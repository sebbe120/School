
namespace Morgengry
{
    public static class Utility
    {
        static Utility()
        {
            LowQualityValue = 12.5;
            MediumQualityValue = 20;
            HighQualityValue = 27.5;
        }

        public static double LowQualityValue { get; set; }
        public static double MediumQualityValue { get; set; }
        public static double HighQualityValue { get; set; }

        public static double GetValueOfMerchandise(Merchandise merchandise)
        {
            double value = 0.0;

            if (merchandise is Book book)
                value = book.Price;

            else if (merchandise is Amulet amulet)
            {
                if (amulet.Quality == Level.low)
                    value = LowQualityValue;
                else if (amulet.Quality == Level.medium)
                    value = MediumQualityValue;
                else if (amulet.Quality == Level.high)
                    value = HighQualityValue;
            }
            return value;
        }
    }
}
