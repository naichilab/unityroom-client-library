## インポート方法






# Unityroom Client Library

unityroomのAPIを活用するためのライブラリです。

初心者の方でも手順通り導入すれば簡単に使えることを目的にしています。

## できること

* スコアランキング送信APIの利用

# 動作環境

* Unity 2020.3(LTS)以上

# 導入方法

## PackageManagerを使う場合

> Windowsの場合はシステムに [Gitクライアント](https://git-scm.com/) がインストールされている必要があります。  
> Macは最初からインストールされているため不要です。

1. Window -> Package Manager
    * 画像
1. "+" -> Add package from git URL...
    * 画像
1. 以下のURLを入力し、Addを押す
    * https://github.com/naichilab/unityroom-client-library.git?path=Assets/unityroom
2. Unityroom Client Library が導入済みとなれば成功
    * 画像

## UnityPackageを使う場合

1. こちらからダウンロード
    * 画像
2. ダウンロードしたファイルを実行してプロジェクトにインポート
    * 画像

# 使い方

## 準備

1. Projectビューの Packages -> Unityroom Client Library -> Api -> UnityroomApiClient (プレハブ) をシーンに配置する
    * 画像
1. 配置した UnityroomApiClient のインスペクタにて `Hmac Key` を入力する。
    * 画像

## スコア送信方法

* 任意の場所で下記を呼び出す

```.cs
// ボードNo1にスコア123.45fを送信する。
UnityroomApiClient.Instance.SendScore(1, 123.45f, ScoreboardWriteMode.Always);
```

3つ目の引数は３種類あります。
unityroomで作成したスコアボードと同じ設定を選んでください。

* HighScoreDesc：ハイスコア（降順）として記録する
* HighScoreAsc：ハイスコア（昇順）として記録する
* Always：ハイスコア（常に記録）として記録する

# ライセンス

* MITライセンス
* This library is under the MIT License.
