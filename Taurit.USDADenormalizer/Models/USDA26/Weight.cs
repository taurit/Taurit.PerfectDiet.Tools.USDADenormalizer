using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// Weight File (file name = WEIGHT). This file (Table 12) contains the weight in grams of a number of
    /// common measures for each food item.
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// 5-digit Nutrient Databank number.
        /// </summary>
        public string NDBNum { get; set; }

        /// <summary>
        /// Sequence number.
        /// </summary>
        public string Seq { get; set; }

        /// <summary>
        /// Unit modifier (for example, 1 in “1 cup”).
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Description (for example, cup, diced, and 1-inch pieces).
        /// </summary>
        public string MsreDesc { get; set; }

        /// <summary>
        /// Gram weight.
        /// </summary>
        public string GmWgt { get; set; }

        /// <summary>
        /// Number of data points.
        /// </summary>
        public string NumDataPts { get; set; }

        /// <summary>
        /// Standard deviation.
        /// </summary>
        public string StdDev { get; set; }

    }

}
