// Project  : 
// Type     : BOS
// Creation :
// Description:
#region imports
using System;

using com.rerum.rpo;
using com.rerum.sys;
using com.rerum.types;

using application.types;
using application.dom;

//<bucb>User Imports
//<eucb>User Imports

using String        = System.String;
using boolean       = System.Boolean;  
using Object        = System.Object;
using status_t      = System.UInt32;
using classid_t     = System.UInt32;
using TStatus       = System.UInt32;
using RTStatus      = System.UInt32;
using RJStatus      = System.UInt32;
using RJPOObject    = com.rerum.rpo.RPOObject;
using TCodigoObjeto = com.rerum.types.TObjectId;
using RJTTList      = com.rerum.rpo.RTTList;
#endregion
namespace application.bos
{
	/// <summary>
	///  Objeto negocial Bovino
	/// </summary>
	/// <Author>Rerum</Author>
	/// <Created>2021-05-26T10:53:44-03:00</Created>
	/// <Modified>2021-05-26T11:55:11-03:00</Modified>
	//<bucb>User Attributes
	//<eucb>User Attributes
	public class Bovino : RPOObject
	{
		/// <summary>
		/// ClassId : identificador unico da classe 
		/// </summary>
		//<bucb>ClassId
		public const int K_CLID_Bovino = 0;
		//<eucb>ClassId

		#region Atributos
		/// <summary>
		/// NA
		/// </summary>
		protected TString brinco = new TString();
		/// <summary>
		/// NA
		/// </summary>
		protected TString nome = new TString();
		/// <summary>
		/// NA
		/// </summary>
		protected TString situacao = new TString();
		/// <summary>
		/// NA
		/// </summary>
		protected TString sexo = new TString();
		/// <summary>
		/// NA
		/// </summary>
		protected TString brincoMae = new TString();
		/// <summary>
		/// NA
		/// </summary>
		protected TString brincoPai = new TString();
		/// <summary>
		/// NA
		/// </summary>
		protected TString raca = new TString();
		/// <summary>
		/// NA
		/// </summary>
		protected TDate dataNascimento = new TDate();
		/// <summary>
		/// NA
		/// </summary>
		protected TDate dataPrenches = new TDate();
		/// <summary>
		/// NA
		/// </summary>
		protected TDate dataUltimoParto = new TDate();
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
		public TString getSituacao()
		{
			//<bucb> getSituacao()
			//<eucb> getSituacao()
			return situacao;
		}

		public void setSituacao(TString value)
		{
			//<bucb> setSituacao(TString value)
			//<eucb> setSituacao(TString value)
			this.situacao = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TString Situacao
		{
			get { return getSituacao(); }
			set { setSituacao(value); }
		}
		public TString getSexo()
		{
			//<bucb> getSexo()
			//<eucb> getSexo()
			return sexo;
		}

		public void setSexo(TString value)
		{
			//<bucb> setSexo(TString value)
			//<eucb> setSexo(TString value)
			this.sexo = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TString Sexo
		{
			get { return getSexo(); }
			set { setSexo(value); }
		}
		public TString getBrincoMae()
		{
			//<bucb> getBrincoMae()
			//<eucb> getBrincoMae()
			return brincoMae;
		}

		public void setBrincoMae(TString value)
		{
			//<bucb> setBrincoMae(TString value)
			//<eucb> setBrincoMae(TString value)
			this.brincoMae = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TString BrincoMae
		{
			get { return getBrincoMae(); }
			set { setBrincoMae(value); }
		}
		public TString getBrincoPai()
		{
			//<bucb> getBrincoPai()
			//<eucb> getBrincoPai()
			return brincoPai;
		}

		public void setBrincoPai(TString value)
		{
			//<bucb> setBrincoPai(TString value)
			//<eucb> setBrincoPai(TString value)
			this.brincoPai = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TString BrincoPai
		{
			get { return getBrincoPai(); }
			set { setBrincoPai(value); }
		}
		public TString getRaca()
		{
			//<bucb> getRaca()
			//<eucb> getRaca()
			return raca;
		}

		public void setRaca(TString value)
		{
			//<bucb> setRaca(TString value)
			//<eucb> setRaca(TString value)
			this.raca = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TString Raca
		{
			get { return getRaca(); }
			set { setRaca(value); }
		}
		public TDate getDataNascimento()
		{
			//<bucb> getDataNascimento()
			//<eucb> getDataNascimento()
			return dataNascimento;
		}

		public void setDataNascimento(TDate value)
		{
			//<bucb> setDataNascimento(TDate value)
			//<eucb> setDataNascimento(TDate value)
			this.dataNascimento = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TDate DataNascimento
		{
			get { return getDataNascimento(); }
			set { setDataNascimento(value); }
		}
		public TDate getDataPrenches()
		{
			//<bucb> getDataPrenches()
			//<eucb> getDataPrenches()
			return dataPrenches;
		}

		public void setDataPrenches(TDate value)
		{
			//<bucb> setDataPrenches(TDate value)
			//<eucb> setDataPrenches(TDate value)
			this.dataPrenches = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TDate DataPrenches
		{
			get { return getDataPrenches(); }
			set { setDataPrenches(value); }
		}
		public TDate getDataUltimoParto()
		{
			//<bucb> getDataUltimoParto()
			//<eucb> getDataUltimoParto()
			return dataUltimoParto;
		}

		public void setDataUltimoParto(TDate value)
		{
			//<bucb> setDataUltimoParto(TDate value)
			//<eucb> setDataUltimoParto(TDate value)
			this.dataUltimoParto = value;
		}

		/// <summary>
		/// NA
		/// </summary>
		public TDate DataUltimoParto
		{
			get { return getDataUltimoParto(); }
			set { setDataUltimoParto(value); }
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
		
		//<bucb> User Defined Constructors
		//<eucb> User Defined Constructors

		/// <summary>
		/// Construtor de Bovino(). Normaliza classid e inicializa classe.
		/// </summary>
		public Bovino()
		//--------------------------------------------------------------------------------------------
		{
			m_classid = K_CLID_Bovino;

			//<bucb>User ConstrutorBovino
			//<eucb>User ConstrutorBovino
		}
		
        public override boolean isValid()
        {
            var baseOk = base.isValid();
			var localOk = true;
			//<bucb> isValid()
			//<eucb> isValid()
			return baseOk && localOk;
        }

		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos

		//<bucb>User NegociaisProtegidos
		//<eucb>User NegociaisProtegidos
		
		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados
		
		#region Rec Agregacoes
		#endregion

	} // End public class Bovino : RPOObject

} // End namespace application.bos