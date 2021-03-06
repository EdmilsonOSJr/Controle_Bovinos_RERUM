// Project  : 
// Type     : TRN Tests
// Creation :
// Description:

using System;
using application.trn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//<bucb> User Imports
//<eucb> User Imports

namespace Treinamento.Testes.Cadastro.application.trn
{
	/// <summary>
	/// Testes para transação - TRNBovino
	/// </summary>
	/// <Author>Rerum</Author>
	/// <Created>2021-05-26T13:47:08-03:00</Created>
	/// <Modified>2021-05-26T13:53:15-03:00</Modified>
    [TestClass]
	public class TRNBovinoTest : BaseTest
    {
		//<bucb> User attributes
		//<eucb> User attributes
		
		//<bucb> User Constants
		//<eucb> User Constants
		
		public TRNBovinoTest() 
			: base()
		{
			//<bucb> TRNBovinoTest()
			//<eucb> TRNBovinoTest()
		}

		[TestMethod()]
		public void EvManterBovinoTest()
		{
            var trn = new TRNBovino();
			//<bucb> EvManterBovinoTest()
            trn.ExecManterBovino();
			//<eucb> EvManterBovinoTest()
            Assert.IsFalse(trn.hasError());
		}

		[TestMethod()]
		public void EvRecuperarBovinoPorIdTest()
		{
            var trn = new TRNBovino();
			//<bucb> EvRecuperarBovinoPorIdTest()
            trn.ExecRecuperarBovinoPorId();
			//<eucb> EvRecuperarBovinoPorIdTest()
            Assert.IsFalse(trn.hasError());
		}

		[TestMethod()]
		public void EvConsultarBovinosTest()
		{
            var trn = new TRNBovino();
			//<bucb> EvConsultarBovinosTest()
            trn.ExecConsultarBovinos();
			//<eucb> EvConsultarBovinosTest()
            Assert.IsFalse(trn.hasError());
		}
		//<bucb> User Defined Tests
		//<eucb> User Defined Tests
    }
}
