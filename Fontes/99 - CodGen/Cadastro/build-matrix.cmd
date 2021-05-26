echo off
set GENHOME=.\generated
set CSRPO=%GENHOME%\cs_rpo
set CSRPO_TEST=%GENHOME%\cs_rpo_test
set DOMSQL=%GENHOME%\dom_sql
set BOSFACTORY=%GENHOME%\bosfactory
set LIBNAME=Cadastro

del /s/q %CSRPO%
del /s/q %CSRPO_TEST%
del /s/q %DOMSQL%
del /s/q %BOSFACTORY%

rd /s/q %CSRPO%
rd /s/q %CSRPO_TEST%
rd /s/q %DOMSQL%
rd /s/q %BOSFACTORY%

mkdir %CSRPO%
mkdir %CSRPO_TEST%
mkdir %DOMSQL%
mkdir %BOSFACTORY%

rem Insira abaixo as rotinas para copiar os arquivos antes da geracao
rem Voce pode usar as variaveis GWTMODEL, GWTUI, CSRPO, CSCONV para obter
rem a localizacao das pastas de destino onde seram criados os arquivos
rem bucb: Pre-Gen
set SRCROOT=..\..
set PastaLibs="%SRCROOT%\01 - Negocios\%LIBNAME%"
set PastaTests="%SRCROOT%\49 - Testes\Controle.Testes"

echo xcopy /s/y %PastaLibs% to %CSRPO%\%LIBNAME%\
mkdir %CSRPO%\%LIBNAME%\
xcopy /s/y/i %PastaLibs%\*.cs %CSRPO%\%LIBNAME%\

echo xcopy /s/q %PastaTests% to %CSRPO_TEST%
xcopy /s/y/i %PastaTests%\*.cs %CSRPO_TEST%\

IF "%1" == "PostGen" GOTO PostGen
rem eucb: Pre-Gen

IF "%1" == "" GOTO BuildAll

rem Indica em qual classe deve parar
set STOP=%1

IF "%1" == "Bovino" GOTO LBL_Bovino
IF "%1" == "trn_Bovino" GOTO LBL_trn_Bovino
IF "%1" == "evt_ConsultarBovinos" GOTO LBL_evt_ConsultarBovinos
IF "%1" == "evt_ManterBovino" GOTO LBL_evt_ManterBovino
IF "%1" == "evt_RecuperarBovinoPorId" GOTO LBL_evt_RecuperarBovinoPorId

:BuildAll
echo Transacoes

:LBL_trn_Bovino

rem Gerando arquivos para Bovino
call amcg --nb --o %CSRPO%\Cadastro\application\trn\\TRNBovino.cs --code-model .\model\\trn_Bovino.js --template ..\templates\Transacao\Trn.cs -Drvo_targetLib=Cadastro
call amcg --nb --o %CSRPO_TEST%\Cadastro\application\trn\test\\TRNBovinoTest.cs --code-model .\model\\trn_Bovino.js --template ..\templates\Transacao\TestTrn.cs -Drvo_targetLib=Cadastro


echo Trn Cadastro/Bovino // OK

IF "%STOP%" == "trn_Bovino" GOTO PostGen

echo Events
:LBL_evt_ConsultarBovinos

rem Gerando arquivos para ConsultarBovinos
rem Events
call amcg --nb --o %CSRPO%\Cadastro\application\evt\\EvConsultarBovinos.cs --code-model .\model\\evt_ConsultarBovinos.js --template ..\templates\Transacao\Event.cs -Drvo_targetLib=Cadastro


echo Event: Cadastro/EvConsultarBovinos // OK

IF "%STOP%" == "evt_ConsultarBovinos" GOTO PostGen
rem LBL_evt_${transactionName}_ConsultarBovinos
:LBL_evt_ManterBovino

rem Gerando arquivos para ManterBovino
rem Events
call amcg --nb --o %CSRPO%\Cadastro\application\evt\\EvManterBovino.cs --code-model .\model\\evt_ManterBovino.js --template ..\templates\Transacao\Event.cs -Drvo_targetLib=Cadastro


echo Event: Cadastro/EvManterBovino // OK

IF "%STOP%" == "evt_ManterBovino" GOTO PostGen
rem LBL_evt_${transactionName}_ManterBovino
:LBL_evt_RecuperarBovinoPorId

rem Gerando arquivos para RecuperarBovinoPorId
rem Events
call amcg --nb --o %CSRPO%\Cadastro\application\evt\\EvRecuperarBovinoPorId.cs --code-model .\model\\evt_RecuperarBovinoPorId.js --template ..\templates\Transacao\Event.cs -Drvo_targetLib=Cadastro


echo Event: Cadastro/EvRecuperarBovinoPorId // OK

IF "%STOP%" == "evt_RecuperarBovinoPorId" GOTO PostGen
rem LBL_evt_${transactionName}_RecuperarBovinoPorId

echo Objects
:LBL_Bovino

rem Gerando arquivos para Bovino
rem BosCol
call amcg --nb --o %CSRPO%\Cadastro\application\bos\Bovino.cs --code-model .\model\Bovino.js --template ..\templates\BosCol\Bos.cs -Drvo_targetLib=Cadastro

call amcg --nb --o %CSRPO%\Cadastro\application\col\\ColBovino.cs --code-model .\model\Bovino.js --template ..\templates\BosCol\Col.cs -Drvo_targetLib=Cadastro
call amcg --nb --o %BOSFACTORY%\Cadastro\Bovino.sql --code-model .\model\Bovino.js --template ..\templates\BosCol\BosFactory.txt -Drvo_targetLib=Cadastro

echo Bos/Col Cadastro/Bovino // OK


IF "%STOP%" == "Bovino" GOTO PostGen
rem END LBL_Bovino

echo TAD

echo Domain

echo Test Suite

:PostGen
rem bucb: Post-Gen
echo xcopy /s/y %CSRPO%\%LIBNAME% to %PastaLibs%\
xcopy /s/y %CSRPO%\%LIBNAME% %PastaLibs%\

echo xcopy /s/q %CSRPO_TEST% to %PastaTests%\
xcopy /s/y %CSRPO_TEST% %PastaTests%\
rem eucb: Post-Gen

:end
echo on
