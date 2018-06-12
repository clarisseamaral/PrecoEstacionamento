using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrecoEstacionamento.Web.Negocio;

namespace PrecoEstacionamento.Teste
{
    [TestClass]
    public class TesteCalculoPreco
    {
        // O preço é dado por hora e dividido em frações de 15 minutos.
        [DataRow(2)]
        [DataRow(3.5f)]
        [DataRow(5)]
        [DataTestMethod]
        public void PrecoUmaFracao(float precoFracao)
        {
            var calculo = new CalculoPreco(precoFracao);

            var valor = calculo.CalculaPreco(DateTime.Parse("2018-03-10 10:00"), DateTime.Parse("2018-03-10 10:15"));

            Assert.AreEqual(precoFracao, valor);
        }

        // O preço de uma hora é equivalente ao preço de 4 frações.
        [DataRow(20)]
        [DataRow(2.5f)]
        [DataRow(6)]
        [DataTestMethod]
        public void PrecoUmaHora(float precoFracao)
        {
            var calculo = new CalculoPreco(precoFracao);

            var valor = calculo.CalculaPreco(DateTime.Parse("2018-03-10 10:00"), DateTime.Parse("2018-03-10 11:00"));

            Assert.AreEqual(precoFracao * 4, valor);
        }

        // O preço de 6 horas é equivalente ao preço de 24 frações.
        [DataRow(20)]
        [DataRow(2.5f)]
        [DataRow(6)]
        [DataTestMethod]
        public void PrecoSeisHoras(float precoFracao)
        {
            var calculo = new CalculoPreco(precoFracao);

            var valor = calculo.CalculaPreco(DateTime.Parse("2018-03-10 10:00"), DateTime.Parse("2018-03-10 16:00"));

            Assert.AreEqual(precoFracao * 24, valor);
        }
    }
}
