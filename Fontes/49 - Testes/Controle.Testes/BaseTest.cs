using System;
using com.rerum.app;
using com.rerum.sys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Treinamento.Testes
{
    /// <summary>
    /// Classe base para os testes unitários.
    /// </summary>
    /// <Author>Marcelo Nepomuceno - Rerum</Author>
    [TestClass]
    [DeploymentItem("Application.xml")]
    [DeploymentItem("FilteredClass.ini")]
    public abstract class BaseTest
    {
        /// <summary>
        /// Representa a instancia do RPO aplication.
        /// </summary>
        protected RPOApplication RpoApp { get; set; }
        [TestInitialize()]
        public void InitRpoApplication()
        {
            RpoApp = new RPOApplication("Application");
            if (RpoApp.init() != RStatus.OK)
            {
                throw new TypeInitializationException(typeof(RPOApplication).FullName, null);
            }
        }
        [TestCleanup()]
        public void TerminateRpoApplication()
        {
            if (RpoApp != null)
            {
                RpoApp.terminate();
            }
        }
    }
}
