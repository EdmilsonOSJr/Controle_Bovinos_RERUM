echo off
set GENHOME=.\generated
set CSRPO=%GENHOME%\cs_rpo
set CSRPO_TEST=%GENHOME%\cs_rpo_test
set DOMSQL=%GENHOME%\dom_sql
set BOSFACTORY=%GENHOME%\bosfactory
set LIBNAME= <Nome do Projeto No Visual Studio>
set LIBNAME_TEST= <Nome do Projeto de Testes No Visual Studio>

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
set PastaTests="%SRCROOT%\49 - Testes\%LIBNAME_TEST%"

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

:BuildAll
echo Transacoes

echo Events

echo Objects

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