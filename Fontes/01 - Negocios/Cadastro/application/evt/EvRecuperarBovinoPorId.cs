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

namespace application.evt
{
	//<bucb>User Aliases 
	//<eucb>User Aliases

	/// <summary>
	/// Evento negocial EvRecuperarBovinoPorId.
	/// </summary>
    /// <Author>Rerum</Author>
    /// <Created>2021-05-26T12:30:56-03:00</Created>
    /// <Modified>2021-05-26T13:45:27-03:00</Modified>
	public class EvRecuperarBovinoPorId : RTEvent
	//============================================================================================
	{
		#region Atributos
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
		
		//<bucb>User Defined Constructors
		//<eucb>User Defined Constructors

		/// <summary>
		/// Construtor de EvRecuperarBovinoPorId. 
		/// </summary>
		public EvRecuperarBovinoPorId(TRNBovino pTransaction, string pEventName) 
			: base(pTransaction, pEventName)
		{
			//<bucb>User Construtor_EvRecuperarBovinoPorId 
			//<eucb>User Construtor_EvRecuperarBovinoPorId
		}		

		#region isValid/begin/end/process
		/// <summary>
		/// Valida pr??-condi????es para execu????o da evento. 
		/// </summary>
		/// <returns>
		/// true - evento pode ser executado, false - evento inv??lido, n??o pode ser executada.
		/// </returns>
		public override bool isValid()
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
		/// Inicio de execu????o da evento: procedimentos de incializacao
		/// </summary>
		/// <returns>
		/// C??digo de status da inicializa????o da evento (getStatus()) <p> Exce????o de sistema durante o processamento
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
		/// Fim de execu????o da evento: procedimentos de encerramento
		/// </summary>
		/// <returns>
		/// C??digo de status da inicializa????o da evento (getStatus()) <p> Exce????o de sistema durante o processamento
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
		
		#endregion

		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos
		
		//<bucb>User NegociaisProtegidos
		//<eucb>User NegociaisProtegidos

		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados

	}  // End public class EvRecuperarBovinoPorId : EvRTEvent
}   // End namespace application.evt
