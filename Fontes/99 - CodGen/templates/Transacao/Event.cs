// Project  : 
// Type     : Event
// Creation :
// Description:

using System;
using System.Reflection;
using System.Threading;

using com.rerum.rpo;
using com.rerum.sys;
using com.rerum.types;
using com.rerum.utils;

using application.types;
using application.bos;
using application.dom;
using application.trn;
using application.sys;

//<bucb>User Imports
//<eucb>User Imports

using String = System.String;
using boolean = System.Boolean;
using Object = System.Object;
using status_t = System.UInt32;
using classid_t = System.UInt32;
using TStatus = System.UInt32;
using RJStatus = System.UInt32;
using state_t = System.Int32;

// rerum transaction status 
using RTStatus = System.UInt32;
// tipo de retorno para eventos --- indica proximo estado da transacao
using REState = System.Int32;

#set ($H = '#')
namespace application.evt
{
	//<bucb>User Aliases 
	//<eucb>User Aliases

	/// <summary>
	/// Evento negocial Ev${name}.
	/// </summary>
    /// <Author>${author}</Author>
    /// <Created>${created}</Created>
    /// <Modified>${modified}</Modified>
#if ($base == "RTEvent")
	public class Ev${name} : ${base}
#elseif ($name == "RecuperarLoteOcorrenciaComDependenciasPorIdSRG" || $name == "RecuperarOcorrenciaComDependenciasPorId" || $name == "EnviarLoteOcorrenciaAssociacaoSRG")
	public class Ev${name}<TOcorrenciaEventoBovinoSRG> : Ev${base} where TOcorrenciaEventoBovinoSRG : OcorrenciaEventoBovinoSRG
#else
	public class Ev${name} : Ev${base}
#end
	//============================================================================================
	{
		${H}region Atributos
#foreach ($a in $attributes)
		/// <summary>
		/// $a.doc
		/// </summary>
#if ($a.rpotype == "TString")
		private ${a.rpotype} $a.field = new ${a.rpotype}("");
#elseif ($a.rpotype == "TOcorrenciaEventoBovinoSRG")
		private ${a.rpotype} $a.field = default(TOcorrenciaEventoBovinoSRG);
#else
		private ${a.rpotype} $a.field = new ${a.rpotype}();
#end
#end
		${H}endregion

		${H}region Get/Set Atributos
#foreach ($a in $attributes)
#set ($atype = $a.rpotype)
		public $atype get${a.field.upFirst}() 
		{
			//<bucb> get${a.field.upFirst}()
			//<eucb> get${a.field.upFirst}()
			return $a.field;
		}

		public void set${a.field.upFirst}($atype value) 
		{
			//<bucb> set${a.field.upFirst}($atype value)
			//<eucb> set${a.field.upFirst}($atype value)
			this.$a.field = value;
		}

		/// <summary>
		/// $a.doc
		/// </summary>
		public $atype $a.field.upFirst 
		{
			get { return get${a.field.upFirst}(); }
			set { set${a.field.upFirst}(value); }
		}
#end
		${H}endregion
		
		${H}region Associacoes
#foreach ($a in $associations)
		/// <summary>
		/// $a.doc
		/// </summary>
		private ${a.rpotype} $a.field = new ${a.rpotype}();
#end
		${H}endregion

		${H}region Get/Set Associacoes
#foreach ($a in $associations)
#set ($atype = $a.rpotype)
		public $atype get${a.field.upFirst}() 
		{
			//<bucb> get${a.field.upFirst}()
			//<eucb> get${a.field.upFirst}()
			return $a.field;
		}

		public void set${a.field.upFirst}($atype value) 
		{
			//<bucb> set${a.field.upFirst}($atype value)
			//<eucb> set${a.field.upFirst}($atype value)
			this.$a.field = value;
		}

		/// <summary>
		/// $a.doc
		/// </summary>
		public $atype $a.field.upFirst 
		{
			get { return get${a.field.upFirst}(); }
			set { set${a.field.upFirst}(value); }
		}
#end
		${H}endregion
		
		${H}region Agregacoes
#foreach ($a in $aggregations)
		/// <summary>
		/// $a.doc
		/// Tipo dos elementos: $a.rpotype
		/// </summary>
		private RTTList $a.field = new RTTList();
#end
		${H}endregion

		${H}region Get/Set Agregacoes
#foreach ($a in $aggregations)
		public RTTList get${a.field.upFirst}() 
		{
			//<bucb> get${a.field.upFirst}()
			//<eucb> get${a.field.upFirst}()
			return $a.field;
		}

		public void set${a.field.upFirst}(RTTList value) 
		{
			//<bucb> set${a.field.upFirst}(RTTList value)
			//<eucb> set${a.field.upFirst}(RTTList value)
			this.$a.field = value;
		}

		/// <summary>
		/// $a.doc
		/// </summary>
		public RTTList $a.field.upFirst 
		{
			get { return get${a.field.upFirst}(); }
			set { set${a.field.upFirst}(value); }
		}
#end
		${H}endregion

		//<bucb>User Consts
		//<eucb>User Consts

		//<bucb>User Atributos 
		//<eucb>User Atributos
		
		//<bucb>User Defined Constructors
		//<eucb>User Defined Constructors

		/// <summary>
		/// Construtor de Ev${name}. 
		/// </summary>
		public Ev${name}(${transactionName} pTransaction, string pEventName) 
			: base(pTransaction, pEventName)
		{
			//<bucb>User Construtor_Ev${name} 
			//<eucb>User Construtor_Ev${name}
		}		

		${H}region isValid/begin/end/process
		/// <summary>
		/// Valida pré-condições para execução da evento. 
		/// </summary>
		/// <returns>
		/// true - evento pode ser executado, false - evento inválido, não pode ser executada.
		/// </returns>
		public override bool isValid()
		{
			__tracein("isValid()");
#if ($name != "ManterContratoBeneficiario")
			// Chama validacao do pai
			if (base.isValid()) 
			{
				//<bucb>User isValid
				//<eucb>User isValid
			}
			else 
			{
				//<bucb>User else_isValid
				//<eucb>User else_isValid
			}
#else			
			//<bucb>User isValid
			//<eucb>User isValid
#end
			__traceout("isValid()");
			return !hasError();
		}

		/// <summary>
		/// Inicio de execução da evento: procedimentos de incializacao
		/// </summary>
		/// <returns>
		/// Código de status da inicialização da evento (getStatus()) <p> Exceção de sistema durante o processamento
		/// </returns>
		public override status_t begin()
		//------------------------------------------------------------------------------
		{
			__tracein("begin()");
			base.begin(); // Chama inicializacao do pai
			__traceout("begin()");

			//<bucb>User begin
			//<eucb>User begin

			return getStatus();
		}

		/// <summary>
		/// Fim de execução da evento: procedimentos de encerramento
		/// </summary>
		/// <returns>
		/// Código de status da inicialização da evento (getStatus()) <p> Exceção de sistema durante o processamento
		/// </returns>
		public override status_t end()
		//------------------------------------------------------------------------------
		{
			__tracein("end()");
			base.end(); // Chama encerramento do pai
			__traceout("end()");
			
			//<bucb>User end 
			//<eucb>User end

			return getStatus();
		}
		
        public override status_t process()
        {
            __tracein("process()");
            //<bucb>User process 
            try
            {
                startTransaction();

            }
            catch (LogicaNegocioException ex)
            {
                setStatus(ex.ErrorCode, ex);
                __trace(ex);
            }
            catch (Exception ex)
            {
                setStatus(RStatus.ERROR);
                __trace(ex);
            }
            finally
            {
                endTransaction();
            }
            //<eucb>User process
			__traceout("process()");
            return getStatus();
        }
		
		${H}endregion

		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos
		
		//<bucb>User NegociaisProtegidos
		//<eucb>User NegociaisProtegidos

		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados

	}  // End public class Ev${name} : Ev${base}
}   // End namespace application.evt
