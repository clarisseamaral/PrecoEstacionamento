using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrecoEstacionamento.Web.Negocio;

namespace PrecoEstacionamento.Teste
{
    [TestClass]
    public class TesteCalculoPreco
    {
        [DataRow(2)]
        [DataRow(3.5f)]
        [DataRow(5)]
        [DataTestMethod]
        public void PrecoUmaFracao(float precoFracao)
        {
            var calculo = new CalculoPreco(precoFracao);

            var valor = calculo.CalculaPreco(DateTime.Parse("2018-03-10 10:00"), DateTime.Parse("2018-03-01 10:15"));

            Assert.AreEqual(precoFracao, valor);
        }
    }
}
