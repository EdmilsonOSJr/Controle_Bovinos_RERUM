CREATE TABLE updatetracking
(
 cod_objeto character varying(36) NOT NULL,
 domainid character varying(36),
 dt_ocorrencia timestamp without time zone,
 transactioncontext character varying(36),
 updatedobjectid character varying(36),
 updatedobjecttype character varying(200),
 userid character varying(36),
 CONSTRAINT pk_updatetracking PRIMARY KEY (cod_objeto)
);

CREATE TABLE updatetrackingdetail
(
 cod_objeto character varying(36) NOT NULL,
 newvaleu text,
 oldvalue text NOT NULL,
 propertyname character varying(200),
 propertytypename character varying(200),
 parentid character varying(36) NOT NULL,
 CONSTRAINT pk_updatetrackingdetail PRIMARY KEY (cod_objeto),
 CONSTRAINT fk_updatetrackingdetail_identificacao FOREIGN KEY (parentid)
 REFERENCES updatetracking (cod_objeto) MATCH SIMPLE
 ON UPDATE NO ACTION
 ON DELETE NO ACTION
);