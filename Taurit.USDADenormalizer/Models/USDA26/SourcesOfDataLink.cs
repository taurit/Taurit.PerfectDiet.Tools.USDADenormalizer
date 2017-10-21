namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Sources of Data Link File (file name = DATSRCLN). This file (Table 14) is used to link the Nutrient Data
    ///     file with the Sources of Data table. It is needed to resolve the many-tomany relationship between the two tables.
    /// </summary>
    public class SourcesOfDataLink
    {
        /// <summary>
        ///     5-digit Nutrient Databank number.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string NDBNo { get; set; }

        /// <summary>
        ///     Unique 3-digit identifier code for a nutrient
        /// </summary>
        public string NutrNo { get; set; }

        /// <summary>
        ///     Unique ID identifying the reference/source.
        /// </summary>
        public string DataSrcId { get; set; }
    }
}