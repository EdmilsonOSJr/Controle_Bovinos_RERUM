@echo off
rem Descomente a linha abaixo e configure o caminho da jvm (java)
rem set PATH=C:\jdk1.7.0_05\bin;%PATH%
call amcg --nb --o .\build-matrix.cmd --code-model allmaps.js --template ..\templates\the-architect-of-matrix.cmd
call build-matrix.cmd %*
pause
@echo on