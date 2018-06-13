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

        // O preço de 6 horas é equivalente ao preço de 12 frações (promoção, 1h + 2h).
        [DataRow(20)]
        [DataRow(2.5f)]
        [DataRow(6)]
        [DataTestMethod]
        public void PrecoSeisHoras(float precoFracao)
        {
            var calculo = new CalculoPreco(precoFracao);

            var valor = calculo.CalculaPreco(DateTime.Parse("2018-03-10 10:00"), DateTime.Parse("2018-03-10 16:00"));

            Assert.AreEqual(precoFracao * 12, valor);
        }

        // O preço de 4 horas é equivalente ao preço de 4 frações (promoção, 1h).
        [DataRow(20)]
        [DataRow(2.5f)]
        [DataRow(6)]
        [DataTestMethod]
        public void PrecoQuatroHoras(float precoFracao)
        {
            var calculo = new CalculoPreco(precoFracao);

            var valor = calculo.CalculaPreco(DateTime.Parse("2018-03-10 10:00"), DateTime.Parse("2018-03-10 14:00"));

            Assert.AreEqual(precoFracao * 4, valor);
        }

        // O preço de 1h até 4 horas é de apenas 1h (promoção).
        [DataRow(2, 3)]
        [DataRow(2.5f, 1.5)]
        [DataRow(6, 3.89)]
        [DataTestMethod]
        public void PrecoHorasPromocao(float precoFracao, double horas)
        {
            var calculo = new CalculoPreco(precoFracao);

            var entrada = DateTime.Parse("2018-03-10 10:00");
            var valor = calculo.CalculaPreco(entrada, entrada.AddHours(horas));

            Assert.AreEqual(precoFracao * 4, valor);
        }

        // Se passou uma fração de hora, deve ser cobrado o valor inteiro da fração do cliente (ex: 35 minutos é pago como 3 frações, 45 minutos).
        [DataRow(2, 20, 4)]
        [DataRow(2.5f, 35, 7.5f)]
        [DataRow(6, 372, 78)] // 6:12
        [DataTestMethod]
        public void PrecoFracaoQuebrada(float precoFracao, int minutos, float valorEsperado)
        {
            var calculo = new CalculoPreco(precoFracao);

            var entrada = DateTime.Parse("2018-03-10 10:00");
            var valor = calculo.CalculaPreco(entrada, entrada.AddMinutes(minutos));

            Assert.AreEqual(valorEsperado, valor);
        }
    }
}
