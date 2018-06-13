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
            float fracoesEstadia = (float)(saida - entrada).TotalMinutes / 15f;

            fracoesEstadia = CalculoPromocao(fracoesEstadia);
            return _precoFracao * fracoesEstadia;
        }

        private static float CalculoPromocao(float fracoesEstadia)
        {
            if (fracoesEstadia >= 4 && fracoesEstadia <= 16)
                fracoesEstadia = 4;
            else if (fracoesEstadia > 16)
                fracoesEstadia -= 12;
            return fracoesEstadia;
        }
    }
}