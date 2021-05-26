using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Treinamento.Testes
{
    /// <summary>
    /// Inicia o contexto do log para os testes.
    /// </summary>
    /// <Author> Marcelo Nepomuceno - Rerum </Author>
    [TestClass]
    public static class Startup
    {
        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}