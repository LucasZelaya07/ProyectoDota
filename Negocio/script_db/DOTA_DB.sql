use master
go 
create database DOTA_DB
go
use DOTA_DB
go
USE [DOTA_DB]
GO

/****** Object:  Table [dbo].[ELEMENTOS]    Script Date: 8/5/2021 9:48:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ELEMENTOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_ELEMENTOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DOTA_DB]
GO

/****** Object:  Table [dbo].[DOTA]    Script Date: 8/5/2021 9:48:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HEROES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[UrlImagen] [varchar](300) NULL,
	[IdTipo] [int] NULL,
	[IdDebilidad] [int] NULL,
	[IdVentaja] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_HEROES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HEROES]  WITH CHECK ADD  CONSTRAINT [FK_HEROES_ELEMENTOS] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[ELEMENTOS] ([Id])
GO

ALTER TABLE [dbo].[HEROES] CHECK CONSTRAINT [FK_HEROES_ELEMENTOS]
GO

ALTER TABLE [dbo].[HEROES]  WITH CHECK ADD  CONSTRAINT [FK_HEROES_ELEMENTOS1] FOREIGN KEY([IdDebilidad])
REFERENCES [dbo].[ELEMENTOS] ([Id])
GO

ALTER TABLE [dbo].[HEROES] CHECK CONSTRAINT [FK_HEROES_ELEMENTOS1]
GO

ALTER TABLE [dbo].[HEROES]  WITH CHECK ADD  CONSTRAINT [FK_HEROES_POKEMONS] FOREIGN KEY([IdVentaja])
REFERENCES [dbo].[HEROES] ([Id])
GO

ALTER TABLE [dbo].[HEROES] CHECK CONSTRAINT [FK_HEROES_POKEMONS]
GO

insert into ELEMENTOS values ('Fuerza')
insert into ELEMENTOS values ('Agilidad')
insert into ELEMENTOS values ('Inteligencia')

insert into HEROES values (1, 'Morphling', 'Cambiando sus cualidades para adaptarse a cada situación, Morphling puede ser tan escurridizo como mortal.', 'https://loladictos.com/wp-content/uploads/2022/01/8f0c19c4-morphling-1.jpg', 1, 2, null, 1)
insert into HEROES values (4, 'Silencer', 'Silencer cambia la dinámica de cada batalla cuando fuerza a sus enemigos a ser incapaces de lanzar hechizos.', 'https://lh4.googleusercontent.com/9JBwMOsJTQmk9oBVAomEEohn0JybWwfYH_WKRoEJdYTOdMV6Xaf5rB6pDBIMGdtAHWdCJHXvS5OYa-nPjUAHf9IQzyvJ_Tu8rfpW9am3HzTwh5TU0XUXWsLL2Q346L3MRE2__ADg', 2, 3, null, 1)
insert into HEROES values (11, 'Enigma', 'Temido por su habilidad definitiva, Enigma puede invocar un agujero negro,', 'https://images3.alphacoders.com/773/thumb-1920-773523.jpg', 1, 1, null, 1)
insert into HEROES values (15, 'Axe', 'Uno tras otro, Axe extermina a sus enemigos. Al frente de su equipo, los encierra en la batalla', 'https://i.blogs.es/914b72/portada/1366_2000.jpg', 2, 1, null, 1)

select * from HEROES