# Unityroom Client Library

unityroomのAPIを活用するためのライブラリです。

初心者の方でも手順通り導入すれば簡単に使えることを目標にしています。  
上級者の方は自由に改変していただいたり、このライブラリを使わず直接APIを利用していただいても大丈夫です。

## できること

* スコア送信API呼び出し

今後サーバー側のAPIとともにこのライブラリの機能も増やしていく予定です。

# 動作環境

* Unity 2020.3(LTS)以上

# 導入方法

### PackageManagerを使う方法(おすすめ)

> Windowsの場合はシステムに [Gitクライアント](https://git-scm.com/) がインストールされている必要があります。  
> Macには最初からインストールされています。

> Git触りたくない！!って人は次のUnityPackageを使う方法をご利用ください。

1. Window -> Package Manager
    * <img width="386" alt="image" src="https://github.com/naichilab/unityroom-client-library/assets/7110482/7f1745d3-6014-47bc-b59b-f758c7710227">
1. "+" -> Add package from git URL...
    * <img width="228" alt="image" src="https://github.com/naichilab/unityroom-client-library/assets/7110482/7c83f098-7df6-482e-b64d-404017528170">
1. 以下のURLを入力し、Addを押す
    * https://github.com/naichilab/unityroom-client-library.git?path=Assets/unityroom
2. Unityroom Client Library が導入済みとなれば成功
    * <img width="917" alt="image" src="https://github.com/naichilab/unityroom-client-library/assets/7110482/32f0c8cb-32bd-4c63-8add-c873056bff11">


### UnityPackageを使う方法

1. [Releases](https://github.com/naichilab/unityroom-client-library/releases)のページからunitypackageをダウンロード
2. ダウンロードしたファイルを実行してプロジェクトにインポート
    * <img width="419" alt="image" src="https://github.com/naichilab/unityroom-client-library/assets/7110482/c8dbd566-95e8-4ff8-821c-1b7be2e0a1b5">

# 使い方

## 準備

1. unityroomのゲーム設定にて、HMAC認証用キーをコピーしておく
    *  <img width="907" alt="スクリーンショット 2023-05-16 1 52 19" src="https://github.com/naichilab/unityroom-client-library/assets/7110482/8be131d7-d34f-4f07-bd6e-c74a7795e7c2">
3. プロジェクトビューにあるプレハブ（UnityroomApiClient）をドラッグ＆ドロップしてシーンに配置する
    * プレハブの場所
        * PackageManagerから導入した場合： Projectビューの Packages -> Unityroom Client Library -> Api -> UnityroomApiClient (水色のキューブアイコン)
        * UnityPackageから導入した場合：Projectビューの Assets -> unityroom -> Api -> UnityroomApiClient (水色のキューブアイコン)
    * <img width="385" alt="スクリーンショット 2023-05-16 1 48 44" src="https://github.com/naichilab/unityroom-client-library/assets/7110482/f4eab764-110a-467b-a5ba-f249af1ae62d">
4. 配置した UnityroomApiClient のインスペクタにて `Hmac Key` に先ほどコピーして `HMAC認証用キー` を入力する。
    * <img width="903" alt="スクリーンショット 2023-05-16 1 50 31" src="https://github.com/naichilab/unityroom-client-library/assets/7110482/2d633cbb-7f68-4176-b8eb-47726b667095">

準備は以上です。

## スコア送信API呼び出し方法

任意の場所で下記を呼び出します。

> 補足：もしエラーとなる場合  
> PackageManager経由で導入した場合、UnityroomApiClientが見つからずスクリプトのコンパイルエラーとなることがあるようです。  
> もしそうなった場合はUnityを一度再起動すると改善されます。

```.cs
// ボードNo1にスコア123.45fを送信する。
UnityroomApiClient.Instance.SendScore(1, 123.45f, ScoreboardWriteMode.Always);
```

* 1つ目の引数はボードNoです。unityroomの設定画面でスコアボード一覧画面で確認できます。
* 2つ目の引数はスコア(float)です。
* 3つ目の引数はスコアの記録ルールで３種類あります。unityroomで作成したスコアボードと同じ設定を選んでください。
    * HighScoreDesc：ハイスコア（降順）として記録する
    * HighScoreAsc：ハイスコア（昇順）として記録する
    * Always：ハイスコア（常に記録）として記録する

スコアはゲームオーバー時に自動送信したり、ボタンを押したときなど任意のタイミングで送信したりしてください。

# ライセンス

* MITライセンス
* This library is under the MIT License.
