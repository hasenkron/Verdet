namespace Verdet.Helper
{
    class ReturnAlert
    {
        
        private static string textLength;
        private static string onlyEnglish;

        public static string TextLengthAlert
        {
            get => textLength = "Kullanıcı adı en az " + Control.TextLengthMin + "en fazla " + Control.TextLengthMax + " karakter olabilir.";
            set => textLength = value;
        }
        public static string OnlyEnglishAlert
        {
            get => onlyEnglish = "Sadece ingilizce karakter, sayı, alt tire ve nokta kullanabilirsiniz.";
            set => onlyEnglish = value;
        }
    }
}
