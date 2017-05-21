-- DB SCRIPTS --

-- USER TABLE --
	USE [AcademicMarkeplace_DEV]
	GO

	/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 21/05/2017 8:25:38 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[AspNetUsers](
		[Id] [nvarchar](128) NOT NULL,
		[Email] [nvarchar](256) NULL,
		[EmailConfirmed] [bit] NOT NULL,
		[PasswordHash] [nvarchar](max) NULL,
		[SecurityStamp] [nvarchar](max) NULL,
		[PhoneNumber] [nvarchar](max) NULL,
		[PhoneNumberConfirmed] [bit] NOT NULL,
		[TwoFactorEnabled] [bit] NOT NULL,
		[LockoutEndDateUtc] [datetime] NULL,
		[LockoutEnabled] [bit] NOT NULL,
		[AccessFailedCount] [int] NOT NULL,
		[UserName] [nvarchar](256) NOT NULL,
	 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	GO

-- ROLES TABLE --
	/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 21/05/2017 8:27:04 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[AspNetRoles](
		[Id] [nvarchar](128) NOT NULL,
		[Name] [nvarchar](256) NOT NULL,
	 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO
	
-- USERROLES TABLE -- 
	/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 21/05/2017 8:25:42 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[AspNetUserRoles](
		[UserId] [nvarchar](128) NOT NULL,
		[RoleId] [nvarchar](128) NOT NULL,
	 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC,
		[RoleId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO

	ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
	REFERENCES [dbo].[AspNetRoles] ([Id])
	ON DELETE CASCADE
	GO

	ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
	GO

	ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
	REFERENCES [dbo].[AspNetUsers] ([Id])
	ON DELETE CASCADE
	GO

	ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
	GO

-- USERLOGINS TABLE --
	/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 21/05/2017 8:27:44 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[AspNetUserLogins](
		[LoginProvider] [nvarchar](128) NOT NULL,
		[ProviderKey] [nvarchar](128) NOT NULL,
		[UserId] [nvarchar](128) NOT NULL,
	 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
	(
		[LoginProvider] ASC,
		[ProviderKey] ASC,
		[UserId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO

	ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
	REFERENCES [dbo].[AspNetUsers] ([Id])
	ON DELETE CASCADE
	GO

	ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
	GO

-- USERCLAIMS TABLE --
	/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 21/05/2017 8:28:14 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[AspNetUserClaims](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[UserId] [nvarchar](128) NOT NULL,
		[ClaimType] [nvarchar](max) NULL,
		[ClaimValue] [nvarchar](max) NULL,
	 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	GO

	ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
	REFERENCES [dbo].[AspNetUsers] ([Id])
	ON DELETE CASCADE
	GO

	ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
	GO

-- MIGRATIONS TABLE -- 
	/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 21/05/2017 8:28:38 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	SET ANSI_PADDING ON
	GO

	CREATE TABLE [dbo].[__MigrationHistory](
		[MigrationId] [nvarchar](150) NOT NULL,
		[ContextKey] [nvarchar](300) NOT NULL,
		[Model] [varbinary](max) NOT NULL,
		[ProductVersion] [nvarchar](32) NOT NULL,
	 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
	(
		[MigrationId] ASC,
		[ContextKey] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	GO

	SET ANSI_PADDING OFF
	GO
	
-- POST TABLE --
	/****** Object:  Table [dbo].[Post]    Script Date: 15/05/2017 2:34:29 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[Post](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Title] [nvarchar](50) NOT NULL,
		[Description] [nvarchar](500) NULL,
		[PostedBy] [nvarchar](128) NOT NULL,
		[PostedDate] [datetime] NOT NULL,
		[CompletedBy] [nvarchar](128) NULL,
		[CompletedDate] [datetime] NULL,
		[Active] [bit] NOT NULL CONSTRAINT [DF_Post_Active]  DEFAULT ((1)),
	 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO

	ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post-CompletedBy_User-Id] FOREIGN KEY([CompletedBy])
	REFERENCES [dbo].[AspNetUsers] ([Id])
	GO

	ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post-CompletedBy_User-Id]
	GO

	ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post-PostedBy_User-Id] FOREIGN KEY([PostedBy])
	REFERENCES [dbo].[AspNetUsers] ([Id])
	GO

	ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post-PostedBy_User-Id]
	GO

-- BALANCE TABLE -- 
	/****** Object:  Table [dbo].[Balance]    Script Date: 15/05/2017 2:34:33 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[Balance](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[UserId] [nvarchar](128) NOT NULL,
		[Balance] [int] NULL,
	 CONSTRAINT [PK_Balance] PRIMARY KEY CLUSTERED 
	(
		[UserId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO

	ALTER TABLE [dbo].[Balance]  WITH CHECK ADD  CONSTRAINT [FK_Balance_Balance] FOREIGN KEY([UserId])
	REFERENCES [dbo].[AspNetUsers] ([Id])
	GO

	ALTER TABLE [dbo].[Balance] CHECK CONSTRAINT [FK_Balance_Balance]
	GO
