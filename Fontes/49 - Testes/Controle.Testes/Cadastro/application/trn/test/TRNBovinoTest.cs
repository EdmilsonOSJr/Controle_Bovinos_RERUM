// Project  : 
// Type     : TRN Tests
// Creation :
// Description:

using System;
using application.bos;
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

            Bovino bovino = new Bovino();
            bovino.setNome("mimosa");
            bovino.setBrinco("br001");
            bovino.setBrincoMae("");
            bovino.setBrincoPai("");
            bovino.setSituacao("vendido");
            bovino.setRaca("pura");
            bovino.setSexo("femea");

            trn.Bovino = bovino;

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


            trn.Brinco = "75dd5d248f40491e81c9ee851ab4c782";

            trn.ExecConsultarBovinos();

            if(trn.RetornoConsulta!=null && trn.RetornoConsulta.Count > 0)
            {
                 foreach(Bovino b in trn.RetornoConsulta)
                {
                    Console.WriteLine(string.Format("Nome = {0} e Brinco = {1}", b.getNome(), b.getBrinco()));
                }
            }


			//<eucb> EvConsultarBovinosTest()
            Assert.IsFalse(trn.hasError());
		}
		//<bucb> User Defined Tests
		//<eucb> User Defined Tests
    }
}
