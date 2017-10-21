namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// LanguaL Factor File (File name = LANGUAL). This file (Table 6) is a support file to the Food Description
    /// file and contains the factors from the LanguaL Thesaurus used to code a particular food.
    /// </summary>
    public class LangualFactor
    {
        /// <summary>
        /// Links to the Food Description file by the NDB_No field
        /// </summary>
        public string NDBNo { get; set; }

        /// <summary>
        /// Links to LanguaL Factors Description file by the Factor_Code field
        /// </summary>
        public string FactorCode { get; set; }
    }
}
