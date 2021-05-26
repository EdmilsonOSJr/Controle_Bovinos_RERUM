// Project  : 
// Type     : DOM
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
namespace application.dom
{
	/// <summary>
	/// Domínio ${name}
	/// </summary>
	public class ${name} : RPODomain	
	{
        /// <summary>
        /// Identificação do dominio (deve coincidir com o valor em banco de dados) -- "${name}"
        /// </summary>
        public const String K_TDM_${name} = "${name}";

#foreach($item in $item_domain)
        public const int ${item.name} = Constantes.Numero_${item.id};
#end
		
		//<bucb>User Consts
		//<eucb>User Consts

		//<bucb>User Atributos 
		//<eucb>User Atributos

		/// <summary>
		/// Construtor de ${name}(). Normaliza classid e inicializa classe.
		/// </summary>
		public ${name}() 
			: base(K_TDM_${name})
		{
			//<bucb>User Construtor${name}
			//<eucb>User Construtor${name}
		}
		
		/// <summary>
		/// Construtor de ${name}(). Normaliza classid e inicializa classe.
		/// </summary>
		public ${name}(int valor) 
			: base(K_TDM_${name})
		{
			//<bucb>User Construtor${name}(int valor) 
			this.setCode(valor);
			//<eucb>User Construtor${name}(int valor) 
		}

		//<bucb>User NegociaisPublicos
		//<eucb>User NegociaisPublicos

		//<bucb>User NegociaisPrivados
		//<eucb>User NegociaisPrivados
		
        /// <summary>
        /// Conversão para inteiro, permite atribuição de um inteiro a um objeto da classe
        /// </summary>
    	public static implicit operator ${name}(int vlr)
	    {
		    ${name} lRetObj = new ${name}(vlr);
			//<bucb> operator ${name} (int vlr)
			//<eucb> operator ${name} (int vlr)
		    return lRetObj;
	    }
		
        /// <summary>
        /// Conversão para inteiro, permite atribuição de um inteiro a um objeto da classe
        /// </summary>
    	public static implicit operator int(${name} vlr)
	    {
			int retVal;
			if (vlr == null) 
			{ 
				//<bucb> operator ${name} to int // null
				retVal = -1;
				//<eucb> operator ${name} to int // null
			} 
			else 
			{
				//<bucb> operator ${name} to int // not-null
				retVal = vlr.getCode();
				//<eucb> operator ${name} to int // not-null
			}
		    return retVal;
	    }

	} // End public class ${name} : ${base}

} // End namespace application.bos

