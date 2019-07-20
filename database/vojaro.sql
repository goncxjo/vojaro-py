USE [master]
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE NAME='vojaro' and xtype='U')
	CREATE DATABASE [vojaro]
GO

USE [vojaro]
GO

CREATE TABLE [dbo].[Universidad](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Codigo] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[FechaCarga] [date] NOT NULL,
	[FechaModificacion] [date] NULL,
	[ModificadoPor] [bigint] NULL,
	[Version] [int] NOT NULL DEFAULT 0
)
GO

CREATE TABLE [dbo].[SedeUniversidad](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniversidadID] [bigint] FOREIGN KEY REFERENCES Universidad(ID),
	[Nombre] [nvarchar](255) NOT NULL,
    [Dirección] [nvarchar](255),
    [Ciudad] [nvarchar](255),
    [Pais] [nvarchar](255),
    [Telefono_1] [nvarchar](255),
    [Telefono_2] [nvarchar](255)
)
GO

CREATE TABLE [dbo].[DepartamentoUniversidad](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniversidadID] [bigint] FOREIGN KEY REFERENCES Universidad(ID),
	[Nombre] [nvarchar](255) NOT NULL
)
GO

CREATE TABLE [dbo].[TipoCarrera](
	[ID] [tinyint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] [nvarchar](255) NOT NULL
)
GO

CREATE TABLE [dbo].[Carrera](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[TipoCarreraID] [tinyint] FOREIGN KEY REFERENCES TipoCarrera(ID),
	[DepartamentoUniversidadID] [bigint] FOREIGN KEY REFERENCES DepartamentoUniversidad(ID),
	[UniversidadID] [bigint] FOREIGN KEY REFERENCES Universidad(ID),
	[Nombre] [nvarchar](255) NOT NULL,
	[Duracion] [tinyint] NOT NULL DEFAULT 1,
	[FechaCarga] [date] NOT NULL,
	[FechaModificacion] [date] NULL,
	[ModificadoPor] [bigint] NULL,
	[Version] [int] NOT NULL DEFAULT 0
)
GO

CREATE TABLE [dbo].[CarreraOrientacion](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[CarreraID] [bigint] FOREIGN KEY REFERENCES Carrera(ID),
	[Nombre] [nvarchar](255) NOT NULL,
	[FechaCarga] [date] NOT NULL,
	[FechaModificacion] [date] NULL,
	[ModificadoPor] [bigint] NULL,
	[Version] [int] NOT NULL DEFAULT 0
)
GO

CREATE TABLE [dbo].[Asignatura](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UniversidadID] [bigint] FOREIGN KEY REFERENCES Universidad(ID),
	[CarreraID] [bigint] FOREIGN KEY REFERENCES Carrera(ID),
	[Nombre] [nvarchar](255) NOT NULL,
	[Cuatrimestre] [int] NOT NULL DEFAULT 0,
	[CargaHoraria] [tinyint] NOT NULL DEFAULT 0,
	[EsAsignaturaComun] [bit] NOT NULL DEFAULT 0,
	[Codigo] [nvarchar](10) NULL,
	[FechaCarga] [date] NOT NULL,
	[FechaModificacion] [date] NULL,
	[ModificadoPor] [bigint] NULL,
	[Version] [int] NOT NULL DEFAULT 0
)
GO

CREATE TABLE [dbo].[AsignaturaCorrelativa](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[AsignaturaID] [bigint] FOREIGN KEY REFERENCES Asignatura(ID),
	[CorrelativaID] [bigint] FOREIGN KEY REFERENCES Asignatura(ID),
	[Regularizada] [bit] NOT NULL DEFAULT 0,
	[Aprobada] [bit] NOT NULL DEFAULT 0
)
GO

CREATE TABLE [dbo].[Alumno](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Edad] [int] NOT NULL DEFAULT 0,
    [Dirección] [nvarchar](255),
    [Ciudad] [nvarchar](255),
    [Pais] [nvarchar](255),
    [Telefono_1] [nvarchar](255),
    [Telefono_2] [nvarchar](255),
	[FechaCarga] [date] NOT NULL,
	[FechaModificacion] [date] NULL,
	[ModificadoPor] [bigint] NULL,
	[Version] [int] NOT NULL DEFAULT 0
)
GO

CREATE TABLE [dbo].[AlumnoAsignatura](
	[ID] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[AlumnoID] [bigint] FOREIGN KEY REFERENCES Alumno(ID),
	[CarreraID] [bigint] FOREIGN KEY REFERENCES Carrera(ID),
	[EstadoAsignatura] [nvarchar](100) NOT NULL,
	[FechaCarga] [date] NOT NULL,
	[FechaModificacion] [date] NULL,
	[ModificadoPor] [bigint] NULL,
	[Version] [int] NOT NULL DEFAULT 0
)
GO
