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

namespace application.trn
{
	//<bucb>User Aliases 
	//<eucb>User Aliases

	/// <summary>
	/// Transacao negocial TRNBovino.
	/// </summary>
	/// <Author>Rerum</Author>
	/// <Created>2021-05-26T13:47:08-03:00</Created>
	/// <Modified>2021-05-26T13:53:15-03:00</Modified>
	public class TRNBovino : RPOTransaction
	//============================================================================================
	{
		//<bucb> TrId : class_id (Tdentificador unico da transacao)
		/// <summary>
		///  TrId : class_id (Tdentificador unico da transacao)
		/// </summary>
		public const int K_TRID_Bovino = 1933104379;
		//<eucb>
		
		/// <summary>
		///  TrId : Nome da Transacao -->  RPOTransaction.K_CLID_RPOTransaction + K_TRID_TRNBovino
		/// </summary>
		public const classid_t K_CLID_Bovino = RPOTransaction.K_CLID_RPOTransaction + K_TRID_Bovino;

		#region Atributos
		/// <summary>
		/// NA
		/// </summary>
		private TString brinco = new TString("");
		/// <summary>
		/// NA
		/// </summary>
		private TString nome = new TString("");
		/// <summary>
		/// NA
		/// </summary>
		private RTTList retornoConsulta = new RTTList();
		/// <summary>
		/// NA
		/// </summary>
		private TObjectId idBovino = new TObjectId();
		/// <summary>
		/// NA
		/// </summary>
		private Bovino bovino = new Bovino();
		#endregion

		#region Get/Set Atributos
		public TString getBrinco() 
		{
			//<bucb> getBrinco()
			//<eucb> getBrinco()
			return brinco;
		}

		public void setBrinco(TString value) 
		{
			//<bucb> setBrinco(TString value)
			//<eucb> setBrinco(TString value)
			this.brinco = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TString Brinco 
		{
			get { return getBrinco(); }
			set { setBrinco(value); }
		}
		public TString getNome() 
		{
			//<bucb> getNome()
			//<eucb> getNome()
			return nome;
		}

		public void setNome(TString value) 
		{
			//<bucb> setNome(TString value)
			//<eucb> setNome(TString value)
			this.nome = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TString Nome 
		{
			get { return getNome(); }
			set { setNome(value); }
		}
		public RTTList getRetornoConsulta() 
		{
			//<bucb> getRetornoConsulta()
			//<eucb> getRetornoConsulta()
			return retornoConsulta;
		}

		public void setRetornoConsulta(RTTList value) 
		{
			//<bucb> setRetornoConsulta(RTTList value)
			//<eucb> setRetornoConsulta(RTTList value)
			this.retornoConsulta = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public RTTList RetornoConsulta 
		{
			get { return getRetornoConsulta(); }
			set { setRetornoConsulta(value); }
		}
		public TObjectId getIdBovino() 
		{
			//<bucb> getIdBovino()
			//<eucb> getIdBovino()
			return idBovino;
		}

		public void setIdBovino(TObjectId value) 
		{
			//<bucb> setIdBovino(TObjectId value)
			//<eucb> setIdBovino(TObjectId value)
			this.idBovino = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TObjectId IdBovino 
		{
			get { return getIdBovino(); }
			set { setIdBovino(value); }
		}
		public Bovino getBovino() 
		{
			//<bucb> getBovino()
			//<eucb> getBovino()
			return bovino;
		}

		public void setBovino(Bovino value) 
		{
			//<bucb> setBovino(Bovino value)
			//<eucb> setBovino(Bovino value)
			this.bovino = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public Bovino Bovino 
		{
			get { return getBovino(); }
			set { setBovino(value); }
		}
		#endregion
		
		#region Associacoes
		#endregion

		#region Get/Set Associacoes
		#endregion
		
		#region Agregacoes
		#endregion

		#region Get/Set Agregacoes
		#endregion

		//<bucb>User Consts
		//<eucb>User Consts

		//<bucb>User Atributos 
		//<eucb>User Atributos
		
        public const int K_ST_INICIAL = K_ST_IDLE; // 0
        public const int K_ST_Inicial = 1;
        public const int K_ST_BovinoMantido = 2;
        public const int K_ST_BovinoRecuperado = 3;
        public const int K_ST_BovinosRecuperados = 4;
        public const int K_ST_FIM = 5;

        public const int K_EV_ManterBovino = 0;
		public const string K_EV_NAME_ManterBovino = "EvManterBovino";
        public const int K_EV_RecuperarBovinoPorId = 1;
		public const string K_EV_NAME_RecuperarBovinoPorId = "EvRecuperarBovinoPorId";
        public const int K_EV_ConsultarBovinos = 2;
		public const string K_EV_NAME_ConsultarBovinos = "EvConsultarBovinos";
        public const int K_EV_FIM_TRN_Bovino = 3;
        // Tabela de transicao de estados
        protected static String K_XML_TransitionTable =
        "<StateTransitionTable>"
            + "\n<States>"
                + "\n<state name=\"Inicial\"/>"
                + "\n<state name=\"Inicial\"/>"
                + "\n<state name=\"BovinoMantido\"/>"
                + "\n<state name=\"BovinoRecuperado\"/>"
                + "\n<state name=\"BovinosRecuperados\"/>"
                + "\n<state name=\"Fim\"/>"
            + "\n</States>"
            + "\n<Events>"
                + "\n<event name=\"EvManterBovino\"		handler=\"evManterBovino\" />"
                + "\n<event name=\"EvRecuperarBovinoPorId\"		handler=\"evRecuperarBovinoPorId\" />"
                + "\n<event name=\"EvConsultarBovinos\"		handler=\"evConsultarBovinos\" />"
                + "\n<event name=\"Finalizar\"   handler=\"finalizar\" />"
            + "\n</Events>"
            + "\n<Transitions>"
                + "\n<error state=\"error\"  meth=\"@erroTransicao\" />"
                + "\n<transition state=\"Inicial\" event=\"EvManterBovino\"		nextstate=\"BovinoMantido\" />"
                + "\n<transition state=\"Inicial\" event=\"EvRecuperarBovinoPorId\"		nextstate=\"BovinoRecuperado\" />"
                + "\n<transition state=\"Inicial\" event=\"EvConsultarBovinos\"		nextstate=\"BovinosRecuperados\" />"
            + "\n</Transitions>"
        + "\n</StateTransitionTable>";

		//<bucb> User Defined Constructors
		//<eucb>

		/// <summary>
		///  Construtor de TRNBovino. Normaliza classid, trid  e inicializa classe.
		/// </summary>
		public TRNBovino() 
		{
			registerTRNInformation(true);
		}

		public TRNBovino(bool regStateMachine) 
		{
			registerTRNInformation(regStateMachine);
		}

		private void registerTRNInformation(bool regStateMachine) 
		{
			m_classid = K_CLID_Bovino;
			trid = K_TRID_Bovino;
			
			if (regStateMachine) 
			{
				registerStateTransitionMachine(K_XML_TransitionTable);
			}
			//<bucb>User Construtor_TRNBovino 
			//<eucb>User Construtor_TRNBovino
		}

		#region isValid/begin/end
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
        protected virtual T GetEventByName<T>(string pEventName) where T : RTEvent
        {
            T evt = null;
            if (evt == null || !string.IsNullOrWhiteSpace(pEventName))
            {
                switch (pEventName)
                {
                    case K_EV_NAME_ManterBovino: evt = new EvManterBovino(this, K_EV_NAME_ManterBovino) as T; break;
                    case K_EV_NAME_RecuperarBovinoPorId: evt = new EvRecuperarBovinoPorId(this, K_EV_NAME_RecuperarBovinoPorId) as T; break;
                    case K_EV_NAME_ConsultarBovinos: evt = new EvConsultarBovinos(this, K_EV_NAME_ConsultarBovinos) as T; break;
					//<bucb> GetEventByName
					//<eucb> GetEventByName
					default: break;
				}
            }
            return evt;
        }
		
		#endregion

		#region eventos
		
		#endregion

		#region exec's

		/// <summary>
		/// $e.doc
		/// </summary>
		public status_t ExecManterBovino()
		{
			var evt = GetEventByName<EvManterBovino>(K_EV_NAME_ManterBovino);

            //<bucb>Set ExecManterBovino

            evt.Bovino = this.bovino;

			//<eucb>Set ExecManterBovino
			
			setStatus(exec(evt));
			
			//<bucb>Get ExecManterBovino
			//<eucb>Get ExecManterBovino
			
			return getStatus();
		}

		/// <summary>
		/// $e.doc
		/// </summary>
		public status_t ExecRecuperarBovinoPorId()
		{
			var evt = GetEventByName<EvRecuperarBovinoPorId>(K_EV_NAME_RecuperarBovinoPorId);

            //<bucb>Set ExecRecuperarBovinoPorId
            //<eucb>Set ExecRecuperarBovinoPorId

            evt.Bovino = this.bovino;


			setStatus(exec(evt));
			
			//<bucb>Get ExecRecuperarBovinoPorId
			//<eucb>Get ExecRecuperarBovinoPorId
			
			return getStatus();
		}

		/// <summary>
		/// $e.doc
		/// </summary>
		public status_t ExecConsultarBovinos()
		{
			var evt = GetEventByName<EvConsultarBovinos>(K_EV_NAME_ConsultarBovinos);

            //<bucb>Set ExecConsultarBovinos
            //<eucb>Set ExecConsultarBovinos

            
            evt.Brinco= this.brinco;
            evt.Nome= this.nome;

            setStatus(exec(evt));

            this.retornoConsulta = evt.RetornoConsulta;
			//<bucb>Get ExecConsultarBovinos
			//<eucb>Get ExecConsultarBovinos
			
			return getStatus();
		}

		#endregion
		
		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos

		//<bucb>User NegociaisProtegidos
		//<eucb>User NegociaisProtegidos
		
		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados

	}  // End public class TRNBovino : TRNRPOTransaction
}   // End namespace application.trn
