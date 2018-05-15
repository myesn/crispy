IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Applications] (
    [Id] uniqueidentifier NOT NULL,
    [DateTimeCreated] datetime2 NOT NULL,
    [Deleted] bit NOT NULL,
    [Enabler] bit NOT NULL,
    [Encryption] bit NOT NULL,
    [IncludeGlobalConfig] bit NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Applications] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Environments] (
    [Id] uniqueidentifier NOT NULL,
    [ApplicatoinId] uniqueidentifier NOT NULL,
    [DateTimeCreated] datetime2 NOT NULL,
    [Deleted] bit NOT NULL,
    [Enabler] bit NOT NULL,
    [Encryption] bit NOT NULL,
    [IncludeGlobalConfig] bit NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_Environments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Environments_Applications_ApplicatoinId] FOREIGN KEY ([ApplicatoinId]) REFERENCES [Applications] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Variables] (
    [Id] uniqueidentifier NOT NULL,
    [ApplicationId] uniqueidentifier NULL,
    [DateTimeCreated] datetime2 NOT NULL,
    [Deleted] bit NOT NULL,
    [Enabler] bit NOT NULL,
    [Key] nvarchar(50) NOT NULL,
    [Value] nvarchar(1280) NOT NULL,
    CONSTRAINT [PK_Variables] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Variables_Applications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications] ([Id]) ON DELETE SET NULL
);

GO

CREATE TABLE [KeyValuePairs] (
    [Id] uniqueidentifier NOT NULL,
    [ApplyType] int NOT NULL,
    [DateTimeCreated] datetime2 NOT NULL,
    [Deleted] bit NOT NULL,
    [Description] nvarchar(256) NULL,
    [Enabler] bit NOT NULL,
    [EnvironmentId] uniqueidentifier NULL,
    [Key] nvarchar(50) NOT NULL,
    [Timestamp] rowversion NULL,
    [Value] nvarchar(1280) NULL,
    [ValueType] int NOT NULL,
    CONSTRAINT [PK_KeyValuePairs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_KeyValuePairs_Environments_EnvironmentId] FOREIGN KEY ([EnvironmentId]) REFERENCES [Environments] ([Id]) ON DELETE SET NULL
);

GO

CREATE TABLE [KeyValuePairHistories] (
    [Id] uniqueidentifier NOT NULL,
    [DateTimeCreated] datetime2 NOT NULL,
    [KeyValuePairId] uniqueidentifier NOT NULL,
    [Value] nvarchar(1280) NULL,
    [ValueType] int NOT NULL,
    CONSTRAINT [PK_KeyValuePairHistories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_KeyValuePairHistories_KeyValuePairs_KeyValuePairId] FOREIGN KEY ([KeyValuePairId]) REFERENCES [KeyValuePairs] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Environments_ApplicatoinId] ON [Environments] ([ApplicatoinId]);

GO

CREATE INDEX [IX_KeyValuePairHistories_KeyValuePairId] ON [KeyValuePairHistories] ([KeyValuePairId]);

GO

CREATE INDEX [IX_KeyValuePairs_EnvironmentId] ON [KeyValuePairs] ([EnvironmentId]);

GO

CREATE INDEX [IX_Variables_ApplicationId] ON [Variables] ([ApplicationId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180515092405_Crispy', N'2.0.3-rtm-10026');

GO

