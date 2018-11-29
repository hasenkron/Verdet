using System.Text.RegularExpressions;

namespace Verdet.Helper
{
    /// <summary>
    /// Kontrol mekanizmaları bu sınıfta yer alır.
    /// <EN>Control mechanisms are included in this class.</EN>
    /// </summary>

    class Control
    {
        
        public static int TextLengthMin { get; set; } = 2;
        public static int TextLengthMax { get; set; } = 13;

        /// <summary>
        /// Eğer girilen değerin uzunluğu TextLengthMin ile TextLengthMax arasında ise bu metod true döndürür.
        /// <EN>If value length between TextLengthMin or TextLengthMax this method return true.</EN>
        /// </summary>
        /// <param name="str">Kontrol edilecek değer.
        /// <EN>Value to be checked.</EN></param>
        /// <returns>Bool</returns>

        public static bool TextLength(string str)
        {
            if (str.Length <= TextLengthMin || str.Length >= TextLengthMax)
                return true;
            else
                return false;
        }

     

        
        /// <summary>
        /// Eğer girilen değer ingilizce karakter içermiyorsa veya boşluk var ise bu metod true döndürür. Sayı, alttire ve nokta false döndürür.
        /// <EN>If value contains non-English character or space, this method return true. Number, underscore and dot return false.</EN>
        /// </summary>
        /// <param name="str">Value to be checked.</param>
        /// <returns>Bool</returns>
        public static bool OnlyEnglish(string str)
        {
            Regex rx = new Regex("[^a-zA-Z0-9_.|\t]");
            if (rx.IsMatch(str))
                return true;
            else
                return false;
        }
    }
}
