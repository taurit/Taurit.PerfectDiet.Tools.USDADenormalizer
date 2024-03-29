﻿namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Source Code File (file name = SRC_CD). This file (Table 10) contains codes indicating the type of data
    ///     (analytical, calculated, assumed zero, and so on) in the Nutrient Data file. To improve the usability
    ///     of the database and to provide values for the FNDDS, NDL staff imputed nutrient values for a number
    ///     of proximate components, total dietary fiber, total sugar, and vitamin and mineral values.
    /// </summary>
    public class SourceCode
    {
        /// <summary>
        ///     2-digit code.
        /// </summary>
        public string SrcCd { get; set; }

        /// <summary>
        ///     Description of source code that identifies the type of nutrient data.
        /// </summary>
        public string SrcCdDesc { get; set; }
    }
}