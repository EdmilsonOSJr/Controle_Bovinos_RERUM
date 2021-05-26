@echo off
rem ----------------------------------------------------------------------
rem -- TreinamentoArquiteturaRerum.bat : script para execucao de comandos do liquibase
rem -- author	     : Marcelo Nepomuceno
rem -- date		     : 2020-06-30
rem -- build by      : Rerum Engenharia de Sistemas
rem ----------------------------------------------------------------------

set LB_HOME=%~dp0

pushd %LB_HOME%
cd ../../Liquibase/

echo Acionando os scrips do Treinamento....
call liquibase.bat --defaultsFile=../TreinamentoArquiteturaRerum/batches/%1/TreinamentoArquiteturaRerum.properties --changeLogFile=../TreinamentoArquiteturaRerum/batches/TreinamentoArquiteturaRerum.xml %2 -Dpatches.home=../TreinamentoArquiteturaRerum/patches
popd