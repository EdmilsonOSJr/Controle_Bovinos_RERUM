CREATE TABLE [dbo].[Domain](
	[cod_objeto] [varchar](25) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Domain] PRIMARY KEY NONCLUSTERED 
(
	[cod_objeto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO