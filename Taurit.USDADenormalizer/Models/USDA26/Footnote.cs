namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Footnote File (file name = FOOTNOTE). This file (Table 13) contains additional information
    ///     about the food item, household weight, and nutrient value.
    /// </summary>
    public class Footnote
    {
        /// <summary>
        ///     5-digit Nutrient Databank number.
        /// </summary>
        public string NDBNo { get; set; }

        /// <summary>
        ///     Sequence number. If a given footnote applies to more than one nutrient number, the same footnote number is used. As
        ///     a result, this file cannot be indexed.
        /// </summary>
        public string FootntNo { get; set; }

        /// <summary>
        ///     Type of footnote:
        ///     D = footnote adding information to the food description;
        ///     M = footnote adding information to measure description;
        ///     N = footnote providing additional information on a nutrient value. If the Footnt_typ = N, the Nutr_No will also be
        ///     filled in.
        /// </summary>
        public string FootntTyp { get; set; }

        /// <summary>
        ///     Unique 3-digit identifier code for a nutrient to which footnote applies.
        /// </summary>
        public string NutrNo { get; set; }

        /// <summary>
        ///     Footnote text.
        /// </summary>
        public string FootntTxt { get; set; }
    }
}