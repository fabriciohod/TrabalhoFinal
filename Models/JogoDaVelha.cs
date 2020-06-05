using System;
using System.Collections.Generic;
using BlazorApp1.Scripts;
namespace BlazorApp1.Models.JogoDaVelha
{
    public class JogoDaVelha
    {
        public string[, ] Tabulairo { get; private set; } = new string[3, 3];
        private List<bool> resultados = new List<bool> (4);
        public bool TurnoDo_X { get; private set; } = true;
        public bool oJogoAcabou { get; private set; } = false;
        // TODO: Pensar em um nome melhor
        public void MarcarOndeFoiClicado (int i, int j)
        {
            Func<bool> PassarTurno = () => TurnoDo_X = TurnoDo_X is true ? false : true;
            if (Tabulairo[i, j] == "X" || Tabulairo[i, j] == "O") return;
            switch (TurnoDo_X)
            {
                case true:
                    Tabulairo[i, j] = "X";
                    PassarTurno ();
                    break;

                case false:
                    Tabulairo[i, j] = "O";
                    PassarTurno ();
                    break;
            }
        }
        public void VerificarVitoria ()
        {
            resultados.Add (VerificarLinha (this.Tabulairo));
            resultados.Add (VerificarColuna (this.Tabulairo));
            resultados.Add (VerificarDiagonalPrincipal (this.Tabulairo));
            resultados.Add (VerificarDiagonalSecundaria (this.Tabulairo));
            if (resultados.Contains (true)) oJogoAcabou = true;
        }
        private bool VerificarLinha (string[, ] matriz)
        {
            for (int i = 0; i < matriz.GetLength (0); i++)
            {
                if (CoiasUteis.NullCheck (matriz[i, 0], matriz[i, 1], matriz[i, 2])) continue;
                if (CoiasUteis.CheckVitoria (matriz[i, 0], matriz[i, 1], matriz[i, 2])) return true;
            }
            return false;
        }
        private bool VerificarColuna (string[, ] matriz)
        {
            for (int j = 0; j < matriz.GetLength (1); j++)
            {
                if (CoiasUteis.NullCheck (matriz[0, j], matriz[1, j], matriz[2, j])) continue;
                if (CoiasUteis.CheckVitoria (matriz[0, j], matriz[1, j], matriz[2, j])) return true;
            }
            return oJogoAcabou = false;
        }
        private bool VerificarDiagonalPrincipal (string[, ] matriz)
        {
            if (CoiasUteis.NullCheck (matriz[0, 0], matriz[1, 1], matriz[2, 2])) return false;
            if (CoiasUteis.CheckVitoria (matriz[0, 0], matriz[1, 1], matriz[2, 2])) return true;
            return oJogoAcabou = false;
        }
        private bool VerificarDiagonalSecundaria (string[, ] matriz)
        {
            if (CoiasUteis.NullCheck (matriz[0, 2], matriz[1, 1], matriz[2, 0])) return false;
            if (CoiasUteis.CheckVitoria (matriz[0, 2], matriz[1, 1], matriz[2, 0])) return true;
            return false;
        }
    }
}