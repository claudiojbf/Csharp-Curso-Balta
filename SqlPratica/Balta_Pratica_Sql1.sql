CREATE DATABASE [balta]

USE[balta]

CREATE TABLE [Student]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(120) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Document] NVARCHAR(20) NOT NULL,
    [Phone] NVARCHAR(20) NOT NULL,
    [Birthdate] DATETIME NULL,
    [CreateData] DATETIME NOT NULL DEFAULT(GETDATE()),
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
);
GO

create table [Author]
(
    [Id] UNIQUEIDENTIFIER not NULL,
    [Name] NVARCHAR(80) NOT NULL,
    [Title] NVARCHAR(80) NOT NULL,
    [Image] NVARCHAR(1024) not NULL,
    [Bio] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(450) NULL,
    [Email] NVARCHAR(160) NOT NULL,
    [Type] TINYINT NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Career]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Title] nvarchar(160) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [DurationInMinutes] INT NOT NULL,
    [Active] BIT NOT NULL,
    [Featured] BIT NOT NULL,
    [Tags] NVARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Career] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Category]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Order] int NOT NULL,
    [Description] TEXT NOT NULL,
    [Featured] BIT NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Course]
(
    [Id] UNIQUEIDENTIFIER not NULL,
    [Tag] NVARCHAR(20) NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Level] TINYINT NOT NULL,
    [DurationInMinutes] INT NOT NULL,
    [CreateData] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateDate] DATETIME NOT NULL,
    [Active] BIT NOT NULL,
    [Free] BIT NOT NULL,
    [Featured] BIT NOT NULL,
    [AuthorId] UNIQUEIDENTIFIER NOT NULL,
    [CategoryId] UNIQUEIDENTIFIER NOT NULL,
    [Tags] NVARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Course_Author_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Author] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Course_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION,
);
GO

CREATE TABLE [CareerItem]
(
    [CareerId] UNIQUEIDENTIFIER not NULL,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Description] TEXT NOT NULL,
    [Order] TINYINT NOT NULL,
    CONSTRAINT [PK_CareerItem] PRIMARY KEY ([CareerId], [CourseId]),
    CONSTRAINT [FK_CareerItem_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CarrerItem_Career_CareerId] FOREIGN KEY ([CareerId]) REFERENCES [Career] ([Id]) ON DELETE NO ACTION,
);
GO

CREATE TABLE [StudentCourse]
(
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [StudentId] UNIQUEIDENTIFIER NOT NULL,
    [Progrees] TINYINT NOT NULL,
    [Favorite] BIT NOT NULL,
    [StartDate] DATETIME NOT NULL,
    [LastUpdateDate] DATETIME NULL DEFAULT(GETDATE()),
    CONSTRAINT [PK_StudentCourse] PRIMARY KEY ([CourseId], [StudentId]),
    CONSTRAINT [FK_StudentCourse_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course]([Id]),
    CONSTRAINT [FK_StudentCourse_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]),
);
GO