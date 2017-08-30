# skeleton.netcore
.NET Core2.0のWebアプリサンプルです。


# アーキテクチャ
- ルーティング -> 属性ベース
- ログ -> Serilog
- データベース -> Npgsql(PostgreSQL)
- テスト -> xUnit, Moq
- フロントエンド -> Webpack

# フォルダ構成
- netcore -> Webアプリ本体
- netcore.test -> Webアプリテスト
- webpack -> Webpack

# コマンド
```cd netcore
dotnet restore
dotnet ef database update
dotnet run
```

```cd netcore.test
dotnet restore
dotnet test
```

```cd webpack
npm install
npm run build
npm run pro
```
