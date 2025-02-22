﻿USE [DBTareas]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 30/01/2025 4:58:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 30/01/2025 4:58:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](500) NOT NULL,
	[Prioridad] [nvarchar](20) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaVencimiento] [datetime2](7) NULL,
	[IdEstado] [int] NOT NULL,
	[ArchivoPDF] [varbinary](max) NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Tareas]    Script Date: 30/01/2025 4:58:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Tareas] AS
SELECT 
    E.Id as IdEstado, 
    E.Nombre as NombreEstado, 
    COUNT(T.Id) AS CantidadTareas
FROM 
    Estados E
LEFT JOIN 
    Tareas T ON T.IdEstado = E.Id
GROUP BY 
    E.Id, E.Nombre;
GO
/****** Object:  View [dbo].[V_Estados]    Script Date: 30/01/2025 4:58:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Estados] AS
SELECT 
    T.Id AS IdTarea,
    T.Nombre,
    T.Descripcion,
    T.Prioridad,
    T.FechaCreacion,
    T.FechaActualizacion,
    T.FechaVencimiento,
	E.Id As IdEstado,
    E.Nombre AS Estado
FROM 
    Tareas T
JOIN 
    Estados E ON T.IdEstado = E.Id;
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30/01/2025 4:58:51 a. m. ******/
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
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Estados_IdEstado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Estados_IdEstado]
GO
/****** Object:  Data   Script Date: 30/01/2025 4:58:51 a. m. ******/
INSERT INTO Tareas (Nombre, Descripcion, Prioridad, FechaCreacion, FechaVencimiento, IdEstado) 
VALUES 
('Configurar servidor', 'Instalar y configurar el servidor de producción', 'Alta', GETDATE(), DATEADD(DAY, 10, GETDATE()), (SELECT Id FROM Estados WHERE Nombre = 'To Do')),
('Diseñar base de datos', 'Crear el modelo entidad-relación', 'Media', GETDATE(), DATEADD(DAY, 15, GETDATE()), (SELECT Id FROM Estados WHERE Nombre = 'In Progress')),
('Desarrollar API', 'Implementar los servicios REST', 'Alta', GETDATE(), DATEADD(DAY, 30, GETDATE()), (SELECT Id FROM Estados WHERE Nombre = 'Done'));

