USE [persona]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 21-11-2019 1:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[codigo] [int] NOT NULL,
	[nombre] [nchar](200) NOT NULL,
	[apellido_paterno] [nchar](200) NOT NULL,
	[apellido_materno] [nchar](200) NOT NULL,
	[sexo] [nchar](200) NOT NULL
) ON [PRIMARY]
GO
