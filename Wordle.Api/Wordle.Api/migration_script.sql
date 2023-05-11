IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427222812_Word')
BEGIN
    CREATE TABLE [Words] (
        [WordId] int NOT NULL IDENTITY,
        [Text] nvarchar(max) NOT NULL,
        [IsCommon] bit NOT NULL,
        CONSTRAINT [PK_Words] PRIMARY KEY ([WordId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427222812_Word')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230427222812_Word', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504214159_AddIsUsed')
BEGIN
    ALTER TABLE [Words] ADD [IsUsed] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504214159_AddIsUsed')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230504214159_AddIsUsed', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509224012_PUpdate')
BEGIN
    CREATE TABLE [Players] (
        [PlayerId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [GameCount] int NOT NULL,
        [TotalAttempts] int NOT NULL,
        [AverageAttempts] float NOT NULL,
        [TotalSecondsPlayed] int NOT NULL,
        [AverageSecondsPerGame] int NOT NULL,
        CONSTRAINT [PK_Players] PRIMARY KEY ([PlayerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509224012_PUpdate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230509224012_PUpdate', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509225737_PUpdate2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230509225737_PUpdate2', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509231424_PUpdate3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230509231424_PUpdate3', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230511070945_PUpdate4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230511070945_PUpdate4', N'7.0.5');
END;
GO

COMMIT;
GO

