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
            var minutosEstadia = (saida - entrada).TotalMinutes;
            if (VerificaTempoTolerancia(minutosEstadia))
                return 0;

            var fracoesEstadia = (int)Math.Ceiling(minutosEstadia / 15f);
            fracoesEstadia = CalculoPromocao(fracoesEstadia);

            return _precoFracao * fracoesEstadia;
        }

        private bool VerificaTempoTolerancia(double minutosEstadia)
        {
            return minutosEstadia < 15;
        }

        private static int CalculoPromocao(int fracoesEstadia)
        {
            if (fracoesEstadia >= 4 && fracoesEstadia <= 16)
                fracoesEstadia = 4;
            else if (fracoesEstadia > 16)
                fracoesEstadia -= 12;
            return fracoesEstadia;
        }
    }
}