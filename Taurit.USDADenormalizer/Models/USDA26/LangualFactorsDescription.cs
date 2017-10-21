namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// LanguaL Factors Description File (File name = LANGDESC). This file (Table 7) is a support file
    /// to the LanguaL Factor file and contains the descriptions for only those factors used in coding
    /// the selected food items codes in this release of SR.
    /// </summary>
    public class LangualFactorsDescription
    {
        /// <summary>
        /// The LanguaL factor from the Thesaurus. Only those codes used to factor the foods contained in the LanguaL Factor file are included in this file
        /// </summary>
        public string FactorCode { get; set; }

        /// <summary>
        /// The description of the LanguaL Factor Code from the thesaurus
        /// </summary>
        public string Description { get; set; }
    }
}
