// Project  : 
// Type     : BOS
// Creation :
// Description:
#set ($H = '#')
${H}region imports
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
${H}endregion
namespace application.bos
{
	/// <summary>
	///  Objeto negocial ${name}
	/// </summary>
	/// <Author>${author}</Author>
	/// <Created>${created}</Created>
	/// <Modified>${modified}</Modified>
	//<bucb>User Attributes
	//<eucb>User Attributes
#if ($bosbase)
	public class ${name} : ${bosbase}
#else
	public class ${name} : ${base}
#end
	{
		/// <summary>
		/// ClassId : identificador unico da classe 
		/// </summary>
		//<bucb>ClassId
		public const int K_CLID_${name} = 0;
		//<eucb>ClassId

		${H}region Atributos
#foreach ($a in $attributes)
		/// <summary>
		/// $a.doc
		/// </summary>
		protected ${a.rpotype} $a.field = new ${a.rpotype}();
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
		protected TObjectId $a.field = new TObjectId(typeof(${a.rpotype}));
#end
		${H}endregion

		${H}region Get/Set Associacoes
#foreach ($a in $associations)
#set ($atype = $a.rpotype)
		public $a.type get${a.field.upFirst}()
		{
			//<bucb> get${a.field.upFirst}()
			//<eucb> get${a.field.upFirst}()
			return ($a.type)getAttribute(${a.field});
		}

		public void set${a.field.upFirst}($atype value)
		{
			//<bucb> set${a.field.upFirst}($atype value)
			//<eucb> set${a.field.upFirst}($atype value)
			setAttribute(this.$a.field, value);
		}
		
		public void setRef${a.field.upFirst}(TObjectId value)
		{
			//<bucb> setRef${a.field.upFirst}(TObjectId value)
			//<eucb> setRef${a.field.upFirst}(TObjectId value)
			if (null != $a.field)
			{
				${a.field}.setOID(value);
			}
		}
		
		public void setRef${a.field.upFirst}(Object value)
		{
			//<bucb> setRef${a.field.upFirst}(Object value)
			//<eucb> setRef${a.field.upFirst}(Object value)
			if (null != $a.field)
			{
				${a.field}.setOID(value);
			}
		}
		
		public TObjectId getRef${a.field.upFirst}()
		{ 
			//<bucb> getRef${a.field.upFirst}()
			//<eucb> getRef${a.field.upFirst}()
			return ${a.field}; 
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
		
		//<bucb> User Defined Constructors
		//<eucb> User Defined Constructors

		/// <summary>
		/// Construtor de ${name}(). Normaliza classid e inicializa classe.
		/// </summary>
		public ${name}()
		//--------------------------------------------------------------------------------------------
		{
			m_classid = K_CLID_${name};

			//<bucb>User Construtor${name}
			//<eucb>User Construtor${name}
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
#foreach ($a in $aggregations)		
		public RTTList rec${a.field.upFirst}IfEmpty()
		{
			if ($a.field == null || ${a.field}.Count == 0)
			{
				rec${a.field.upFirst}To(out ${a.field});
			}
			return ${a.field};
		}
		
		public status_t rec${a.field.upFirst}To(out RTTList lst${a.field.upFirst})
		{
			status_t stRetorno = RStatus.OK;
			lst${a.field.upFirst} = null;
			try 
			{
				__tracein("${name}::rec${a.field.upFirst}To");
				//<bucb> rec${a.field.upFirst}To()
				//<eucb> rec${a.field.upFirst}To()
			} 
			catch(Exception ex) 
			{
				__trace(ex);
				lst${a.field.upFirst} = new RTTList();
				lst${a.field.upFirst}.setIsNull(true);
				stRetorno = RStatus.ERROR;
			} 
			finally 
			{
				__traceout("${name}::rec${a.field.upFirst}To");
			}
			return stRetorno;
		}
#end
		#endregion

	} // End public class ${name} : ${base}

} // End namespace application.bos