using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Stores combined data from few USDA tables, containing denormalized information about nutrients in foods.
    ///     Performs all the logic that is necessary to construct flat table model of the data based on originar database
    ///     structure.
    /// </summary>
    public class DenormalizedModel
    {
        /// <summary>
        ///     Flat representation of food items information in database
        /// </summary>
        public readonly IList<DenormalizedItem> FoodItems = new List<DenormalizedItem>();

        /// <summary>
        ///     This function builds flat model for food item with arbitrarily-chosen set of data.
        ///     It indends to cover most important values for each food item, but it does not guarantee that all
        ///     associated data will be represented in this model.
        /// </summary>
        /// <param name="dbModel"></param>
        public DenormalizedModel(DatabaseRepresentation dbModel)
        {
            // Dictionaries for interesting nutrients (for performance)
            var nutrDictionaries = GetNutrientDictionaries(
                dbModel);

            // Food group dictionary (for performance)
            var foodGrpIdToName = dbModel.foodGroupDescription.ToDictionary(g => g.FdGrpCd, g => g.FdGrpDesc);

            // From FoodDescription
            foreach (var foodItm in dbModel.foodDescription /*.Take(5)*/) // Take() for fast debugging
            {
                // Fill basic values about food item from FOodDescription entity
                var flatItem = new DenormalizedItem(foodItm);

                // Fill food group details from FoodGroup entity
                flatItem.FoodGroupName = foodGrpIdToName[foodItm.FoodGroup];

                // Find nutrient values
                // In this place data fron NUTR_DEF entity that has a generic structure in DB is placed in strongly-typed fields of DenormalizedItem, thus necessity to use nutrient identifiers in the code
                var foodId = foodItm.NutrientDatabankNumber;
                flatItem.Protein_Grams = TryGetDecimal(nutrDictionaries[203], foodId);
                flatItem.Fat_Grams = TryGetDecimal(nutrDictionaries[204], foodId);
                flatItem.Carbohydrate_Grams = TryGetDecimal(nutrDictionaries[205], foodId);
                flatItem.Ash_Grams = TryGetDecimal(nutrDictionaries[207], foodId);
                flatItem.Energy_Kcal = TryGetDecimal(nutrDictionaries[208], foodId);
                flatItem.Starch_Grams = TryGetDecimal(nutrDictionaries[209], foodId);
                flatItem.Sucrose_Grams = TryGetDecimal(nutrDictionaries[210], foodId);
                flatItem.Glucose_Grams = TryGetDecimal(nutrDictionaries[211], foodId);
                flatItem.Fructose_Grams = TryGetDecimal(nutrDictionaries[212], foodId);
                flatItem.Lactose_Grams = TryGetDecimal(nutrDictionaries[213], foodId);
                flatItem.Maltose_Grams = TryGetDecimal(nutrDictionaries[214], foodId);
                flatItem.AlcoholEthyl_Grams = TryGetDecimal(nutrDictionaries[221], foodId);
                flatItem.Water_Grams = TryGetDecimal(nutrDictionaries[255], foodId);
                flatItem.AdjustedProtein_Grams = TryGetDecimal(nutrDictionaries[257], foodId);
                flatItem.Caffeine_Mg = TryGetDecimal(nutrDictionaries[262], foodId);
                flatItem.Theoboromine_Mg = TryGetDecimal(nutrDictionaries[263], foodId);
                flatItem.Energy_KJ = TryGetDecimal(nutrDictionaries[268], foodId);
                flatItem.Sugar_Grams = TryGetDecimal(nutrDictionaries[269], foodId);
                flatItem.Galactose_Grams = TryGetDecimal(nutrDictionaries[287], foodId);
                flatItem.FiberTotalDietary_Grams = TryGetDecimal(nutrDictionaries[291], foodId);
                flatItem.Calcium_Mg = TryGetDecimal(nutrDictionaries[301], foodId);
                flatItem.Iron_Mg = TryGetDecimal(nutrDictionaries[303], foodId);
                flatItem.Magnesium_Mg = TryGetDecimal(nutrDictionaries[304], foodId);
                flatItem.Phosphorus_Mg = TryGetDecimal(nutrDictionaries[305], foodId);
                flatItem.Potassium_Mg = TryGetDecimal(nutrDictionaries[306], foodId);
                flatItem.Sodium_Mg = TryGetDecimal(nutrDictionaries[307], foodId);
                flatItem.Zinc_Mg = TryGetDecimal(nutrDictionaries[309], foodId);
                flatItem.Copper_Mg = TryGetDecimal(nutrDictionaries[312], foodId);
                flatItem.Fluorite_Ug = TryGetDecimal(nutrDictionaries[313], foodId);
                flatItem.Manganese_Mg = TryGetDecimal(nutrDictionaries[315], foodId);
                flatItem.Selenium_Ug = TryGetDecimal(nutrDictionaries[317], foodId);
                flatItem.VitaminA_IU = TryGetDecimal(nutrDictionaries[318], foodId);
                flatItem.Retinol_Ug = TryGetDecimal(nutrDictionaries[319], foodId);
                flatItem.VitaminA_RAE = TryGetDecimal(nutrDictionaries[320], foodId);
                flatItem.CaroteneBeta_Ug = TryGetDecimal(nutrDictionaries[321], foodId);
                flatItem.CaroteneAlpha_Ug = TryGetDecimal(nutrDictionaries[322], foodId);
                flatItem.VitaminE_Mg = TryGetDecimal(nutrDictionaries[323], foodId);
                flatItem.VitaminD_IU = TryGetDecimal(nutrDictionaries[324], foodId);
                flatItem.VitaminD2_Ug = TryGetDecimal(nutrDictionaries[325], foodId);
                flatItem.VitaminD3_Ug = TryGetDecimal(nutrDictionaries[326], foodId);
                flatItem.VitaminD2D2Sum_Ug = TryGetDecimal(nutrDictionaries[328], foodId);
                flatItem.Cryptoxanthin_Ug = TryGetDecimal(nutrDictionaries[334], foodId);
                flatItem.Lycopene_Ug = TryGetDecimal(nutrDictionaries[337], foodId);
                flatItem.LuteinAndZeaxanthin_Ug = TryGetDecimal(nutrDictionaries[338], foodId);
                flatItem.TocopherolBeta_Mg = TryGetDecimal(nutrDictionaries[341], foodId);
                flatItem.TocopherolGamma_Mg = TryGetDecimal(nutrDictionaries[342], foodId);
                flatItem.TocopherolDelta_Mg = TryGetDecimal(nutrDictionaries[343], foodId);
                flatItem.TocotrienolAlpha_Mg = TryGetDecimal(nutrDictionaries[344], foodId);
                flatItem.TocotrienolBeta_Mg = TryGetDecimal(nutrDictionaries[345], foodId);
                flatItem.TocotrienolGamma_Mg = TryGetDecimal(nutrDictionaries[346], foodId);
                flatItem.TocotrienolDelta_Mg = TryGetDecimal(nutrDictionaries[347], foodId);
                flatItem.VitaminC_Mg = TryGetDecimal(nutrDictionaries[401], foodId);
                flatItem.Thiamin_Mg = TryGetDecimal(nutrDictionaries[404], foodId);
                flatItem.Riboflavin_Mg = TryGetDecimal(nutrDictionaries[405], foodId);
                flatItem.Niacin_Mg = TryGetDecimal(nutrDictionaries[406], foodId);
                flatItem.PantothenicAcid_Mg = TryGetDecimal(nutrDictionaries[410], foodId);
                flatItem.VitaminB6A_Mg = TryGetDecimal(nutrDictionaries[415], foodId);
                flatItem.FoliateTotal_Ug = TryGetDecimal(nutrDictionaries[417], foodId);
                flatItem.VitaminB12_Ug = TryGetDecimal(nutrDictionaries[418], foodId);
                flatItem.CholineTotalMg = TryGetDecimal(nutrDictionaries[421], foodId);
                flatItem.Menaquinone4_Ug = TryGetDecimal(nutrDictionaries[428], foodId);
                flatItem.Dihydrophylloquinone_Ug = TryGetDecimal(nutrDictionaries[429], foodId);
                flatItem.VitaminK_Ug = TryGetDecimal(nutrDictionaries[430], foodId);
                flatItem.FolicAcid_Ug = TryGetDecimal(nutrDictionaries[431], foodId);
                flatItem.FolateFood_Ug = TryGetDecimal(nutrDictionaries[432], foodId);
                flatItem.FolateDFE_Ug = TryGetDecimal(nutrDictionaries[435], foodId);
                flatItem.Betaine_Mg = TryGetDecimal(nutrDictionaries[454], foodId);
                flatItem.Tryptophan_Grams = TryGetDecimal(nutrDictionaries[501], foodId);
                flatItem.Threonine_Grams = TryGetDecimal(nutrDictionaries[502], foodId);
                flatItem.Isoleucine_Grams = TryGetDecimal(nutrDictionaries[503], foodId);
                flatItem.Leucine_Grams = TryGetDecimal(nutrDictionaries[504], foodId);
                flatItem.Lysine_Grams = TryGetDecimal(nutrDictionaries[505], foodId);
                flatItem.Methionine_Grams = TryGetDecimal(nutrDictionaries[506], foodId);
                flatItem.Cystine_Grams = TryGetDecimal(nutrDictionaries[507], foodId);
                flatItem.Phenylalanine_Grams = TryGetDecimal(nutrDictionaries[508], foodId);
                flatItem.Tyrosine_Grams = TryGetDecimal(nutrDictionaries[509], foodId);
                flatItem.Valine_Grams = TryGetDecimal(nutrDictionaries[510], foodId);
                flatItem.Arginine_Grams = TryGetDecimal(nutrDictionaries[511], foodId);
                flatItem.Histidine_Grams = TryGetDecimal(nutrDictionaries[512], foodId);
                flatItem.Alanine_Grams = TryGetDecimal(nutrDictionaries[513], foodId);
                flatItem.AsparticAcid_Grams = TryGetDecimal(nutrDictionaries[514], foodId);
                flatItem.GlutamicAcid_Grams = TryGetDecimal(nutrDictionaries[515], foodId);
                flatItem.Glycine_Grams = TryGetDecimal(nutrDictionaries[516], foodId);
                flatItem.Proline_Grams = TryGetDecimal(nutrDictionaries[517], foodId);
                flatItem.Serine_Grams = TryGetDecimal(nutrDictionaries[518], foodId);
                flatItem.Hydroxyproline_Grams = TryGetDecimal(nutrDictionaries[521], foodId);
                flatItem.VitaminEAdded_Mg = TryGetDecimal(nutrDictionaries[573], foodId);
                flatItem.VitaminB12Added_Ug = TryGetDecimal(nutrDictionaries[578], foodId);
                flatItem.Cholesterol_Mg = TryGetDecimal(nutrDictionaries[601], foodId);
                flatItem.FattyAcidsTotalTrans_Grams = TryGetDecimal(nutrDictionaries[605], foodId);
                flatItem.FattyAcidsTotalSaturated_Grams = TryGetDecimal(nutrDictionaries[606], foodId);
                flatItem.F4D0_Grams = TryGetDecimal(nutrDictionaries[607], foodId);
                flatItem.F6D0_Grams = TryGetDecimal(nutrDictionaries[608], foodId);
                flatItem.F8D0_Grams = TryGetDecimal(nutrDictionaries[609], foodId);
                flatItem.F10D0_Grams = TryGetDecimal(nutrDictionaries[610], foodId);
                flatItem.F12D0_Grams = TryGetDecimal(nutrDictionaries[611], foodId);
                flatItem.F14D0_Grams = TryGetDecimal(nutrDictionaries[612], foodId);
                flatItem.F16D0_Grams = TryGetDecimal(nutrDictionaries[613], foodId);
                flatItem.F18D0_Grams = TryGetDecimal(nutrDictionaries[614], foodId);
                flatItem.F20D0_Grams = TryGetDecimal(nutrDictionaries[615], foodId);
                flatItem.F18D1_Grams = TryGetDecimal(nutrDictionaries[617], foodId);
                flatItem.F18D2_Grams = TryGetDecimal(nutrDictionaries[618], foodId);
                flatItem.F18D3_Grams = TryGetDecimal(nutrDictionaries[619], foodId);
                flatItem.F20D4_Grams = TryGetDecimal(nutrDictionaries[620], foodId);
                flatItem.F22D6_Grams = TryGetDecimal(nutrDictionaries[621], foodId);
                flatItem.F22D0_Grams = TryGetDecimal(nutrDictionaries[624], foodId);
                flatItem.F14D1_Grams = TryGetDecimal(nutrDictionaries[625], foodId);
                flatItem.F16D1_Grams = TryGetDecimal(nutrDictionaries[626], foodId);
                flatItem.F18D4_Grams = TryGetDecimal(nutrDictionaries[627], foodId);
                flatItem.F20D1_Grams = TryGetDecimal(nutrDictionaries[628], foodId);
                flatItem.F20D5_Grams = TryGetDecimal(nutrDictionaries[629], foodId);
                flatItem.F22D1_Grams = TryGetDecimal(nutrDictionaries[630], foodId);
                flatItem.F22D5_Grams = TryGetDecimal(nutrDictionaries[631], foodId);
                flatItem.Phytosterols_Mg = TryGetDecimal(nutrDictionaries[636], foodId);
                flatItem.Stigmasterol_Mg = TryGetDecimal(nutrDictionaries[638], foodId);
                flatItem.Campesterol_Mg = TryGetDecimal(nutrDictionaries[639], foodId);
                flatItem.BetaSitosterol_Mg = TryGetDecimal(nutrDictionaries[641], foodId);
                flatItem.FattyAcidsTotalMonounsaturated_Grams = TryGetDecimal(nutrDictionaries[645], foodId);
                flatItem.FattyAcidsTotalPolyunsaturated_Grams = TryGetDecimal(nutrDictionaries[646], foodId);
                flatItem.F15D0_Grams = TryGetDecimal(nutrDictionaries[652], foodId);
                flatItem.F17D0_Grams = TryGetDecimal(nutrDictionaries[653], foodId);
                flatItem.F24D0_Grams = TryGetDecimal(nutrDictionaries[654], foodId);
                flatItem.F16D1T_Grams = TryGetDecimal(nutrDictionaries[662], foodId);
                flatItem.F18D1T_Grams = TryGetDecimal(nutrDictionaries[663], foodId);
                flatItem.F22D1T_Grams = TryGetDecimal(nutrDictionaries[664], foodId);
                flatItem.T18to2NotFurtherDefined_Grams = TryGetDecimal(nutrDictionaries[665], foodId);
                flatItem.I18to2_Grams = TryGetDecimal(nutrDictionaries[666], foodId);
                flatItem.F18D2TT_Grams = TryGetDecimal(nutrDictionaries[669], foodId);
                flatItem.F18D2CLA_Grams = TryGetDecimal(nutrDictionaries[670], foodId);
                flatItem.F24D1C_Grams = TryGetDecimal(nutrDictionaries[671], foodId);
                flatItem.F20D2CN6_Grams = TryGetDecimal(nutrDictionaries[672], foodId);
                flatItem.F16D1C_Grams = TryGetDecimal(nutrDictionaries[673], foodId);
                flatItem.F18D1C_Grams = TryGetDecimal(nutrDictionaries[674], foodId);
                flatItem.F18D2CN6_Grams = TryGetDecimal(nutrDictionaries[675], foodId);
                flatItem.F22D1C_Grams = TryGetDecimal(nutrDictionaries[676], foodId);
                flatItem.F18D3CN6_Grams = TryGetDecimal(nutrDictionaries[685], foodId);
                flatItem.F17D1_Grams = TryGetDecimal(nutrDictionaries[687], foodId);
                flatItem.F20D3_Grams = TryGetDecimal(nutrDictionaries[689], foodId);
                flatItem.FATRNM_Grams = TryGetDecimal(nutrDictionaries[693], foodId);
                flatItem.FATRNP_Grams = TryGetDecimal(nutrDictionaries[695], foodId);
                flatItem.F13D0_Grams = TryGetDecimal(nutrDictionaries[696], foodId);
                flatItem.F15D1_Grams = TryGetDecimal(nutrDictionaries[697], foodId);
                flatItem.F18D3CN3_Grams = TryGetDecimal(nutrDictionaries[851], foodId);
                flatItem.F20D3N3_Grams = TryGetDecimal(nutrDictionaries[852], foodId);
                flatItem.F20D3N6_Grams = TryGetDecimal(nutrDictionaries[853], foodId);
                flatItem.F20D4N6_Grams = TryGetDecimal(nutrDictionaries[855], foodId);
                flatItem.I18to3_Grams = TryGetDecimal(nutrDictionaries[856], foodId);
                flatItem.F21D5_Grams = TryGetDecimal(nutrDictionaries[857], foodId);
                flatItem.F22D4_Grams = TryGetDecimal(nutrDictionaries[858], foodId);
                flatItem.F18D1TN7_Grams = TryGetDecimal(nutrDictionaries[859], foodId);

                FoodItems.Add(flatItem);
            }
        }

        /// <summary>
        ///     Builds a dictionary of dictionaries for all types of nutrients found in NutrientDefinition table.
        ///     This is done purely for performance reasons, as looking up in dictionaries for each product is faster than
        ///     repeating LINQ queries.
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        private Dictionary<int, Dictionary<int, string>> GetNutrientDictionaries(DatabaseRepresentation dbModel)
        {
            var dictionaries = new Dictionary<int, Dictionary<int, string>>();

            foreach (var nutrient in dbModel.nutrientDefinition)
            {
                // using description as key, because Tagname is neither unique nor required
                var nutrientDict = GetNutrientDict(dbModel, nutrient.NutrNo);
                dictionaries.Add(nutrient.NutrNo, nutrientDict);
            }

            return dictionaries;
        }


        /// <summary>
        ///     Returns dictionary mapping Food item (from Food description entity) to desired nutrient's value
        /// </summary>
        /// <param name="dbModel">Initialized USDA26 database model</param>
        /// <param name="nutrNo">ID of nutrient which value should be put as dictionary values</param>
        /// <returns></returns>
        private Dictionary<int, string> GetNutrientDict(DatabaseRepresentation dbModel, int nutrNo)
        {
            // Get the numeric identifier for a given nutrient
            var nutrientNumber = dbModel.nutrientDefinition.Where(nd => nd.NutrNo == nutrNo).FirstOrDefault().NutrNo;

            // Build a dictionary
            // ReSharper disable once InconsistentNaming
            var nutrientNDBNoToValue = dbModel.nutrientData
                .Where(nut => nut.NutrNo == nutrientNumber)
                .ToDictionary(x => x.NDBNo, x => x.NutrVal);

            return nutrientNDBNoToValue;
        }

        /// <summary>
        ///     Attempts to get a value from a dictionary and parse is as decimal.
        /// </summary>
        /// <typeparam name="T1">Dictionary key type</typeparam>
        /// <param name="dict">Dictionary to search value for</param>
        /// <param name="key">Key in the provided dictionary to look for</param>
        /// <returns>Parsed decimal or null in case of no success</returns>
        private decimal? TryGetDecimal<T1>(Dictionary<T1, string> dict, T1 key)
        {
            if (!dict.TryGetValue(key, out var dictValue)) return null;
            if (dictValue == null) return null;

            if (!decimal.TryParse(dictValue,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out var dictValDecimal))
                return null;

            return dictValDecimal;
        }
    }
}