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

CREATE TABLE [admin ] (
    [idAdmin] VARCHAR(200) NOT NULL,
    [email] VARCHAR(200) NOT NULL,
    [password] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_admin ] PRIMARY KEY ([idAdmin])
);
GO

CREATE TABLE [productBrand] (
    [idBrand] VARCHAR(200) NOT NULL,
    [brandName] nvarchar(max) NOT NULL,
    [brandDetail] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_productBrand] PRIMARY KEY ([idBrand])
);
GO

CREATE TABLE [productCategory] (
    [idCategory] VARCHAR(200) NOT NULL,
    [categoryName] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_productCategory] PRIMARY KEY ([idCategory])
);
GO

CREATE TABLE [productColor] (
    [idColor] VARCHAR(200) NOT NULL,
    [colorName] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_productColor] PRIMARY KEY ([idColor])
);
GO

CREATE TABLE [productSize] (
    [idSize] VARCHAR(200) NOT NULL,
    [sizeName] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_productSize] PRIMARY KEY ([idSize])
);
GO

CREATE TABLE [productTypes] (
    [idType] VARCHAR(200) NOT NULL,
    [typeName] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_productTypes] PRIMARY KEY ([idType])
);
GO

CREATE TABLE [role] (
    [Id] nvarchar(450) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [NormalizedName] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_role] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [roleClaims] (
    [Id] int NOT NULL,
    [RoleId] nvarchar(max) NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL
);
GO

CREATE TABLE [userClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(max) NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_userClaims] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [userLogins] (
    [LoginProvider] nvarchar(max) NULL,
    [ProviderKey] nvarchar(max) NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(max) NULL
);
GO

CREATE TABLE [userRoles] (
    [UserId] nvarchar(max) NULL,
    [RoleId] nvarchar(max) NULL
);
GO

CREATE TABLE [users] (
    [idUser] VARCHAR(200) NOT NULL,
    [firstName] nvarchar(200) NOT NULL,
    [lastName] nvarchar(200) NOT NULL,
    [birthday] datetime2 NOT NULL,
    [note] nvarchar(1000) NOT NULL,
    [province] nvarchar(200) NULL,
    [interestedIn] nvarchar(1000) NOT NULL,
    [address] nvarchar(2000) NULL,
    [lastLogin] datetime2 NOT NULL,
    [avatar] VARCHAR(200) NULL,
    [Id] nvarchar(max) NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY ([idUser])
);
GO

CREATE TABLE [userTokens] (
    [UserId] nvarchar(max) NULL,
    [LoginProvider] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Value] nvarchar(max) NULL
);
GO

CREATE TABLE [vouchers] (
    [idVoucher] VARCHAR(200) NOT NULL,
    [price] int NOT NULL,
    [expiredDate] nvarchar(max) NOT NULL,
    [isUse] tinyint NOT NULL DEFAULT CAST(0 AS tinyint),
    CONSTRAINT [PK_vouchers] PRIMARY KEY ([idVoucher])
);
GO

CREATE TABLE [products] (
    [idProduct] VARCHAR(200) NOT NULL,
    [idSize] VARCHAR(200) NOT NULL,
    [idBrand] VARCHAR(200) NOT NULL,
    [idColor] VARCHAR(200) NOT NULL,
    [idCategory] VARCHAR(200) NOT NULL,
    [idType] VARCHAR(200) NOT NULL,
    [productName] nvarchar(max) NULL,
    [price] nvarchar(max) NULL,
    [salePrice] VARCHAR(200) NOT NULL,
    [photoReview] VARCHAR(200) NOT NULL,
    [detail] nvarchar(2000) NOT NULL,
    [isSaling] tinyint NOT NULL,
    [expiredSalingDate] datetime2 NOT NULL,
    [dateAdded] datetime2 NOT NULL,
    CONSTRAINT [PK_products] PRIMARY KEY ([idProduct]),
    CONSTRAINT [FK_products_productBrand_idBrand] FOREIGN KEY ([idBrand]) REFERENCES [productBrand] ([idBrand]) ON DELETE CASCADE,
    CONSTRAINT [FK_products_productCategory_idCategory] FOREIGN KEY ([idCategory]) REFERENCES [productCategory] ([idCategory]) ON DELETE CASCADE,
    CONSTRAINT [FK_products_productColor_idColor] FOREIGN KEY ([idColor]) REFERENCES [productColor] ([idColor]) ON DELETE CASCADE,
    CONSTRAINT [FK_products_productSize_idSize] FOREIGN KEY ([idSize]) REFERENCES [productSize] ([idSize]) ON DELETE CASCADE,
    CONSTRAINT [FK_products_productTypes_idType] FOREIGN KEY ([idType]) REFERENCES [productTypes] ([idType]) ON DELETE CASCADE
);
GO

CREATE TABLE [odersList] (
    [idOrderList] nvarchar(450) NOT NULL,
    [idUser] VARCHAR(200) NOT NULL,
    [status] int NOT NULL,
    [date] datetime2 NOT NULL,
    [idVoucher] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_odersList] PRIMARY KEY ([idOrderList]),
    CONSTRAINT [FK_odersList_users_idUser] FOREIGN KEY ([idUser]) REFERENCES [users] ([idUser]) ON DELETE CASCADE
);
GO

CREATE TABLE [productPhotos] (
    [IdPhoto] nvarchar(450) NOT NULL,
    [idProduct] VARCHAR(200) NOT NULL,
    [link] VARCHAR(200) NOT NULL,
    [uploadedTime] datetime2 NOT NULL,
    CONSTRAINT [PK_productPhotos] PRIMARY KEY ([IdPhoto]),
    CONSTRAINT [FK_productPhotos_products_idProduct] FOREIGN KEY ([idProduct]) REFERENCES [products] ([idProduct]) ON DELETE CASCADE
);
GO

CREATE TABLE [rating] (
    [Id] nvarchar(450) NOT NULL,
    [idUser] VARCHAR(200) NOT NULL,
    [idProduct] VARCHAR(200) NOT NULL,
    [comment] nvarchar(2000) NOT NULL,
    [rateDate] datetime2 NOT NULL,
    [rate] int NOT NULL,
    CONSTRAINT [PK_rating] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_rating_products_idProduct] FOREIGN KEY ([idProduct]) REFERENCES [products] ([idProduct]) ON DELETE CASCADE,
    CONSTRAINT [FK_rating_users_idUser] FOREIGN KEY ([idUser]) REFERENCES [users] ([idUser]) ON DELETE CASCADE
);
GO

CREATE TABLE [odersDetails] (
    [idOder] VARCHAR(200) NOT NULL,
    [idOrderList] nvarchar(450) NULL,
    [totalPrice] int NOT NULL,
    [idProduct] VARCHAR(200) NOT NULL,
    [quality] int NOT NULL,
    CONSTRAINT [PK_odersDetails] PRIMARY KEY ([idOder]),
    CONSTRAINT [FK_odersDetails_odersList_idOrderList] FOREIGN KEY ([idOrderList]) REFERENCES [odersList] ([idOrderList]) ON DELETE NO ACTION,
    CONSTRAINT [FK_odersDetails_products_idProduct] FOREIGN KEY ([idProduct]) REFERENCES [products] ([idProduct]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idUser', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'Id', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName', N'address', N'avatar', N'birthday', N'firstName', N'interestedIn', N'lastLogin', N'lastName', N'note', N'province') AND [object_id] = OBJECT_ID(N'[users]'))
    SET IDENTITY_INSERT [users] ON;
INSERT INTO [users] ([idUser], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [Id], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [address], [avatar], [birthday], [firstName], [interestedIn], [lastLogin], [lastName], [note], [province])
VALUES ('2', 0, N'a156ccb1-67ce-4e42-bb89-6a4b73d724c9', N'nhattruongtp2000@gmail.com', CAST(1 AS bit), N'69BD714F-9576-45BA-B5B7-F00649BE00DE', CAST(0 AS bit), NULL, N'nhattruongtp2000@gmail.com', N'admin', N'AQAAAAEAACcQAAAAEPwefgK4XVXnKu4ehkmqQ3LfhPy9/mCkQ8/5gW6q1ti+hYCPKkODNGSUR/NCuIC9ew==', NULL, CAST(0 AS bit), N'', CAST(0 AS bit), N'admin', N'asd', 'asd', '2020-10-12T00:00:00.0000000', N'Nguyen', N'asd', '2020-11-13T00:00:00.0000000', N'Truong', N'asd', N'asd');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'idUser', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'Id', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName', N'address', N'avatar', N'birthday', N'firstName', N'interestedIn', N'lastLogin', N'lastName', N'note', N'province') AND [object_id] = OBJECT_ID(N'[users]'))
    SET IDENTITY_INSERT [users] OFF;
GO

CREATE INDEX [IX_odersDetails_idOrderList] ON [odersDetails] ([idOrderList]);
GO

CREATE INDEX [IX_odersDetails_idProduct] ON [odersDetails] ([idProduct]);
GO

CREATE INDEX [IX_odersList_idUser] ON [odersList] ([idUser]);
GO

CREATE INDEX [IX_productPhotos_idProduct] ON [productPhotos] ([idProduct]);
GO

CREATE INDEX [IX_products_idBrand] ON [products] ([idBrand]);
GO

CREATE INDEX [IX_products_idCategory] ON [products] ([idCategory]);
GO

CREATE INDEX [IX_products_idColor] ON [products] ([idColor]);
GO

CREATE INDEX [IX_products_idSize] ON [products] ([idSize]);
GO

CREATE INDEX [IX_products_idType] ON [products] ([idType]);
GO

CREATE INDEX [IX_rating_idProduct] ON [rating] ([idProduct]);
GO

CREATE INDEX [IX_rating_idUser] ON [rating] ([idUser]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210101063342_a', N'5.0.0');
GO

COMMIT;
GO

