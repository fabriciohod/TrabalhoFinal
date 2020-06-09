using System;
using System.Collections.Generic;
using TrabalhoFinal.Scripts;
namespace TrabalhoFinal.Models.JogoDaVelha
{
    public class JogoDaVelha
    {
        public string[, ] Tabulairo { get; private set; } = new string[3, 3];
        public bool TurnoDo_X { get; private set; } = true;
        public int Pontos_X { get; private set; }
        public int Pontos_O { get; private set; }
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
        public void ResetJogo ()
        {
            TurnoDo_X = true;
            oJogoAcabou = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Tabulairo[i, j] = "";
                }
            }
        }
        public void VerificarVitoria ()
        {
            if (VerificarLinha (this.Tabulairo)) Placar();
            if (VerificarColuna (this.Tabulairo)) Placar() ;
            if (VerificarDiagonalPrincipal (this.Tabulairo)) Placar() ;
            if (VerificarDiagonalSecundaria (this.Tabulairo)) Placar() ;
        }
        public void Placar ()
        {
            oJogoAcabou = true;
            if (!TurnoDo_X) Pontos_X += 1;
            else Pontos_O += 1;

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