using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrecoEstacionamento.Web.Negocio
{

    public class CalculoPreco
    {
        private readonly float _precoFracao;

        public CalculoPreco(float precoFracao)
        {
            _precoFracao = precoFracao;
        }

        public float CalculaPreco(DateTime entrada, DateTime saida)
        {
            return _precoFracao * (float)(saida - entrada).TotalMinutes / 15f;
        }
    }
}