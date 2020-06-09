using System;
using System.Collections.Generic;
using System.Linq;
using TrabalhoFinal.Scripts;

namespace TrabalhoFinal.models.forca
{
    public class Forca
    {
        public string[] BonecoDaForca { get; } = { "./image/base.png", "./image/cabeça.png", "./image/corpo.png", "./image/braçoD.png", "./image/braçoE.png", "./image/pernaD.png", "./image/pernaE.png" };
        private readonly string[] _temaJogos = { "zelda", "doom", "valorant", "minecraft", "counter-strike", "star fox" };
        private readonly string[] _temaComida = { "arroz", "feijão", "alface", "tomate", "carne" };
        public char[] Dica { get; private set; }
        public string PalavraSecreta { get; private set; }
        public List<char> LetrasErradas { get; private set; }
        public string TextoDeFimDejogo { get; private set; } = "";
        public bool oJogoAcabou { get; private set; } = false;
        public int IndexDoBoneco { get; private set; } = 0;

        public void EscolherTema (string tema)
        {
            switch (tema)
            {
                case "comida":
                    PalavraSecreta = CoiasUteis.PegarUmValorNoArray (_temaComida);
                    Dica = CoiasUteis.CodificarString (PalavraSecreta);
                    break;
                case "jogos":
                    PalavraSecreta = CoiasUteis.PegarUmValorNoArray (_temaJogos);
                    Dica = CoiasUteis.CodificarString (PalavraSecreta);
                    break;
                default:
                    return;
            }
        }
        public void VerificarFimDeJogo ()
        {
            if (!(Dica.Contains ('*')))
            {
                TextoDeFimDejogo = "Voce acertou, Parabens 🥳";
                oJogoAcabou = true;
            }
            if (BonecoDaForca[IndexDoBoneco] == BonecoDaForca[6])
            {
                TextoDeFimDejogo = "Voce perdeu, Boa sorte na proxima 😢";
                oJogoAcabou = true;
            }
            return;
        }
        public void VerificarResposta (char input)
        {
            try
            {
                char[] palavraSecreta = PalavraSecreta.ToCharArray ();
                if (PalavraSecreta.Contains (input))
                {
                    for (int i = 0; i < Dica.Length; i++)
                    {
                        if (palavraSecreta[i] == input) Dica[i] = input;
                        else continue;
                    }

                }
                else
                {
                    MudarBoneco ();
                    LetrasErradas.Add (input);
                }
            }
            catch (Exception)
            {
                return;
            }

        }
        private int MudarBoneco () => IndexDoBoneco <= 5 ? IndexDoBoneco++ : IndexDoBoneco;
    }
}