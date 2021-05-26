CREATE TABLE [dbo].[transactionclass] (
	[cod_objeto] [varchar](36) NOT NULL,
	[id] [int] NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[tngroup] [int] NULL,
	[tnflags] [int] NULL,
	[eventset1] [int] NULL,
	[eventset2] [int] NULL,
	["name"] [varchar](36) NULL,
	[descr] [varchar](36) NULL,
	[tnprocedure] [varchar](36) NULL,
	[tnvars] [varchar](36) NULL,
	[tnclassid] [int] NULL,
	CONSTRAINT [pk_transactionclass] PRIMARY KEY (cod_objeto)
);