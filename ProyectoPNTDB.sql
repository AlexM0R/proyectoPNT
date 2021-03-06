USE [ProyectoPNTDB]
GO
ALTER TABLE [dbo].[ListaDeseados] DROP CONSTRAINT [FK_ListaDeseados_Usuarios_usuarioId]
GO
ALTER TABLE [dbo].[ListaDeseados] DROP CONSTRAINT [FK_ListaDeseados_Articulos_articuloId]
GO
ALTER TABLE [dbo].[ListaCompras] DROP CONSTRAINT [FK_ListaCompras_Usuarios_usuarioId]
GO
ALTER TABLE [dbo].[ListaCompras] DROP CONSTRAINT [FK_ListaCompras_Compras_compraId]
GO
ALTER TABLE [dbo].[ListaArticulos] DROP CONSTRAINT [FK_ListaArticulos_Compras_compraId]
GO
ALTER TABLE [dbo].[ListaArticulos] DROP CONSTRAINT [FK_ListaArticulos_Articulos_articuloId]
GO
ALTER TABLE [dbo].[Carrito] DROP CONSTRAINT [FK_Carrito_Usuarios_usuarioId]
GO
ALTER TABLE [dbo].[Carrito] DROP CONSTRAINT [FK_Carrito_Articulos_articuloId]
GO
ALTER TABLE [dbo].[Carrito] DROP CONSTRAINT [DF__Carrito__cantArt__30F848ED]
GO
/****** Object:  Index [IX_ListaDeseados_usuarioId]    Script Date: 14/12/2020 18:51:39 ******/
DROP INDEX [IX_ListaDeseados_usuarioId] ON [dbo].[ListaDeseados]
GO
/****** Object:  Index [IX_ListaCompras_usuarioId]    Script Date: 14/12/2020 18:51:39 ******/
DROP INDEX [IX_ListaCompras_usuarioId] ON [dbo].[ListaCompras]
GO
/****** Object:  Index [IX_ListaArticulos_compraId]    Script Date: 14/12/2020 18:51:39 ******/
DROP INDEX [IX_ListaArticulos_compraId] ON [dbo].[ListaArticulos]
GO
/****** Object:  Index [IX_Carrito_usuarioId]    Script Date: 14/12/2020 18:51:39 ******/
DROP INDEX [IX_Carrito_usuarioId] ON [dbo].[Carrito]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[ListaDeseados]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListaDeseados]') AND type in (N'U'))
DROP TABLE [dbo].[ListaDeseados]
GO
/****** Object:  Table [dbo].[ListaCompras]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListaCompras]') AND type in (N'U'))
DROP TABLE [dbo].[ListaCompras]
GO
/****** Object:  Table [dbo].[ListaArticulos]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListaArticulos]') AND type in (N'U'))
DROP TABLE [dbo].[ListaArticulos]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Compras]') AND type in (N'U'))
DROP TABLE [dbo].[Compras]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Carrito]') AND type in (N'U'))
DROP TABLE [dbo].[Carrito]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Articulos]') AND type in (N'U'))
DROP TABLE [dbo].[Articulos]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/12/2020 18:51:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
USE [master]
GO
/****** Object:  Database [ProyectoPNTDB]    Script Date: 14/12/2020 18:51:39 ******/
DROP DATABASE [ProyectoPNTDB]
GO
/****** Object:  Database [ProyectoPNTDB]    Script Date: 14/12/2020 18:51:39 ******/
CREATE DATABASE [ProyectoPNTDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoPNTDB', FILENAME = N'C:\Users\TKMAFIA\ProyectoPNTDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProyectoPNTDB_log', FILENAME = N'C:\Users\TKMAFIA\ProyectoPNTDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProyectoPNTDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoPNTDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoPNTDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProyectoPNTDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoPNTDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoPNTDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProyectoPNTDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoPNTDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProyectoPNTDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProyectoPNTDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoPNTDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoPNTDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoPNTDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoPNTDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProyectoPNTDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoPNTDB] SET QUERY_STORE = OFF
GO
USE [ProyectoPNTDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ProyectoPNTDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/12/2020 18:51:39 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 14/12/2020 18:51:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numeroArticulo] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[imagen] [nvarchar](max) NOT NULL,
	[stock] [int] NOT NULL,
	[talle] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 14/12/2020 18:51:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[articuloId] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
	[cantArticulos] [int] NOT NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[articuloId] ASC,
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 14/12/2020 18:51:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nroPedido] [int] NOT NULL,
	[fechaCompra] [datetime2](7) NOT NULL,
	[articuloId] [int] NOT NULL,
	[precioTotal] [float] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaArticulos]    Script Date: 14/12/2020 18:51:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaArticulos](
	[articuloId] [int] NOT NULL,
	[compraId] [int] NOT NULL,
 CONSTRAINT [PK_ListaArticulos] PRIMARY KEY CLUSTERED 
(
	[articuloId] ASC,
	[compraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaCompras]    Script Date: 14/12/2020 18:51:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaCompras](
	[compraId] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
 CONSTRAINT [PK_ListaCompras] PRIMARY KEY CLUSTERED 
(
	[compraId] ASC,
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaDeseados]    Script Date: 14/12/2020 18:51:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaDeseados](
	[articuloId] [int] NOT NULL,
	[usuarioId] [int] NOT NULL,
 CONSTRAINT [PK_ListaDeseados] PRIMARY KEY CLUSTERED 
(
	[articuloId] ASC,
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/12/2020 18:51:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [nvarchar](max) NOT NULL,
	[nombreCompleto] [nvarchar](100) NOT NULL,
	[contraseña] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NOT NULL,
	[mail] [nvarchar](max) NOT NULL,
	[carritoId] [int] NOT NULL,
	[deseadosId] [int] NOT NULL,
	[comprasId] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201108051333_ProyectoPNT_MVC.Context.ProyectoPNTDatabaseContext', N'3.1.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201126004920_Carrito_Agrego_cantArticulos', N'3.1.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201212234731_Sacamos_Tipo_Usuario', N'3.1.10')
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (1, 12345687, 750, N'Remera de laicra', N'Remera Sport', N'/images/articulo-007.jpg', 10, N'M')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (2, 87468, 1500, N'Pantalon Adidas', N'Remera crop top', N'/images/articulo-009.jpg', 6, N'L')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (3, 846512, 5000, N'Gorra Lakers Original', N'Adidas Zapatilla VyA', N'/images/articulo-003.jpg', 3, N'S')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (4, 13, 1000, N'Pantalon hombre joggin', N'Pantalon joggin oscuros', N'/images/articulo-013.jpg', 10, N'L')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (5, 4920, 2000, N'Jeans femeninos', N'Pantalones Jeans femeninos', N'/images/articulo-011.jpg', 20, N'M')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (6, 45487, 3500, N'Zapatillas', N'Adidas Zapatilla grises', N'/images/articulo-001.jpg', 8, N'S')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (7, 48787, 2000, N'Buzo', N'Campera Negra Nike', N'/images/articulo-014.jpg', 5, N'XL')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (8, 487745, 1800, N'Campera', N'Campera Adidas', N'/images/articulo-015.jpg', 12, N'S')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (9, 48768, 1300, N'Buzo', N'Buzo Nike', N'/images/articulo-016.jpg', 7, N'M')
INSERT [dbo].[Articulos] ([id], [numeroArticulo], [precio], [descripcion], [nombre], [imagen], [stock], [talle]) VALUES (10, 48765198, 1300, N'Buzo', N'Buzo Adidas', N'/images/articulo-017.jpg', 16, N'M')
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
INSERT [dbo].[Carrito] ([articuloId], [usuarioId], [cantArticulos]) VALUES (1, 9, 8)
INSERT [dbo].[Carrito] ([articuloId], [usuarioId], [cantArticulos]) VALUES (2, 9, 6)
INSERT [dbo].[Carrito] ([articuloId], [usuarioId], [cantArticulos]) VALUES (3, 9, 5)
INSERT [dbo].[Carrito] ([articuloId], [usuarioId], [cantArticulos]) VALUES (4, 9, 4)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id], [nombreUsuario], [nombreCompleto], [contraseña], [direccion], [mail], [carritoId], [deseadosId], [comprasId]) VALUES (7, N'Josesito01', N'Jose Alfonso', N'josesito123', N'La Casa Del Jóse 5432', N'josesuemail@hotmail.com', 7, 7, 7)
INSERT [dbo].[Usuarios] ([id], [nombreUsuario], [nombreCompleto], [contraseña], [direccion], [mail], [carritoId], [deseadosId], [comprasId]) VALUES (8, N'test', N'Test Personita', N'test', N'Testeo 123', N'test@hotmail.com', 0, 0, 0)
INSERT [dbo].[Usuarios] ([id], [nombreUsuario], [nombreCompleto], [contraseña], [direccion], [mail], [carritoId], [deseadosId], [comprasId]) VALUES (9, N'test2', N'Testeando 2', N'test', N'Testeo 123', N'test2@hotmail.com', 9, 9, 9)
INSERT [dbo].[Usuarios] ([id], [nombreUsuario], [nombreCompleto], [contraseña], [direccion], [mail], [carritoId], [deseadosId], [comprasId]) VALUES (11, N'testeo', N'aaaaaaaaaaaa', N'test', N'aaaaaaaaaaa', N'paaaaaaaaaaaa@aaaaa', 11, 11, 11)
INSERT [dbo].[Usuarios] ([id], [nombreUsuario], [nombreCompleto], [contraseña], [direccion], [mail], [carritoId], [deseadosId], [comprasId]) VALUES (12, N'1234', N'1234 1234', N'1234', N'1234 4321', N'1234@hotmail.com', 12, 12, 12)
INSERT [dbo].[Usuarios] ([id], [nombreUsuario], [nombreCompleto], [contraseña], [direccion], [mail], [carritoId], [deseadosId], [comprasId]) VALUES (13, N'aaaaaaaaa', N'aaaaaaaaaaa', N'aaaaaaaaa', N'aaaaaaaaaaaaa', N'aaaaaaaa@aaaaaaaa.com', 13, 13, 13)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Carrito_usuarioId]    Script Date: 14/12/2020 18:51:39 ******/
CREATE NONCLUSTERED INDEX [IX_Carrito_usuarioId] ON [dbo].[Carrito]
(
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ListaArticulos_compraId]    Script Date: 14/12/2020 18:51:39 ******/
CREATE NONCLUSTERED INDEX [IX_ListaArticulos_compraId] ON [dbo].[ListaArticulos]
(
	[compraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ListaCompras_usuarioId]    Script Date: 14/12/2020 18:51:39 ******/
CREATE NONCLUSTERED INDEX [IX_ListaCompras_usuarioId] ON [dbo].[ListaCompras]
(
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ListaDeseados_usuarioId]    Script Date: 14/12/2020 18:51:39 ******/
CREATE NONCLUSTERED INDEX [IX_ListaDeseados_usuarioId] ON [dbo].[ListaDeseados]
(
	[usuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrito] ADD  DEFAULT ((0)) FOR [cantArticulos]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Articulos_articuloId] FOREIGN KEY([articuloId])
REFERENCES [dbo].[Articulos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Articulos_articuloId]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Usuarios_usuarioId] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[Usuarios] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Usuarios_usuarioId]
GO
ALTER TABLE [dbo].[ListaArticulos]  WITH CHECK ADD  CONSTRAINT [FK_ListaArticulos_Articulos_articuloId] FOREIGN KEY([articuloId])
REFERENCES [dbo].[Articulos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaArticulos] CHECK CONSTRAINT [FK_ListaArticulos_Articulos_articuloId]
GO
ALTER TABLE [dbo].[ListaArticulos]  WITH CHECK ADD  CONSTRAINT [FK_ListaArticulos_Compras_compraId] FOREIGN KEY([compraId])
REFERENCES [dbo].[Compras] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaArticulos] CHECK CONSTRAINT [FK_ListaArticulos_Compras_compraId]
GO
ALTER TABLE [dbo].[ListaCompras]  WITH CHECK ADD  CONSTRAINT [FK_ListaCompras_Compras_compraId] FOREIGN KEY([compraId])
REFERENCES [dbo].[Compras] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaCompras] CHECK CONSTRAINT [FK_ListaCompras_Compras_compraId]
GO
ALTER TABLE [dbo].[ListaCompras]  WITH CHECK ADD  CONSTRAINT [FK_ListaCompras_Usuarios_usuarioId] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[Usuarios] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaCompras] CHECK CONSTRAINT [FK_ListaCompras_Usuarios_usuarioId]
GO
ALTER TABLE [dbo].[ListaDeseados]  WITH CHECK ADD  CONSTRAINT [FK_ListaDeseados_Articulos_articuloId] FOREIGN KEY([articuloId])
REFERENCES [dbo].[Articulos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaDeseados] CHECK CONSTRAINT [FK_ListaDeseados_Articulos_articuloId]
GO
ALTER TABLE [dbo].[ListaDeseados]  WITH CHECK ADD  CONSTRAINT [FK_ListaDeseados_Usuarios_usuarioId] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[Usuarios] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListaDeseados] CHECK CONSTRAINT [FK_ListaDeseados_Usuarios_usuarioId]
GO
USE [master]
GO
ALTER DATABASE [ProyectoPNTDB] SET  READ_WRITE 
GO
