namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Food Description File (file name = FOOD_DES). This file (Table 4) contains long and short descriptions
    ///     and food group designators for 8,463 food items, along with common names, manufacturer name, scientific name,
    ///     percentage and description of refuse, and factors used for calculating protein and kilocalories, if applicable.
    ///     Items used in the FNDDS are also identified by value of “Y” in the Survey field.
    /// </summary>
    public class FoodDescription
    {
        /// <summary>
        ///     5-digit Nutrient Databank number that uniquely identifies a food item. If this field is defined as numeric, the
        ///     leading zero will be lost.
        /// </summary>
        public int NutrientDatabankNumber { get; set; }

        /// <summary>
        ///     4-digit code indicating food group to which a food item belongs
        /// </summary>
        public int FoodGroup { get; set; }

        /// <summary>
        ///     200-character description of food item.
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        ///     60-character abbreviated description of food item. Generated from the 200-character description using abbreviations
        ///     in Appendix A. If short description is longer than 60 characters, additional abbreviations are made.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        ///     Other names commonly used to describe a food, including local or regional names for various foods, for example,
        ///     “soda” or “pop” for “carbonated beverages.”
        /// </summary>
        public string CornName { get; set; }

        /// <summary>
        ///     Indicates the company that manufactured the product, when appropriate.
        /// </summary>
        public string ManufacName { get; set; }

        /// <summary>
        ///     Indicates if the food item is used in the USDA Food and Nutrient Database for Dietary Studies (FNDDS) and thus has
        ///     a complete nutrient profile for the 65 FNDDS nutrients.
        /// </summary>
        public string Survey { get; set; }

        /// <summary>
        ///     Description of inedible parts of a food item (refuse), such as seeds or bone
        /// </summary>
        public string RefDesc { get; set; }

        /// <summary>
        ///     Percentage of refuse.
        /// </summary>
        public string Refuse { get; set; }

        /// <summary>
        ///     Scientific name of the food item. Given for the least processed form of the food (usually raw), if applicable.
        /// </summary>
        public string SciName { get; set; }

        /// <summary>
        ///     Factor for converting nitrogen to protein (see p. 12).
        /// </summary>
        public string NFactor { get; set; }

        /// <summary>
        ///     Factor for calculating calories from protein (see p. 13).
        /// </summary>
        public string ProFactor { get; set; }

        /// <summary>
        ///     Factor for calculating calories from fat (see p. 13).
        /// </summary>
        public string FatFactor { get; set; }

        /// <summary>
        ///     Factor for calculating calories from carbohydrate (see p. 13).
        /// </summary>
        public string CHOFactor { get; set; }
    }
}