BEGIN TRANSACTION;
GO

ALTER TABLE [Accounts] ADD [AccountNumber] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230530120215_ManyToMany', N'6.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ATable] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_ATable] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [BTable] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_BTable] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AB] (
    [AListId] int NOT NULL,
    [BListId] int NOT NULL,
    CONSTRAINT [PK_AB] PRIMARY KEY ([AListId], [BListId]),
    CONSTRAINT [FK_AB_ATable_AListId] FOREIGN KEY ([AListId]) REFERENCES [ATable] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AB_BTable_BListId] FOREIGN KEY ([BListId]) REFERENCES [BTable] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AB_BListId] ON [AB] ([BListId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230530120313_ManyToMany1', N'6.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Accounts] DROP CONSTRAINT [FK_Accounts_Customers_CustomerId];
GO

ALTER TABLE [AccountTransaction] DROP CONSTRAINT [FK_AccountTransaction_Accounts_AccountId];
GO

ALTER TABLE [Accounts] DROP CONSTRAINT [PK_Accounts];
GO

EXEC sp_rename N'[Accounts]', N'Musteri';
GO

EXEC sp_rename N'[Musteri].[AccountNumber]', N'MusteriNo', N'COLUMN';
GO

EXEC sp_rename N'[Musteri].[IX_Accounts_CustomerId]', N'IX_Musteri_CustomerId', N'INDEX';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Musteri]') AND [c].[name] = N'MusteriNo');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Musteri] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Musteri] ALTER COLUMN [MusteriNo] varchar(50) NOT NULL;
ALTER TABLE [Musteri] ADD DEFAULT '' FOR [MusteriNo];
GO

ALTER TABLE [Musteri] ADD CONSTRAINT [PK_Musteri] PRIMARY KEY ([Id]);
GO

ALTER TABLE [AccountTransaction] ADD CONSTRAINT [FK_AccountTransaction_Musteri_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Musteri] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Musteri] ADD CONSTRAINT [FK_Musteri_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230530120948_AccountConfig', N'6.0.16');
GO

COMMIT;
GO

