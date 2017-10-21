namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// Nutrient Data File (file name = NUT_DATA). This file (Table 8) contains the nutrient values and
    /// information about the values, including expanded statistical information.
    /// </summary>
    public class NutrientData
    {
        /// <summary>
        /// 5-digit Nutrient Databank number
        /// </summary>
        public int NDBNo { get; set; }

        /// <summary>
        /// Unique 3-digit identifier code for a nutrient.
        /// </summary>
        public int NutrNo { get; set; }

        /// <summary>
        /// Amount in 100 grams, edible portion †.
        /// </summary>
        public string NutrVal { get; set; }

        /// <summary>
        /// Number of data points (previously called Sample_Ct) is the number of analyses used to calculate the nutrient value. If the number of data points is 0, the value was calculated or imputed.
        /// </summary>
        public string NumDataPts { get; set; }

        /// <summary>
        /// Standard error of the mean. Null if cannot be calculated. The standard error is also not given if the number of data points is less than three.
        /// </summary>
        public string StdError { get; set; }

        /// <summary>
        /// Code indicating type of data.
        /// </summary>
        public string SrcCd { get; set; }

        /// <summary>
        /// Data Derivation Code giving specific information on how the value is determined
        /// </summary>
        public string DerivCd { get; set; }

        /// <summary>
        /// NDB number of the item used to calculate a missing value. Populated only for items added or updated starting with SR14.
        /// </summary>
        public string RefNDBNo { get; set; }

        /// <summary>
        /// Indicates a vitamin or mineral added for fortification or enrichment. This field is populated for ready-to-eat breakfast cereals and many brand-name hot cereals in food group 8.
        /// </summary>
        public string AddNutrMark { get; set; }

        /// <summary>
        /// Number of studies.
        /// </summary>
        public string NumStudies { get; set; }

        /// <summary>
        /// Minimum value.
        /// </summary>
        public string Min { get; set; }

        /// <summary>
        /// Maximum value.
        /// </summary>
        public string Max { get; set; }

        /// <summary>
        /// Degrees of freedom.
        /// </summary>
        public string DF { get; set; }

        /// <summary>
        /// Lower 95% error bound.
        /// </summary>
        public string LowEB { get; set; }

        /// <summary>
        /// Upper 95% error bound.
        /// </summary>
        public string UpEB { get; set; }

        /// <summary>
        /// Statistical comments. See definitions below.
        /// </summary>
        public string StatCmt { get; set; }

        /// <summary>
        /// Indicates when a value was either added to the database or last modified.
        /// </summary>
        public string AddModDate { get; set; }

        /// <summary>
        /// Confidence Code indicating data quality, based on evaluation of sample plan, sample handling, analytical method, analytical quality control, and number of samples analyzed. Not included in this release, but is planned for future releases.
        /// </summary>
        public string CC { get; set; }


    }

}
