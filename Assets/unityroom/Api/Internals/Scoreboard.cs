using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

namespace unityroom.Api.Internals
{
    internal class Scoreboard : MonoBehaviour
    {
        /// <summary>
        /// サーバーにスコアを送信する最短の間隔(秒)
        /// </summary>
        private const int IntervalSeconds = 6;
        /// <summary>
        /// サーバーにスコア送信失敗した場合の最大リトライ回数
        /// </summary>
        private const int MaxTryCount = 2;
        private readonly RetryCounter _retryCounter = new RetryCounter(MaxTryCount);
        private readonly ScoreHolder _scoreHolder = new ScoreHolder();
        private readonly TimeKeeper _timeKeeper = new TimeKeeper(IntervalSeconds);
        private int _boardNo;
        private string _hmacKey;

        private void Update()
        {
            if (_scoreHolder.ScoreChanged && !_timeKeeper.IsBusy()) { StartCoroutine(SendScoreEnumerator()); }
        }

        internal void Initialize(int boardNo, string hmacKey)
        {
            _boardNo = boardNo;
            _hmacKey = hmacKey;
        }

        internal void AddScore(float score, ScoreboardWriteMode mode)
        {
            var scoreUpdated = _scoreHolder.SetNewScore(score, mode);
            Debug.Log(
                scoreUpdated ? $"[unityroom] スコア送信予約 BoardNo={_boardNo} Score={score}"
                    : $"[unityroom] ハイスコア未更新のため送信しません BoardNo={_boardNo} Score={score}"
            );
        }

        private IEnumerator SendScoreEnumerator()
        {
            _timeKeeper.Reset();
            var score = _scoreHolder.Score;
            if (Util.IsEditor())
            {
                Debug.Log($"[unityroom] スコア送信 BoardNo={_boardNo} Score={score} (unityroomにゲームをアップロードすると実際に送信されます)");
                _retryCounter.Reset();
                _scoreHolder.ResetChangedFlag();
                yield break;
            }

            Debug.Log(
                $"[unityroom] スコア送信開始 BoardNo={_boardNo} Score={score} {(_retryCounter.Count > 0 ? $"リトライ{_retryCounter.Count}回目" : "")}"
            );
            using var request = CreateRequest(score);
            yield return request.SendWebRequest();
            _retryCounter.Increment();

            //結果をログに表示
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(
                    $"[unityroom] スコア送信成功 BoardNo={_boardNo} Score={score} Response={request.responseCode} Data={request.downloadHandler.text} "
                );
                _retryCounter.Reset();
                _scoreHolder.ResetChangedFlag();
            }
            else
            {
                //失敗
                Debug.Log(
                    $"[unityroom] スコア送信失敗 BoardNo={_boardNo} Score={score} Response={request.responseCode} Data={request.downloadHandler.text} リトライ残={_retryCounter.RemainCount} "
                );
            }

            if (!_retryCounter.CanRetry)
            {
                _scoreHolder.ResetChangedFlag();
                _retryCounter.Reset();
            }
        }

        private UnityWebRequest CreateRequest(float score)
        {
            // スコア送信APIエンドポイント
            var path = $"/gameplay_api/v1/scoreboards/{_boardNo}/scores";

            // 現在のUNIX TIMEを取得
            var unixTime = UnixTime.GetCurrentUnixTime()
                .ToString();

            // 送信するスコアを文字列に変換しておく
            var scoreText = score.ToString(CultureInfo.InvariantCulture);

            // 認証用のHMAC(Hash-based Message Authentication Code)を計算する
            var hmacDataText = $"POST\n{path}\n{unixTime}\n{scoreText}";
            var hmac = Hmac.GetHmacSha256(hmacDataText, _hmacKey);

            // APIリクエストを送信する
            // スコアはFormDataとして付与する
            // 認証用の情報はリクエストヘッダーに付与する
            var form = new WWWForm();
            form.AddField("score", scoreText);
            var request = UnityWebRequest.Post(path, form);
            request.SetRequestHeader("X-Unityroom-Signature", hmac);
            request.SetRequestHeader("X-Unityroom-Timestamp", unixTime);
            return request;
        }
    }
}