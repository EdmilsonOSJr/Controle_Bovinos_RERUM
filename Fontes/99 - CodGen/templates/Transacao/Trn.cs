// Project  : 
// Type     : TRN
// Creation :
// Description:

using System;
using System.Reflection;
using System.Threading;

using com.rerum.rpo;
using com.rerum.sys;
using com.rerum.types;
using com.rerum.trn;
using com.rerum.utils;

using application.types;
using application.bos;
using application.dom;
using application.evt;

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
using POTransaction = com.rerum.trn.RPOTransaction;
// rerum transaction status 
using RTStatus = System.UInt32;
// tipo de retorno para eventos --- indica proximo estado da transacao
using REState = System.Int32;

#set ($H = '#')
namespace application.trn
{
	//<bucb>User Aliases 
	//<eucb>User Aliases

	/// <summary>
	/// Transacao negocial TRN${name}.
	/// </summary>
	/// <Author>${author}</Author>
	/// <Created>${created}</Created>
	/// <Modified>${modified}</Modified>
#if ($base == "RPOTransaction")
	public class TRN${name} : ${base}
#elseif($base == "RPOSearchTransaction")
	public class TRN${name} : ${base}
#else
	public class TRN${name} : TRN${base}
#end
	//============================================================================================
	{
		//<bucb> TrId : class_id (Tdentificador unico da transacao)
		/// <summary>
		///  TrId : class_id (Tdentificador unico da transacao)
		/// </summary>
		public const int K_TRID_${name} = ${builtin.randint};
		//<eucb>
		
		/// <summary>
		///  TrId : Nome da Transacao -->  RPOTransaction.K_CLID_RPOTransaction + K_TRID_TRN${name}
		/// </summary>
		public const classid_t K_CLID_${name} = RPOTransaction.K_CLID_RPOTransaction + K_TRID_${name};

		${H}region Atributos
#foreach ($a in $attributes)
		/// <summary>
		/// $a.doc
		/// </summary>
#if ($a.rpotype == "TString")
		private ${a.rpotype} $a.field = new ${a.rpotype}("");
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
		
#if ($base == "RPOTransaction")
        public const int K_ST_INICIAL = K_ST_IDLE; // 0
#else
        new public const int K_ST_INICIAL = K_ST_IDLE; // 0
#end		
#set($lastval = 1)
#foreach($state in $states)
#if ($lastval == 1 && $base != "RPOTransaction" && $base != "Base"))
        new public const int K_ST_${state.name.upFirst} = ${lastval};
#else
        public const int K_ST_${state.name.upFirst} = ${lastval};
#end
#set($lastval = $lastval + 1)
#end
#if ($base == "RPOTransaction")
        public const int K_ST_FIM = $lastval;
#else
        new public const int K_ST_FIM = $lastval;
#end

#set($lastval = 0)
#foreach($event in $events)
        public const int K_EV_${event.name.upFirst} = ${lastval};
		public const string K_EV_NAME_${event.name.upFirst} = "Ev${event.name.upFirst}";
#set($lastval = $lastval + 1)
#end
        public const int K_EV_FIM_TRN_${name} = $lastval;
#if ($transitions)
#if ($base == "RPOTransaction")
        // Tabela de transicao de estados
        protected static String K_XML_TransitionTable =
#else
        // Tabela de transicao de estados
        new protected static String K_XML_TransitionTable =
#end		
        "<StateTransitionTable>"
            + "\n<States>"
                + "\n<state name=\"Inicial\"/>"
#foreach($state in $states)
                + "\n<state name=\"${state.name.upFirst}\"/>"
#end
                + "\n<state name=\"Fim\"/>"
            + "\n</States>"
            + "\n<Events>"
#foreach($event in $events)
                + "\n<event name=\"Ev${event.name.upFirst}\"		handler=\"ev${event.name.upFirst}\" />"
#end
                + "\n<event name=\"Finalizar\"   handler=\"finalizar\" />"
            + "\n</Events>"
            + "\n<Transitions>"
                + "\n<error state=\"error\"  meth=\"@erroTransicao\" />"
#foreach($transition in $transitions)
                + "\n<transition state=\"${transition.from}\" event=\"Ev${transition.event.upFirst}\"		nextstate=\"${transition.to}\" />"
#end
            + "\n</Transitions>"
        + "\n</StateTransitionTable>";
#end

		//<bucb> User Defined Constructors
		//<eucb>

		/// <summary>
		///  Construtor de TRN${name}. Normaliza classid, trid  e inicializa classe.
		/// </summary>
		public TRN${name}() 
#if ($callBaseWithFalse && $base != "RPOTransaction")
			: base(false)
#end
		{
			registerTRNInformation(true);
		}

#if ($callBaseWithFalse)
		public TRN${name}(bool regStateMachine) 
#if ($base != "RPOTransaction")
			: base(regStateMachine)
#end
		{
			registerTRNInformation(regStateMachine);
		}
#end

		private void registerTRNInformation(bool regStateMachine) 
		{
			m_classid = K_CLID_${name};
			trid = K_TRID_${name};
			
#if ($transitions)
			if (regStateMachine) 
			{
				registerStateTransitionMachine(K_XML_TransitionTable);
			}
#end
			//<bucb>User Construtor_TRN${name} 
			//<eucb>User Construtor_TRN${name}
		}

		${H}region isValid/begin/end
		/// <summary>
		/// Valida pré-condições para execução da transação 
		/// </summary>
		/// <returns>
		///true- transação pode ser executada    false- transação inválida, não pode ser executada
		/// </returns>
		public override boolean isValid()
		{
			__tracein("isValid()");
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
			__traceout("isValid()");
			return !hasError();
		}

		/// <summary>
		/// Inicio de execução da transação: procedimentos de incializacao
		/// </summary>
		/// <returns>
		/// Código de status da inicialização da transação (getStatus()) <p> Exceção de sistema durante o processamento
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
		/// Fim de execução da transação: procedimentos de encerramento
		/// </summary>
		/// <returns>
		/// Código de status da inicialização da transação (getStatus()) <p> Exceção de sistema durante o processamento
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
		
        /// <summary>
        /// Obtem o evento com base no nome recebido.
        /// </summary>
        /// <typeparam name="T">tipo de retorno do evento.</typeparam>
        /// <param name="pEventName">nome do evento.</param>
        /// <returns>evento recuperado ou nulo caso contrario.</returns>	
#if ($base == "RPOTransaction")
        protected virtual T GetEventByName<T>(string pEventName) where T : RTEvent
        {
            T evt = null;
#else
        protected override T GetEventByName<T>(string pEventName)
        {
            T evt = base.GetEventByName<T>(pEventName);
#end		
            if (evt == null || !string.IsNullOrWhiteSpace(pEventName))
            {
                switch (pEventName)
                {
#foreach($event in $events)
#if (${event.name.upFirst} != "RecuperarLoteOcorrenciaComDependenciasPorIdSRG" && ${event.name.upFirst} != "RecuperarOcorrenciaComDependenciasPorId" && ${event.name.upFirst} != "EnviarLoteOcorrenciaAssociacaoSRG")
                    case K_EV_NAME_${event.name.upFirst}: evt = new Ev${event.name.upFirst}(this, K_EV_NAME_${event.name.upFirst}) as T; break;
#end
#end
					//<bucb> GetEventByName
					//<eucb> GetEventByName
					default: break;
				}
            }
            return evt;
        }
		
		${H}endregion

		${H}region eventos
		
		${H}endregion

		${H}region exec's

#foreach ($e in $events)
#if (${e.name.upFirst} != "ConsultarContratoPorCnpj")
		/// <summary>
		/// $e.doc
		/// </summary>
#if (${e.name.upFirst} == "RecuperarOcorrenciaComDependenciasPorId" || ${e.name.upFirst} == "RecuperarLoteOcorrenciaComDependenciasPorIdSRG" || ${e.name.upFirst} == "EnviarLoteOcorrenciaAssociacaoSRG")
		public status_t Exec${e.name.upFirst}<TOcorrenciaEventoBovinoSRG>() where TOcorrenciaEventoBovinoSRG : OcorrenciaEventoBovinoSRG
		{
			var evt = new Ev${e.name.upFirst}<TOcorrenciaEventoBovinoSRG>(this, K_EV_NAME_${e.name.upFirst});
#else
		public status_t Exec${e.name.upFirst}()
		{
			var evt = GetEventByName<Ev${e.name.upFirst}>(K_EV_NAME_${e.name.upFirst});
#end
			
			//<bucb>Set Exec${e.name.upFirst}
			//<eucb>Set Exec${e.name.upFirst}
			
			setStatus(exec(evt));
			
			//<bucb>Get Exec${e.name.upFirst}
			//<eucb>Get Exec${e.name.upFirst}
			
			return getStatus();
		}

#end
#end
		${H}endregion
		
		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos

		//<bucb>User NegociaisProtegidos
		//<eucb>User NegociaisProtegidos
		
		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados

	}  // End public class TRN${name} : TRN${base}
}   // End namespace application.trn
