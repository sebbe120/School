using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public class Amulet : Merchandise
    {
        private string design;
        private Level quality;
        public static double LowQualityValue { get; set; } = 12.5;
        public static double MediumQualityValue { get; set; } = 20.0;
        public static double HighQualityValue { get; set; } = 27.5;

        public Amulet(string itemId)
        {
            base.ItemId = itemId;
            Quality = Level.medium;
        }
        public Amulet(string itemId, Level quality)
        {
            base.ItemId = itemId;
            Quality = quality;
        }
        public Amulet(string itemId, Level quality, string design)
        {
            base.ItemId = itemId;
            Quality = quality;
            Design = design;
        }

        public string Design
        {
            get { return design; }
            set { design = value; }
        }

        public Level Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        public override double GetValue()
        {
            double value = 0.0;
            if (Quality == Level.low)
                value = LowQualityValue;
            else if (Quality == Level.medium)
                value = MediumQualityValue;
            else if (Quality == Level.high)
                value = HighQualityValue;

            return value;
        }

        public override string ToString()
        {
            return "ItemId: " + ItemId + ", Quality: " + Quality + ", Design: " + Design;
        }
    }
}
