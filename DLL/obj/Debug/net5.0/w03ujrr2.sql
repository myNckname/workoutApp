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

CREATE TABLE [Diets] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Diets] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Statistics] (
    [Id] int NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [CaloriesCount] int NOT NULL,
    [ExcersiesCount] int NOT NULL,
    CONSTRAINT [PK_Statistics] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Workouts] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Icon] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Workouts] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [DietId] int NULL,
    [StatisticsId] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Diets_DietId] FOREIGN KEY ([DietId]) REFERENCES [Diets] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Users_Statistics_StatisticsId] FOREIGN KEY ([StatisticsId]) REFERENCES [Statistics] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UsersProfiles] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Icon] nvarchar(max) NULL,
    [Weight] real NOT NULL,
    [BodyType] nvarchar(24) NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_UsersProfiles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UsersProfiles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UsersWorkouts] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [WorkoutId] int NOT NULL,
    [SpentTime] int NOT NULL,
    [SpentCalories] int NOT NULL,
    CONSTRAINT [PK_UsersWorkouts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UsersWorkouts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UsersWorkouts_Workouts_WorkoutId] FOREIGN KEY ([WorkoutId]) REFERENCES [Workouts] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Users_DietId] ON [Users] ([DietId]);
GO

CREATE INDEX [IX_Users_StatisticsId] ON [Users] ([StatisticsId]);
GO

CREATE UNIQUE INDEX [IX_UsersProfiles_UserId] ON [UsersProfiles] ([UserId]);
GO

CREATE INDEX [IX_UsersWorkouts_UserId] ON [UsersWorkouts] ([UserId]);
GO

CREATE INDEX [IX_UsersWorkouts_WorkoutId] ON [UsersWorkouts] ([WorkoutId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210329104715_Initial', N'5.0.4');
GO

COMMIT;
GO

