namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Nutrient Definition File (file name = NUTR_DEF). This file (Table 9) is a support file to the
    ///     Nutrient Data file. It provides the 3-digit nutrient code, unit of measure, INFOODS tagname, and description.
    /// </summary>
    public class NutrientDefinition
    {
        /// <summary>
        ///     Unique 3-digit identifier code for a nutrient.
        /// </summary>
        public int NutrNo { get; set; }

        /// <summary>
        ///     Units of measure (mg, g, μg, and so on).
        /// </summary>
        public string Units { get; set; }

        /// <summary>
        ///     International Network of Food Data Systems (INFOODS) Tagnames. A unique abbreviation for a nutrient/food component
        ///     developed by INFOODS to aid in the interchange of data.
        /// </summary>
        public string Tagname { get; set; }

        /// <summary>
        ///     Name of nutrient/food component.
        /// </summary>
        public string NutrDesc { get; set; }

        /// <summary>
        ///     Number of decimal places to which a nutrient value is rounded.
        /// </summary>
        public string NumDec { get; set; }

        /// <summary>
        ///     Used to sort nutrient records in the same order as various reports produced from SR.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string SROrder { get; set; }
    }
}