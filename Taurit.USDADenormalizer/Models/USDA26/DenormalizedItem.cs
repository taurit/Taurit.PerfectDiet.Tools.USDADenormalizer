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
        public decimal? Energy_Kcal { get; set; }

        /// <summary>
        /// Proteins in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? Protein_Grams { get; set; }

        /// <summary>
        /// Fat in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? Fat_Grams { get; set; }

        /// <summary>
        /// Carbohydrates in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? Carbohydrate_Grams { get; set; }

        /// <summary>
        /// Ash in g/100g, comes from Nutrient definition->Nutrient data
        /// </summary>
        public decimal? Ash_Grams { get; set; }

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
        public decimal? Starch_Grams { get; internal set; }
        public decimal? Sucrose_Grams { get; internal set; }
        public decimal? Glucose_Grams { get; internal set; }
        public decimal? Fructose_Grams { get; internal set; }
        public decimal? Lactose_Grams { get; internal set; }
        public decimal? Maltose_Grams { get; internal set; }
        public decimal? AlcoholEthyl_Grams { get; internal set; }
        public decimal? Water_Grams { get; internal set; }
        public decimal? AdjustedProtein_Grams { get; internal set; }
        public decimal? Caffeine_Mg { get; internal set; }
        public decimal? Theoboromine_Mg { get; internal set; }
        public decimal? Energy_KJ { get; internal set; }
        public decimal? Sugar_Grams { get; internal set; }
        public decimal? Galactose_Grams { get; internal set; }
        public decimal? FiberTotalDietary_Grams { get; internal set; }
        public decimal? Calcium_Mg { get; internal set; }
        public decimal? Iron_Mg { get; internal set; }
        public decimal? Magnesium_Mg { get; internal set; }
        public decimal? Phosphorus_Mg { get; internal set; }
        public decimal? Potassium_Mg { get; internal set; }
        public decimal? Sodium_Mg { get; internal set; }
        public decimal? Zinc_Mg { get; internal set; }
        public decimal? Copper_Mg { get; internal set; }
        public decimal? Fluorite_Ug { get; internal set; }
        public decimal? Manganese_Mg { get; internal set; }
        public decimal? Selenium_Ug { get; internal set; }
        public decimal? VitaminA_IU { get; internal set; }
        public decimal? Retinol_Ug { get; internal set; }
        public decimal? VitaminA_RAE { get; internal set; }
        public decimal? CaroteneBeta_Ug { get; internal set; }
        public decimal? CaroteneAlpha_Ug { get; internal set; }
        public decimal? VitaminE_Mg { get; internal set; }
        public decimal? VitaminD_IU { get; internal set; }
        public decimal? VitaminD2_Ug { get; internal set; }
        public decimal? VitaminD3_Ug { get; internal set; }
        public decimal? VitaminD2D2Sum_Ug { get; internal set; }
        public decimal? Cryptoxanthin_Ug { get; internal set; }
        public decimal? Lycopene_Ug { get; internal set; }
        public decimal? LuteinAndZeaxanthin_Ug { get; internal set; }
        public decimal? TocopherolBeta_Mg { get; internal set; }
        public decimal? TocopherolGamma_Mg { get; internal set; }
        public decimal? TocopherolDelta_Mg { get; internal set; }
        public decimal? TocotrienolAlpha_Mg { get; internal set; }
        public decimal? TocotrienolBeta_Mg { get; internal set; }
        public decimal? TocotrienolGamma_Mg { get; internal set; }
        public decimal? TocotrienolDelta_Mg { get; internal set; }
        public decimal? VitaminC_Mg { get; internal set; }
        public decimal? Thiamin_Mg { get; internal set; }
        public decimal? Riboflavin_Mg { get; internal set; }
        public decimal? Niacin_Mg { get; internal set; }
        public decimal? PantothenicAcid_Mg { get; internal set; }
        public decimal? VitaminB6A_Mg { get; internal set; }
        public decimal? FoliateTotal_Ug { get; internal set; }
        public decimal? VitaminB12_Mg { get; internal set; }
        public decimal? CholineTotalMg { get; internal set; }
        public decimal? Menaquinone4_Ug { get; internal set; }
        public decimal? Dihydrophylloquinone_Ug { get; internal set; }
        public decimal? VitaminK_Ug { get; internal set; }
        public decimal? FolicAcid_Ug { get; internal set; }
        public decimal? FolateFood_Ug { get; internal set; }
        public decimal? FolateDFE_Ug { get; internal set; }
        public decimal? Betaine_Mg { get; internal set; }
        public decimal? Tryptophan_Grams { get; internal set; }
        public decimal? Threonine_Grams { get; internal set; }
        public decimal? Isoleucine_Grams { get; internal set; }
        public decimal? Leucine_Grams { get; internal set; }
        public decimal? Lysine_Grams { get; internal set; }
        public decimal? Methionine_Grams { get; internal set; }
        public decimal? Cystine_Grams { get; internal set; }
        public decimal? Phenylalanine_Grams { get; internal set; }
        public decimal? Tyrosine_Grams { get; internal set; }
        public decimal? Valine_Grams { get; internal set; }
        public decimal? Arginine_Grams { get; internal set; }
        public decimal? Histidine_Grams { get; internal set; }
        public decimal? Alanine_Grams { get; internal set; }
        public decimal? AsparticAcid_Grams { get; internal set; }
        public decimal? GlutamicAcid_Grams { get; internal set; }
        public decimal? Glycine_Grams { get; internal set; }
        public decimal? Proline_Grams { get; internal set; }
        public decimal? Serine_Grams { get; internal set; }
        public decimal? Hydroxyproline_Grams { get; internal set; }
        public decimal? VitaminEAdded_Mg { get; internal set; }
        public decimal? VitaminB12Added_Mg { get; internal set; }
        public decimal? Cholesterol_Mg { get; internal set; }
        public decimal? FattyAcidsTotalTrans_Grams { get; internal set; }
        public decimal? FattyAcidsTotalSaturated_Grams { get; internal set; }
        public decimal? F4D0_Grams { get; internal set; }
        public decimal? F6D0_Grams { get; internal set; }
        public decimal? F8D0_Grams { get; internal set; }
        public decimal? F10D0_Grams { get; internal set; }
        public decimal? F12D0_Grams { get; internal set; }
        public decimal? F14D0_Grams { get; internal set; }
        public decimal? F16D0_Grams { get; internal set; }
        public decimal? F18D0_Grams { get; internal set; }
        public decimal? F20D0_Grams { get; internal set; }
        public decimal? F18D1_Grams { get; internal set; }
        public decimal? F18D2_Grams { get; internal set; }
        public decimal? F18D3_Grams { get; internal set; }
        public decimal? F20D4_Grams { get; internal set; }
        public decimal? F22D6_Grams { get; internal set; }
        public decimal? F22D0_Grams { get; internal set; }
        public decimal? F14D1_Grams { get; internal set; }
        public decimal? F16D1_Grams { get; internal set; }
        public decimal? F18D4_Grams { get; internal set; }
        public decimal? F20D1_Grams { get; internal set; }
        public decimal? F20D5_Grams { get; internal set; }
        public decimal? F22D1_Grams { get; internal set; }
        public decimal? F22D5_Grams { get; internal set; }
        public decimal? Phytosterols_Mg { get; internal set; }
        public decimal? Stigmasterol_Mg { get; internal set; }
        public decimal? Campesterol_Mg { get; internal set; }
        public decimal? BetaSitosterol_Mg { get; internal set; }
        public decimal? FattyAcidsTotalMonounsaturated_Grams { get; internal set; }
        public decimal? FattyAcidsTotalPolyunsaturated_Grams { get; internal set; }
        public decimal? F15D0_Grams { get; internal set; }
        public decimal? F17D0_Grams { get; internal set; }
        public decimal? F24D0_Grams { get; internal set; }
        public decimal? F16D1T_Grams { get; internal set; }
        public decimal? F18D1T_Grams { get; internal set; }
        public decimal? F22D1T_Grams { get; internal set; }
        public decimal? F18D2TT_Grams { get; internal set; }
        public decimal? F18D2CLA_Grams { get; internal set; }
        public decimal? F24D1C_Grams { get; internal set; }
        public decimal? F20D2CN6_Grams { get; internal set; }
        public decimal? F16D1C_Grams { get; internal set; }
        public decimal? F18D1C_Grams { get; internal set; }
        public decimal? F18D2CN6_Grams { get; internal set; }
        public decimal? F22D1C_Grams { get; internal set; }
        public decimal? F18D3CN6_Grams { get; internal set; }
        public decimal? F17D1_Grams { get; internal set; }
        public decimal? F20D3_Grams { get; internal set; }
        public decimal? FATRNM_Grams { get; internal set; }
        public decimal? FATRNP_Grams { get; internal set; }
        public decimal? F13D0_Grams { get; internal set; }
        public decimal? F15D1_Grams { get; internal set; }
        public decimal? F18D3CN3_Grams { get; internal set; }
        public decimal? F20D3N3_Grams { get; internal set; }
        public decimal? F20D3N6_Grams { get; internal set; }
        public decimal? F20D4N6_Grams { get; internal set; }
        public decimal? F21D5_Grams { get; internal set; }
        public decimal? F22D4_Grams { get; internal set; }
        public decimal? F18D1TN7_Grams { get; internal set; }
        public decimal? I18to2_Grams { get; internal set; }
        public decimal? T18to2NotFurtherDefined_Grams { get; internal set; }
        public decimal? I18to3_Grams { get; internal set; }
    }
}
