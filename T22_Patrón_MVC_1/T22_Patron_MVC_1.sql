USE [T22_Patron_MVC_1]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 01/02/2021 18:03:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NULL,
	[apellido] [varchar](250) NULL,
	[direccion] [varchar](250) NULL,
	[dni] [int] NULL,
	[fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [nombre]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [apellido]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [direccion]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [dni]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (NULL) FOR [fecha]
GO
