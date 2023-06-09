USE [TiendaLibrosDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/05/2023 22:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 01/05/2023 22:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigo_Cliente] [int] NOT NULL,
	[nombre_Cliente] [nvarchar](max) NOT NULL,
	[cedula_Cliente] [int] NOT NULL,
	[fn_Cliente] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 01/05/2023 22:49:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[codigo_Libro] [int] NOT NULL,
	[nombre_Libro] [nvarchar](max) NOT NULL,
	[nombre_Empresa] [nvarchar](30) NOT NULL,
	[descripcion_Libro] [nvarchar](max) NOT NULL,
	[estado_Libro] [bit] NOT NULL,
	[precio_Libro] [decimal](18, 2) NOT NULL,
	[codigo_Cliente] [int] NULL,
	[fechaIngreso_Libro] [datetime2](7) NOT NULL,
	[fechaRetiro_Libro] [datetime2](7) NULL,
	[ClienteId] [int] NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Clientes_ClienteId]
GO
