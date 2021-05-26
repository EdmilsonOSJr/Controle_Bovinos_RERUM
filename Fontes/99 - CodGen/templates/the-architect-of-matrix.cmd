echo off
set GENHOME=.\generated
set CSRPO=%GENHOME%\cs_rpo
set CSRPO_TEST=%GENHOME%\cs_rpo_test
set DOMSQL=%GENHOME%\dom_sql
set BOSFACTORY=%GENHOME%\bosfactory
set LIBNAME=${lib}

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
rem eucb: Pre-Gen
#set( $libname = $lib.replace(".", "") )

IF "%1" == "" GOTO BuildAll

rem Indica em qual classe deve parar
set STOP=%1

#foreach ($t in $types)
IF "%1" == "${t.name}" GOTO LBL_${t.name}
#end
#foreach ($t in $trns)
IF "%1" == "trn_${t.name}" GOTO LBL_trn_${t.name}
#end
#foreach ($t in $tads)
IF "%1" == "tad_${t.name}" GOTO LBL_tad_${t.name}
#end
#foreach ($t in $doms)
IF "%1" == "dom_${t.name}" GOTO LBL_dom_${t.name}
#end
#foreach ($t in $evts)
IF "%1" == "evt_${t.name}" GOTO LBL_evt_${t.name}
#end

:BuildAll
echo Transacoes

#foreach ($t in $trns)
#if (!$t.skip)
:LBL_trn_${t.name}

rem Gerando arquivos para ${t.name}
call amcg --nb --o %CSRPO%\\${lib}\application\trn\\TRN${t.name}.cs --code-model .\model\\trn_${t.name}.js --template ..\templates\Transacao\Trn.cs -Drvo_targetLib=${lib}
call amcg --nb --o %CSRPO_TEST%\\${libname}\application\trn\test\\TRN${t.name}Test.cs --code-model .\model\\trn_${t.name}.js --template ..\templates\Transacao\TestTrn.cs -Drvo_targetLib=${lib}

#if (!$t.skipgui)
#end

echo Trn ${lib}/${t.name} // OK

IF "%STOP%" == "trn_${t.name}" GOTO PostGen
#end
#end

echo Events
#foreach ($t in $evts)
#if (!$t.skip)
:LBL_evt_${t.name}

rem Gerando arquivos para ${t.name}
rem Events
call amcg --nb --o %CSRPO%\\${lib}\application\evt\\Ev${t.name}.cs --code-model .\model\\evt_${t.name}.js --template ..\templates\Transacao\Event.cs -Drvo_targetLib=${lib}

#if (!$t.skipgui)
#end

echo Event: ${lib}/Ev${t.name} // OK

IF "%STOP%" == "evt_${t.name}" GOTO PostGen
rem LBL_evt_${transactionName}_${t.name}
#end
#end

echo Objects
#foreach ($t in $types)
#if (!$t.trn && !$t.skip)
:LBL_${t.name}

rem Gerando arquivos para ${t.name}
rem BosCol
call amcg --nb --o %CSRPO%\\${lib}\application\bos\\${t.name}.cs --code-model .\model\\${t.name}.js --template ..\templates\BosCol\Bos.cs -Drvo_targetLib=${lib}

#if (!$t.transient)
call amcg --nb --o %CSRPO%\\${lib}\application\col\\Col${t.name}.cs --code-model .\model\\${t.name}.js --template ..\templates\BosCol\Col.cs -Drvo_targetLib=${lib}
call amcg --nb --o %BOSFACTORY%\\${lib}\\${t.name}.sql --code-model .\model\\${t.name}.js --template ..\templates\BosCol\BosFactory.txt -Drvo_targetLib=${lib}

echo Bos/Col ${lib}/${t.name} // OK
#else
echo Bos ${lib}/${t.name} // OK
#end

#if (!$t.skipgui)
#end

IF "%STOP%" == "${t.name}" GOTO PostGen
rem END LBL_${t.name}
#end
#end

echo TAD
#foreach ($t in $tads)
#if (!$t.skip)
:LBL_tad_${t.name}

rem Gerando arquivos para ${t.name}
rem TAD
call amcg --nb --o %CSRPO%\\${lib}\application\types\\${t.name}.cs --code-model .\model\\tad_${t.name}.js --template ..\templates\Tipos\Types.cs -Drvo_targetLib=${lib}

#if (!$t.skipgui)
#end

echo TAD ${lib}/${t.name} // OK

IF "%STOP%" == "tad_${t.name}" GOTO PostGen
rem END LBL_${t.name}
#end
#end

echo Domain
#foreach ($t in $doms)
#if (!$t.skip)
:LBL_dom_${t.name}

rem Gerando arquivos para ${t.name}
rem Domain
call amcg --nb --o %CSRPO%\\${lib}\application\dom\\${t.name}.cs --code-model .\model\\dom_${t.name}.js --template ..\templates\Domains\Dom.cs -Drvo_targetLib=${lib}

#if (!$t.skipgui)
#end

call amcg --nb --o %DOMSQL%\\${lib}\\${builtin.gen_seqname}_${t.name}.sql --code-model .\model\\dom_${t.name}.js --template ..\templates\Domains\Dom.Sql
echo Domain ${lib}/${t.name} // OK

IF "%STOP%" == "dom_${t.name}" GOTO PostGen
rem END LBL_${t.name}
#end
#end

echo Test Suite

:PostGen
rem bucb: Post-Gen
rem eucb: Post-Gen

:end
echo on