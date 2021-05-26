CREATE TABLE transactionclass (
	cod_objeto varchar(36) NOT NULL,
	id int4 NOT NULL,
	nome varchar(100) NOT NULL,
	tngroup int4 NULL,
	tnflags int4 NULL,
	eventset1 int4 NULL,
	eventset2 int4 NULL,
	"name" varchar(36) NULL,
	descr varchar(36) NULL,
	tnprocedure varchar(36) NULL,
	tnvars varchar(36) NULL,
	tnclassid int4 NULL,
	CONSTRAINT pk_transactionclass PRIMARY KEY (cod_objeto)
);