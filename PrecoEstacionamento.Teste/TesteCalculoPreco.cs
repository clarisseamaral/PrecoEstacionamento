using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrecoEstacionamento.Web.Negocio;

namespace PrecoEstacionamento.Teste
{
    [TestClass]
    public class TesteCalculoPreco
    {
        [TestMethod]
        public void PrecoUmaFracao()
        {
            var precoFracao = 2;
            var calculo = new CalculoPreco(precoFracao);

            var valor = calculo.CalculaPreco(DateTime.Parse("2018-03-10 10:00"), DateTime.Parse("2018-03-01 10:15"));

            Assert.AreEqual(precoFracao, valor);
        }
    }
}
