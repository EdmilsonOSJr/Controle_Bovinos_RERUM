// Project  : 
// Type     : COL
// Creation :
// Description:
using System;
#region imports
using com.rerum.rpo;
using com.rerum.db;
using com.rerum.sys;
using com.rerum.types;
using application.bos;
using application.types;
using application.dom;

//<bucb>User Imports
//<eucb>User Imports

using String          = System.String;
using boolean         = System.Boolean;  
using Object          = System.Object;
using status_t        = System.UInt32;
using classid_t       = System.UInt32;
using TStatus         = System.UInt32;
using RTStatus        = System.UInt32;
using RJStatus        = System.UInt32;
using RJPOObject      = com.rerum.rpo.RPOObject;
using ColRJPOObject   = com.rerum.rpo.RPOColObject;
using TCodigoObjeto   = com.rerum.types.TObjectId;
using ColRPOObject    = com.rerum.rpo.RPOColObject;
#endregion imports

namespace application.col
{ 
	/// <summary>
	/// Objeto negocial Bovino
	/// </summary>
	/// <Author>Rerum</Author>
	/// <Created>2021-05-26T10:53:44-03:00</Created>
	/// <Modified>2021-05-26T11:55:11-03:00</Modified>
	public class ColBovino : ColRPOObject
    {
        /// <summary>
        /// Table Name    -->   "bovino";
        /// </summary>
        internal const String K_TBL_Bovino = "bovino";

		/// <summary>
        /// Mapeamento do atributo Brinco para coluna brinco
        /// </summary>
        internal const String K_COL_Brinco = "brinco";
		/// <summary>
        /// Mapeamento do atributo Nome para coluna nome
        /// </summary>
        internal const String K_COL_Nome = "nome";
		/// <summary>
        /// Mapeamento do atributo Situacao para coluna situacao
        /// </summary>
        internal const String K_COL_Situacao = "situacao";
		/// <summary>
        /// Mapeamento do atributo Sexo para coluna sexo
        /// </summary>
        internal const String K_COL_Sexo = "sexo";
		/// <summary>
        /// Mapeamento do atributo BrincoMae para coluna brincoMae
        /// </summary>
        internal const String K_COL_BrincoMae = "brincoMae";
		/// <summary>
        /// Mapeamento do atributo BrincoPai para coluna brincoPai
        /// </summary>
        internal const String K_COL_BrincoPai = "brincoPai";
		/// <summary>
        /// Mapeamento do atributo Raca para coluna raca
        /// </summary>
        internal const String K_COL_Raca = "raca";
		/// <summary>
        /// Mapeamento do atributo DataNascimento para coluna dataNascimento
        /// </summary>
        internal const String K_COL_DataNascimento = "dataNascimento";
		/// <summary>
        /// Mapeamento do atributo DataPrenches para coluna dataPrenches
        /// </summary>
        internal const String K_COL_DataPrenches = "dataPrenches";
		/// <summary>
        /// Mapeamento do atributo DataUltimoParto para coluna dataUltimoParto
        /// </summary>
        internal const String K_COL_DataUltimoParto = "dataUltimoParto";


        /// <summary>
        /// Atributo fisico brinco, mapeia coluna brinco
        /// </summary>
        public TString brinco;  // brinco
        /// <summary>
        /// Atributo fisico nome, mapeia coluna nome
        /// </summary>
        public TString nome;  // nome
        /// <summary>
        /// Atributo fisico situacao, mapeia coluna situacao
        /// </summary>
        public TString situacao;  // situacao
        /// <summary>
        /// Atributo fisico sexo, mapeia coluna sexo
        /// </summary>
        public TString sexo;  // sexo
        /// <summary>
        /// Atributo fisico brincoMae, mapeia coluna brincoMae
        /// </summary>
        public TString brincoMae;  // brincoMae
        /// <summary>
        /// Atributo fisico brincoPai, mapeia coluna brincoPai
        /// </summary>
        public TString brincoPai;  // brincoPai
        /// <summary>
        /// Atributo fisico raca, mapeia coluna raca
        /// </summary>
        public TString raca;  // raca
        /// <summary>
        /// Atributo fisico dataNascimento, mapeia coluna dataNascimento
        /// </summary>
        public TDate dataNascimento;  // dataNascimento
        /// <summary>
        /// Atributo fisico dataPrenches, mapeia coluna dataPrenches
        /// </summary>
        public TDate dataPrenches;  // dataPrenches
        /// <summary>
        /// Atributo fisico dataUltimoParto, mapeia coluna dataUltimoParto
        /// </summary>
        public TDate dataUltimoParto;  // dataUltimoParto
		//<bucb>User Consts
		//<eucb>User Consts

		//<bucb>User Atributos 
		//<eucb>User Atributos
		
		//<bucb> User Defined Constructors
		//<eucb> User Defined Constructors
		
        /// <summary>
        /// 
        /// </summary>
        public ColBovino()
        //----------------------------------------------------------------------------------------
        {
            //<bucb> ColBovino()
			//<eucb> ColBovino()
        }
   
        /// <summary>
        /// Metodo de identificacao da tabela física que mapeia o objeto (K_TBL_#@BC$className)
        /// </summary>
        /// <returns>
        ///
        /// </returns>
        override public String getTableName()
        //----------------------------------------------------------------------------------------
        { 
            return K_TBL_Bovino; 
        }

		// Metodos acessores para as colunas da Tabela
		// Acesso as colunas
        public static RDBColumn colunaBrinco(RDBTable pTbl) 
        { 
            //<bucb> colunaBrinco
            //<eucb> colunaBrinco
            return pTbl.col(K_COL_Brinco); 
        }
        public static RDBColumn colunaNome(RDBTable pTbl) 
        { 
            //<bucb> colunaNome
            //<eucb> colunaNome
            return pTbl.col(K_COL_Nome); 
        }
        public static RDBColumn colunaSituacao(RDBTable pTbl) 
        { 
            //<bucb> colunaSituacao
            //<eucb> colunaSituacao
            return pTbl.col(K_COL_Situacao); 
        }
        public static RDBColumn colunaSexo(RDBTable pTbl) 
        { 
            //<bucb> colunaSexo
            //<eucb> colunaSexo
            return pTbl.col(K_COL_Sexo); 
        }
        public static RDBColumn colunaBrincoMae(RDBTable pTbl) 
        { 
            //<bucb> colunaBrincoMae
            //<eucb> colunaBrincoMae
            return pTbl.col(K_COL_BrincoMae); 
        }
        public static RDBColumn colunaBrincoPai(RDBTable pTbl) 
        { 
            //<bucb> colunaBrincoPai
            //<eucb> colunaBrincoPai
            return pTbl.col(K_COL_BrincoPai); 
        }
        public static RDBColumn colunaRaca(RDBTable pTbl) 
        { 
            //<bucb> colunaRaca
            //<eucb> colunaRaca
            return pTbl.col(K_COL_Raca); 
        }
        public static RDBColumn colunaDataNascimento(RDBTable pTbl) 
        { 
            //<bucb> colunaDataNascimento
            //<eucb> colunaDataNascimento
            return pTbl.col(K_COL_DataNascimento); 
        }
        public static RDBColumn colunaDataPrenches(RDBTable pTbl) 
        { 
            //<bucb> colunaDataPrenches
            //<eucb> colunaDataPrenches
            return pTbl.col(K_COL_DataPrenches); 
        }
        public static RDBColumn colunaDataUltimoParto(RDBTable pTbl) 
        { 
            //<bucb> colunaDataUltimoParto
            //<eucb> colunaDataUltimoParto
            return pTbl.col(K_COL_DataUltimoParto); 
        }

        /// <summary>
        /// Inicializacao da classe de acesso à base de dados. Executa o bind com #@BC$className e
        ///registra as colunas da tabela na classe.
        /// </summary>
        /// <returns>
        ///
        /// </returns>
        override public void setup() 
        {
            // Registro de colunas: DEVE OBEDECER A ORDEM DOS ATRIBUTOS PUBLIC DO COL
			setColumn("brinco", createColumnRef(K_COL_Brinco));
			setColumn("nome", createColumnRef(K_COL_Nome));
			setColumn("situacao", createColumnRef(K_COL_Situacao));
			setColumn("sexo", createColumnRef(K_COL_Sexo));
			setColumn("brincoMae", createColumnRef(K_COL_BrincoMae));
			setColumn("brincoPai", createColumnRef(K_COL_BrincoPai));
			setColumn("raca", createColumnRef(K_COL_Raca));
			setColumn("dataNascimento", createColumnRef(K_COL_DataNascimento));
			setColumn("dataPrenches", createColumnRef(K_COL_DataPrenches));
			setColumn("dataUltimoParto", createColumnRef(K_COL_DataUltimoParto));
            base.setup();   // Deve suceder o registro de colunas do filho
            m_late_bind_clname = "RPOObject.Bovino";
            m_late_bind_clid   = Bovino.K_CLID_Bovino;
            //<bucb> setup
            //<eucb> setup
        }

        override public void convertDbToObject(RPOObject pObj)
        {
			var t_obj = (Bovino)pObj;
			base.convertDbToObject(t_obj);
			t_obj.setBrinco(brinco);
			t_obj.setNome(nome);
			t_obj.setSituacao(situacao);
			t_obj.setSexo(sexo);
			t_obj.setBrincoMae(brincoMae);
			t_obj.setBrincoPai(brincoPai);
			t_obj.setRaca(raca);
			t_obj.setDataNascimento(dataNascimento);
			t_obj.setDataPrenches(dataPrenches);
			t_obj.setDataUltimoParto(dataUltimoParto);
			//<bucb> convertDbToObject(RPOObject pObj)
			//<eucb> convertDbToObject(RPOObject pObj)
        }

        override public void convertObjectToDb(RPOObject pObj)
        { 
            try 
            {
                var t_obj = (Bovino)pObj;
                base.convertObjectToDb(pObj);
				brinco = t_obj.getBrinco();
				nome = t_obj.getNome();
				situacao = t_obj.getSituacao();
				sexo = t_obj.getSexo();
				brincoMae = t_obj.getBrincoMae();
				brincoPai = t_obj.getBrincoPai();
				raca = t_obj.getRaca();
				dataNascimento = t_obj.getDataNascimento();
				dataPrenches = t_obj.getDataPrenches();
				dataUltimoParto = t_obj.getDataUltimoParto();
            } 
            catch(Exception e_exp) 
            { 
               __trace(e_exp); 
            }
        }

        protected override void prepareWhereClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria) 
        {
            base.prepareWhereClause(t_select, t_tab, t_criteria);
            //<bucb> prepareWhereClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria) 

            Bovino criterioSelecao = (Bovino)t_criteria;
            if (!string.IsNullOrEmpty(criterioSelecao.getNome()))
            {
                t_select.where().and(colunaNome(t_tab).eq(criterioSelecao.getNome()));
            }

            //<eucb> prepareWhereClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria) 
        }

        protected override void prepareOrderClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria)  
        {
			//<bucb> prepareOrderClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria)  
			//<eucb> prepareOrderClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria)  
        }
		
		public static string getStaticTableName()
		{
			return K_TBL_Bovino;
		}
		
		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos

		//<bucb>User NegociaisProtegidos
		//<eucb>User NegociaisProtegidos
		
		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados
        
    } //public class ColBovino : ColRPOObject

}   // End namespace application.col

