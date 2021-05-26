DECLARE @IdDomain AS VARCHAR(36)
EXEC fn_create_domain @domain='${name}'
SET @IdDomain = (SELECT cod_objeto FROM domain WHERE  NAME = '${name}')

#foreach($item in $item_domain)
EXEC fn_create_item_domain @domainName='${name}', @itemCode=${item.id}, @itemName='${item.name}'
INSERT INTO i18n_traducao(cod_objeto, indicadorplural, locale, textotraducao, chavetraducao)
VALUES      (Lower(Replace(Newid(), '-', '')), '-1', 'pt-BR', '${item.name}', @IdDomain + '_${item.id}')

#end
