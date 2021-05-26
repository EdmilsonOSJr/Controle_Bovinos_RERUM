// Project  : 
// Type     : COL
// Creation :
// Description:
#set ($H = '#')
using System;
${H}region imports
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
${H}endregion imports

namespace application.col
{ 
	/// <summary>
	/// Objeto negocial ${name}
	/// </summary>
	/// <Author>${author}</Author>
	/// <Created>${created}</Created>
	/// <Modified>${modified}</Modified>
#if ($bosbase || $base == 'RPOActive')
	public class Col${name} : ColRPOObject
#else
	public class Col${name} : Col${base}
#end
    {
        /// <summary>
        /// Table Name    -->   "${tableName}";
        /// </summary>
        internal const String K_TBL_${name} = "${tableName}";

#foreach($a in $attributes)
		/// <summary>
        /// Mapeamento do atributo ${a.field.upFirst} para coluna ${a.column}
        /// </summary>
        internal const String K_COL_${a.field.upFirst} = "${a.column}";
#end
#foreach($a in $associations)
		/// <summary>
        /// Mapeamento do atributo ${a.field.upFirst} para coluna ${a.column}
        /// </summary>
        internal const String K_COL_${a.field.upFirst} = "${a.column}";
#end
#if ($classname)
        /// <summary>
        /// Atributo fisico classname, mapeia coluna classname
        /// </summary>
        internal const String K_COL_classname		= "classname";
#end

#if ($classname)
        /// <summary>
        /// Atributo fisico ${a.field}, mapeia coluna ${a.column}
        /// </summary>
        public TString classname;
#end

#foreach($a in $attributes)
        /// <summary>
        /// Atributo fisico ${a.field}, mapeia coluna ${a.column}
        /// </summary>
        public ${a.rpotype} ${a.column};  // ${a.column}
#end
#foreach($a in $associations)
        /// <summary>
        /// Atributo fisico ${a.field}, mapeia coluna ${a.column}
        /// </summary>
        public TObjectId ${a.column};  // ${a.column}
#end
		//<bucb>User Consts
		//<eucb>User Consts

		//<bucb>User Atributos 
		//<eucb>User Atributos
		
		//<bucb> User Defined Constructors
		//<eucb> User Defined Constructors
		
        /// <summary>
        /// 
        /// </summary>
        public Col${name}()
        //----------------------------------------------------------------------------------------
        {
            //<bucb> Col${name}()
			//<eucb> Col${name}()
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
            return K_TBL_${name}; 
        }

		// Metodos acessores para as colunas da Tabela
		// Acesso as colunas
#foreach ($a in $attributes)
        public static RDBColumn coluna${a.field.upFirst}(RDBTable pTbl) 
        { 
            //<bucb> coluna${a.field.upFirst}
            //<eucb> coluna${a.field.upFirst}
            return pTbl.col(K_COL_${a.field.upFirst}); 
        }
#end
#foreach ($a in $associations)
        public static RDBColumn coluna${a.field.upFirst}(RDBTable pTbl) 
        { 
            //<bucb> coluna${a.field.upFirst}
            //<eucb> coluna${a.field.upFirst}
            return pTbl.col(K_COL_${a.field.upFirst}); 
        }
#end

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
#if ($classname)
			setColumn("classname", createColumnRef(K_COL_classname, ColumnType.Inheritance));
#end
#foreach($a in $attributes)
			setColumn("${a.column}", createColumnRef(K_COL_${a.field.upFirst}));
#end
#foreach($a in $associations)
			setColumn("${a.column}", createColumnRef(K_COL_${a.field.upFirst}));
#end
            base.setup();   // Deve suceder o registro de colunas do filho
            m_late_bind_clname = "${base}.${name}";
            m_late_bind_clid   = ${name}.K_CLID_${name};
            //<bucb> setup
            //<eucb> setup
        }

        override public void convertDbToObject(RPOObject pObj)
        {
			var t_obj = (${name})pObj;
			base.convertDbToObject(t_obj);
#foreach($a in $attributes)
			t_obj.set${a.field.upFirst}(${a.column});
#end
#foreach($a in $associations)
			t_obj.setRef${a.field.upFirst}(${a.column});
#end
			//<bucb> convertDbToObject(RPOObject pObj)
			//<eucb> convertDbToObject(RPOObject pObj)
        }

        override public void convertObjectToDb(RPOObject pObj)
        { 
            try 
            {
                var t_obj = (${name})pObj;
                base.convertObjectToDb(pObj);
#foreach($a in $attributes)
				${a.column} = t_obj.get${a.field.upFirst}();
#end
#foreach($a in $associations)
				${a.column} = formaNull(t_obj.getRef${a.field.upFirst}());
#end
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
			//<eucb> prepareWhereClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria) 
        }

        protected override void prepareOrderClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria)  
        {
			//<bucb> prepareOrderClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria)  
			//<eucb> prepareOrderClause(RDBSelector t_select, RDBTable t_tab, RPOObject t_criteria)  
        }
		
#if ($base == 'RPOObject' || $base == 'RPOActive')
		public static string getStaticTableName()
#else
		new public static string getStaticTableName()
#end
		{
			return K_TBL_${name};
		}
		
		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos

		//<bucb>User NegociaisProtegidos
		//<eucb>User NegociaisProtegidos
		
		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados
        
    } //public class Col${name} : Col${base}

}   // End namespace application.col

