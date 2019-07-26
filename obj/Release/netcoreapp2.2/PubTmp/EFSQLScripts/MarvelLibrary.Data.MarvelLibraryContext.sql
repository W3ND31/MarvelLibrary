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

