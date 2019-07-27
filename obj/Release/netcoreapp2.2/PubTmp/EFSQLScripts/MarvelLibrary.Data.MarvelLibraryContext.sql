IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190725174152_inicial')
BEGIN
    CREATE TABLE [Character] (
        [Id] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Desc] nvarchar(max) NULL,
        [Modified] datetime2 NOT NULL,
        [Thumbnail] nvarchar(max) NULL,
        CONSTRAINT [PK_Character] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190725174152_inicial')
BEGIN
    CREATE TABLE [Comic] (
        [Id] int NOT NULL,
        [Title] nvarchar(max) NULL,
        [Format] nvarchar(max) NULL,
        [PageCount] int NOT NULL,
        [SeriesName] nvarchar(max) NULL,
        [OnSaleDate] datetime2 NOT NULL,
        [Thumbnail] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Comic] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190725174152_inicial')
BEGIN
    CREATE TABLE [ComicCharacter] (
        [ComicId] int NOT NULL,
        [CharacterId] int NOT NULL,
        CONSTRAINT [PK_ComicCharacter] PRIMARY KEY ([ComicId], [CharacterId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190725174152_inicial')
BEGIN
    CREATE TABLE [Fav] (
        [Id] int NOT NULL IDENTITY,
        [CharacterId] int NOT NULL,
        CONSTRAINT [PK_Fav] PRIMARY KEY ([Id], [CharacterId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190725174152_inicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190725174152_inicial', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727021835_Accounts')
BEGIN
    CREATE TABLE [Account] (
        [Login] nvarchar(450) NOT NULL,
        [Password] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [PwHash] nvarchar(max) NULL,
        CONSTRAINT [PK_Account] PRIMARY KEY ([Login])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727021835_Accounts')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190727021835_Accounts', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727040035_account_v2')
BEGIN
    ALTER TABLE [Fav] DROP CONSTRAINT [PK_Fav];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727040035_account_v2')
BEGIN
    ALTER TABLE [Fav] ADD [AccountLogin] nvarchar(450) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727040035_account_v2')
BEGIN
    ALTER TABLE [Fav] ADD CONSTRAINT [PK_Fav] PRIMARY KEY ([Id], [CharacterId], [AccountLogin]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727040035_account_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190727040035_account_v2', N'2.2.6-servicing-10079');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727064528_update_fav')
BEGIN
    ALTER TABLE [Fav] DROP CONSTRAINT [PK_Fav];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727064528_update_fav')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Fav]') AND [c].[name] = N'Id');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Fav] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Fav] DROP COLUMN [Id];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727064528_update_fav')
BEGIN
    ALTER TABLE [Fav] ADD CONSTRAINT [PK_Fav] PRIMARY KEY ([CharacterId], [AccountLogin]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190727064528_update_fav')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190727064528_update_fav', N'2.2.6-servicing-10079');
END;

GO

