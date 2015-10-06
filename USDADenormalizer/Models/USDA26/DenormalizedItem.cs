using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// A model of food item.
    /// Contains data from FoodDescription entity that is accompanied by data from other entities in USDA database.
    /// Set of properties that are available is arbitrary. This model does not guarantee that all available information
    /// related to FoodDescription item will be here, but attempts to include all that seems useful in typical scenarios.
    /// 
    /// Names of the properties in this model no longer reflect names in USDA database and accompanying documentation.
    /// Instead, they were chosen to be descriptive, and contain units in their name where appropriate, so the result
    /// should be easy to understand even without original documentation.
    /// 
    /// </summary>
    public class DenormalizedItem
    {
        /// <summary>
        /// Initialize item based on FoodDescription element.
        /// Copy (and parse when appropriate) data about the food item to this object.
        /// </summary>
        /// <param name="foodItem"></param>
        public DenormalizedItem(FoodDescription foodItem)
        {
            this.Name = foodItem.LongDescription;
            this.ScientificName = foodItem.SciName;
            this.CompanyName = foodItem.ManufacName;
            this.RefuseDescription = foodItem.RefDesc;
            this.RefusePercentage = foodItem.Refuse;

            decimal nFactor;
            if (Decimal.TryParse(foodItem.NFactor, NumberStyles.Any, CultureInfo.InvariantCulture, out nFactor))
            {
                this.NitrogenToProteinFactor = nFactor;
            }

            decimal proFactor;
            if (Decimal.TryParse(foodItem.ProFactor, NumberStyles.Any, CultureInfo.InvariantCulture, out proFactor))
            {
                this.ProteinToCaloriesFactor = proFactor;
            }

            decimal fatFactor;
            if (Decimal.TryParse(foodItem.FatFactor, NumberStyles.Any, CultureInfo.InvariantCulture, out fatFactor))
            {
                this.FatToCaloriesFactor = fatFactor;
            }

            decimal choFactor;
            if (Decimal.TryParse(foodItem.CHOFactor, NumberStyles.Any, CultureInfo.InvariantCulture, out choFactor))
            {
                this.CarbohydratesToCaloriesFactor = choFactor;
            }
        }

        /// <summary>
        /// Comes from LongDescription in FoodDescription
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Comes from SciName in FoodDescription
        /// </summary>
        public string ScientificName { get; set; }
        
        /// <summary>
        /// Energy in Kcal, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? EnergyKcal { get; set; }

        /// <summary>
        /// Proteins in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? ProteinGrams { get; set; }

        /// <summary>
        /// Fat in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? FatGrams { get; set; }

        /// <summary>
        /// Carbohydrates in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? CarbohydrateGrams { get; set; }

        /// <summary>
        /// Ash in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? AshGrams { get; set; }

        /// <summary>
        /// Comes from FdGrpDesc in FoodGroupDescription
        /// </summary>
        public string FoodGroupName { get; set; }

        /// <summary>
        /// Comes from ManufacName in FoodDescription
        /// </summary>
        public string CompanyName { get; set; }
        
        /// <summary>
        /// Comes from RefDesc in FoodDescription
        /// </summary>
        public string RefuseDescription { get; set; }

        /// <summary>
        /// Comes from Refuse in FoodDescription
        /// </summary>
        public string RefusePercentage { get; set; }

        /// <summary>
        /// Comes from NFactor in FoodDescription
        /// </summary>
        public decimal? NitrogenToProteinFactor { get; set; }

        /// <summary>
        /// Comes from ProFactor in FoodDescription
        /// </summary>
        public decimal? ProteinToCaloriesFactor { get; set; }
        
        /// <summary>
        /// Comes from FatFactor in FoodDescription
        /// </summary>
        public decimal? FatToCaloriesFactor { get; set; }

        /// <summary>
        /// Comes from CHOFactor in FoodDescription
        /// </summary>
        public decimal? CarbohydratesToCaloriesFactor { get; set; }
        
    
    }
}
