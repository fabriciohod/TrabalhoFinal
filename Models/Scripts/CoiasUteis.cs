using System;
using System.Linq;

namespace TrabalhoFinal.Scripts
{
    public class CoiasUteis
    {
        public static Func<string[], string> PegarUmValorNoArray = array => array[new Random ().Next (array.Length)];
        public static Func<string, char[]> CodificarString => item =>
            item.Select (item => '*')
            .ToArray ();
        public static Func<int, char[]> ConvertIntToCharArray = (item) =>
            item.ToString ()
            .ToCharArray ();
        public static Func<string, char[]> ConvertStringToCharArray = (item) =>
            item.Trim ()
            .ToCharArray ();
        public static Func<string, string, string, bool> NullCheck = (texto1, texto2, texto3) =>
            String.IsNullOrEmpty (texto1) ||
            String.IsNullOrEmpty (texto2) ||
            String.IsNullOrEmpty (texto3);
        public static Func<string, string, string, bool> CheckVitoria = (texto1, texto2, texto3) =>
            texto1.Equals (texto2) &&
            texto2.Equals (texto3);

    }
}