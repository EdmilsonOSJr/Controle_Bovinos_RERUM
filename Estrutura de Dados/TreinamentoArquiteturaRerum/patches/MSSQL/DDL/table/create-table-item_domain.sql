CREATE TABLE item_domain (
	cod_objeto varchar(25) NOT NULL,
	descr varchar(50) NOT NULL,
	code int4 NOT NULL,
	"domain" varchar(25) NOT NULL,
	CONSTRAINT pk_item_domain PRIMARY KEY (cod_objeto)
);


-- item_domain foreign keys
ALTER TABLE item_domain ADD CONSTRAINT fk_item_domain_domain FOREIGN KEY (domain) REFERENCES domain(cod_objeto);