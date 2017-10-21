namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Food Group Description File (file name = FD_GROUP). This file (Table 5) is a support file to the
    ///     Food Description file and contains a list of food groups used in SR26 and their descriptions.
    /// </summary>
    public class FoodGroupDescription
    {
        /// <summary>
        ///     4-digit code identifying a food group. Only the first 2 digits are currently assigned. In the future, the last 2
        ///     digits may be used. Codes may not be consecutive.
        /// </summary>
        public int FdGrpCd { get; set; }

        /// <summary>
        ///     Name of food group.
        /// </summary>
        public string FdGrpDesc { get; set; }
    }
}