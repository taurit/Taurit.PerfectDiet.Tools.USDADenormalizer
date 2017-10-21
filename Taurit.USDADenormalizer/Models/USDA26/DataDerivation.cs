namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Data Derivation Code Description File  (file name = DERIV_CD). This file (Table 11) provides
    ///     information on how the nutrient values were determined. The file contains the derivation codes
    ///     and their descriptions
    /// </summary>
    public class DataDerivation
    {
        /// <summary>
        ///     Derivation Code.
        /// </summary>
        public string DerivCd { get; set; }

        /// <summary>
        ///     Description of derivation code giving specific information on how the value was determined.
        /// </summary>
        public string DerivDesc { get; set; }
    }
}