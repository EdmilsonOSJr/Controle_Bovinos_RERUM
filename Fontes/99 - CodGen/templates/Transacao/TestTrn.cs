// Project  : 
// Type     : TRN Tests
// Creation :
// Description:

using System;
using application.trn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//<bucb> User Imports
//<eucb> User Imports

#set( $namespace = $cspkg.replace(".", "") )
namespace Treinamento.Testes.${namespace}.application.trn
{
	/// <summary>
	/// Testes para transação - TRN${name}
	/// </summary>
	/// <Author>${author}</Author>
	/// <Created>${created}</Created>
	/// <Modified>${modified}</Modified>
    [TestClass]
	public class TRN${name}Test : BaseTest
    {
		//<bucb> User attributes
		//<eucb> User attributes
		
		//<bucb> User Constants
		//<eucb> User Constants
		
		public TRN${name}Test() 
			: base()
		{
			//<bucb> TRN${name}Test()
			//<eucb> TRN${name}Test()
		}
#foreach ($e in $events)
#if (${e.name.upFirst} != "ConsultarContratoPorCnpj")

		[TestMethod()]
		public void Ev${e.name.upFirst}Test()
		{
            var trn = new TRN${name}();
			//<bucb> Ev${e.name.upFirst}Test()
            trn.Exec${e.name.upFirst}();
			//<eucb> Ev${e.name.upFirst}Test()
            Assert.IsFalse(trn.hasError());
		}
#end
#end
		//<bucb> User Defined Tests
		//<eucb> User Defined Tests
    }
}
