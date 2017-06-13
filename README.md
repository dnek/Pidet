# Pidet
IDE for Piet.

## Overview
- 難解プログラミング言語「Piet」のエディタとデバッガの機能を備えたIDEです。
- 開発言語はC#です。
- Pietの仕様はこちらを参照して下さい。
  - http://www.dangermouse.net/esoteric/piet.html
  - http://www.kembo.org/piet/index.htm
- こちらもどうぞ。
  - http://www.slideshare.net/KMC_JP/piet-46068527
- こちらにビルド済みの実行ファイルがあります。最新リリースのPidet*.zipの中にあります。
  - https://github.com/kndama/Pidet/releases

## Usage
### エディタ
- キャンバスの編集ツールには、「Pen」と「Selector」の2種類があります。「ChangeTool」ボタンで切り替えます。
- 「Pen」では自由線を引くことが出来ます。
- 「Selector」では矩形選択が出来ます。
  - Ctrlを押しながら追加で選択することも出来ます。
  - 選択した後、EnterキーまたはSpaceキーで色を塗ることが出来ます。また、Deleteキーで白色を塗ることが出来ます。
  - ダブルクリックでカラーブロックを選択出来ます。
  - 矩形選択時のみ、コピー、切り取り、及び、貼り付けが出来ます。
- Undo・Redoが出来ます。
- メニューバーの「イメージ」からキャンバスサイズの変更が出来ます。また、Ctrl+Alt+カーソルキーで1codelずつ調整することも出来ます。
- メニューバーの「表示」からcodelの拡大率が変更出来ます。また、Ctrl+"+"とCtrl+"-"及びAlt+マウスホイールでも拡大率が変更出来ます。
- パレット上の各色を左クリックするとツールで描画する色が選択出来ます。また、Ctrl+カーソルキーでも選択色を変更出来ます。選択色はパレットの右下に表示されます。
- 〃を左ダブルクリックすると選択中のcodelをまとめて塗ることが出来ます。
- 〃を右クリックすると選択した色を移動元とした移動先のコマンドが他の各色に表示されます。また、Alt+カーソルキーでも変更出来ます。
- 〃をCtrlキーを押しながら左クリックするとcurrent codel(選択中のセルの中で1つだけ濃い網掛けのcodel)をクリックした色に変更すると同時に、相対的な色相と明度を維持するように他のすべてのcodelの色を変更出来ます。
- キャンバス上のcodelを右クリック、またはCtrl+Kでも描画色が選択出来ます(カラーピッカー)。
- Shift+Alt+カーソルキーでキャンバスを平行移動出来ます。

### デバッガ
- 「デバッグ開始」でデバッグを最後まで実行します。入力が不足している場合や処理が1,000,000回続いた場合デバッグを一時停止します。
- 「ジャンプ実行」でデバッグを指定回数進めます。
- 「ステップ実行」でデバッグを1コマンドずつ進めます。
- Ctrl+Bでブレークポイントの設定/解除が出来ます(デバッグ中の設定は出来ません)。
  - 複数codelを選択している場合はcurrent codelが基準になります。
  - Ctrl+Shift+Bでcurrent codelの状態にかかわらず解除します。
- ステップ実行中にはキャンバス左に直前のコマンド実行前後のスタックの状態が表示されます。
- 〃にはキャンバス右下に出力結果が表示されます。
- 〃にはキャンバス上でプログラムポインタの移動元と移動先のcodelが網掛けで表示されます。

### ファイル
- 画像ファイル(png, bmp)の読み込み・保存が出来ます。
- キャンバス上にドラッグ&ドロップしてファイルを読み込むことも出来ます。
- 画像ファイルのパスをコマンドライン引数に取って、Pidet起動時にファイルを読み込むことも出来ます(つまり「プログラムから開く」でPidetを選択して起動することが出来ます)。
- 読み込み・保存時にcodelの大きさを指定出来ます。
- 読み込み時、追加色は白ブロックに変換します。

## Author
- dama([@dnek_](https://twitter.com/dnek_))

## License
- MIT License

## Requirement
- このソフトウェアはMicrosoft Visual Studioで作成されています。起動できない場合は↓等からMicrosoft .NET Framework 4.5以上のコンポーネントをインストールしてください。
	- http://www.microsoft.com/ja-jp/download/details.aspx?id=30653

## Install/Uninstall
- レジストリや設定ファイルは使用していないので、何もする必要はありません。不要になればファイルをそのまま削除してください。

## Changes
### 20150317
- バグ修正。
### 20150425
- ステータスの背景色がデバッグ中に変わるようにした。
- DPとCCの表記が数値のみだったのを改善。
- Ctrl+Kによるカラーピッカーを実装。
- ツールによってキャンバス上でのマウスカーソルが変わるようにした。
### 20150426
- ステップ数をステータスに表示。
- Alt+マウスホイールによるcodelの拡大率変更を実装。
- テキストボックスでのCtrl+Aによる全選択を実装。
- フォーカスによる操作の適用範囲を調整。
- Cキーもツール変更のショートカットキーに適用。
- キャンバスフォーカス時に外枠を表示。
- ブレークポイントを実装。
- キャンバス上にホバーすると自動的にキャンバスをフォーカスするようにした。
- デバッグを一時停止する回数を1,000,000回に増やした。また、一時停止した際にデバッグモード自体を終了するように変更。
### 20150428
- ジャンプ実行を実装。
### 20150428_1
- Undo/Redoとブレークポイントの不整合によるバグを修正。
### 20150504
- 入出力において改行をLFに統一した(CRLFはLFに置換される)。
### 20150619
- ステータスに対角線の長さの自乗を表示。
- 矩形コピー、切り取り、貼り付けを実装。
- 平行移動を実装。
### 20150625
- デバッグ時にstatusが見切れるのを修正。
### 20150709
- 処理可能な列数を増やした。
- 対応するファイル形式をpngとbmpだけにした。
### 20150720
- ステップ実行中にもキャンバスのスクロールやカラーピックが出来るようにした。
### 20150721
- Ctrl+Bだけでブレークポイントの解除も出来るようにした。
### 20150808
- 画像ファイルの読み込みとデバッグの準備の処理を高速化した。
### 20150814
- クリップボードが空の時に貼り付けようとすると例外で落ちるのを修正。
### 20150821
- GitHubで公開するためにreadmeを修正。
### 20150902
- modを修正(上記仕様の"The result has the same sign as the divisor (the top value)."に基づく)。
### 20150907
- 前回のmodの修正が誤っていたので再修正。
### 20150908
- file dirty markerを表示するようにした。
### 20170614
- 白codel上の挙動についてPiet公式の仕様に準拠。
- レイアウトの微修正。
