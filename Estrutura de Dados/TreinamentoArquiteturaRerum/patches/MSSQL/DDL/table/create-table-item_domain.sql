CREATE TABLE [dbo].[Item_Domain](
	[cod_objeto] [varchar](25) NOT NULL,
	[descr] [varchar](50) NOT NULL,
	[code] [int] NOT NULL,
	[domain] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Item_Domain] PRIMARY KEY NONCLUSTERED 
(
	[cod_objeto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO;

ALTER TABLE [dbo].[Item_Domain]  WITH CHECK ADD  CONSTRAINT [FK_Item_Domain_Domain] FOREIGN KEY([domain])
REFERENCES [dbo].[Domain] ([cod_objeto])
GO;