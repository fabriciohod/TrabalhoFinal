using System;
using BlazorApp1.Scripts;
namespace BlazorApp1.Models.AdivinheSePoder
{
    public class AdivinheSePoder
    {
        public char[] Senha { get; private set; }
        public string Resulatado { get; private set; }
        public int Tentativas { get; set; } = 4;
        private Random _rnd = new Random ();
        public void VerificarSenha (string input)
        {
            char[] inputComoArray = CoiasUteis.ConvertStringToCharArray (input);
            int qtd = 0;

            if (this.Senha.Length == inputComoArray.Length)
                try
                {
                    if (this.Senha.Length == inputComoArray.Length)
                    {
                        for (int i = 0; i < this.Senha.Length; i++)
                        {

                            if (inputComoArray[i] == this.Senha[i])
                            {
                                qtd++;
                            }
                        }
                    }
                    if (qtd == this.Senha.Length) Resulatado = "🎉 Parabens voce acertou a senha 🎉";
                    else if (Tentativas >= 0)
                    {
                        Resulatado = "Voce errou 😥 tente outra vez";
                        Tentativas--;
                    }
                    else throw new IndexOutOfRangeException ();
                }
            catch (System.IndexOutOfRangeException)
            {
                Resulatado = "O input tem numero de caracters diferente da senha";
                return;
            }
        }
        public string QuantidadeDeDigitosNaSenha ()
        {
            string stringSenha = "";
            foreach (var digitos in this.Senha)
            {
                stringSenha += "*";
            }
            return stringSenha;
        }
        public void GerarSenha (char dificuldade)
        {
            switch (dificuldade)
            {
                case 'F':
                    this.Senha = CoiasUteis.ConvertIntToCharArray (_rnd.Next (100));
                    break;
                case 'M':
                    this.Senha = CoiasUteis.ConvertIntToCharArray (_rnd.Next (2000));
                    break;
                case 'D':
                    this.Senha = CoiasUteis.ConvertIntToCharArray (_rnd.Next (90000));
                    break;
                default:
                    this.Senha = CoiasUteis.ConvertIntToCharArray (_rnd.Next (2147483647));
                    break;
            }
        }

        public string SenhaComoString ()
        {
            string _senha = "";
            if (Senha != null)
            {
                foreach (var item in Senha)
                {
                    _senha += item;
                }
                return _senha;
            }
            return "Senha nao foi gerada";
        }
    }
}