// Project  : 
// Type     : TYPE
// Creation :
// Description:
#set ($H = '#')
${H}region imports
using System;

using com.rerum.rpo;
using com.rerum.sys;
using com.rerum.types;

using application.types;

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
using Long          = System.Int64;
using Integer       = System.Int32;
${H}endregion
namespace application.types
{
	/// <summary>
	///  Tipo Abstrato de Dados ${name}
	/// </summary>
	public class ${name} : ${base}
	{
		//<bucb>User Consts
		//<eucb>User Consts

		//<bucb>User Atributos 
		//<eucb>User Atributos

		//BBLK#User Attributes#> 
		//EBLK#User Attributes#>

		///<summary>
		/// Construtor de ${name}(). Inicia com valor padrão
		///</summary>
		public ${name}() 
			: base(0)
		{
			this.setIsNull(true);
			//<bucb>User Construtor${name}()
			//<eucb>User Construtor${name}()
		}

		///<summary>
		/// Construtor de ${name}(). Inicia com valor padrão
		///</summary>
		public ${name}(${native.cs} val) 
			: base(val)
		{
			//<bucb>User Construtor${name}()
			//<eucb>User Construtor${name}()
		}

		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos

		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados
		
        public static implicit operator ${name}(${native.cs} vlr)
        {
            ${name} lRetObj = new ${name}(vlr);
			//<bucb> Implicit from ${native.cs}
			//<eucb> Implicit from ${native.cs}
            return lRetObj;
        }

	} // End public class ${name} : ${base}

} // End namespace application.bos

