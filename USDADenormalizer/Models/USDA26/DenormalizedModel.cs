using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// Stores combined data from few USDA tables, containing denormalized information about nutrients in foods.
    /// Performs all the logic that is necessary to construct flat table model of the data based on originar database structure.
    /// </summary>
    public class DenormalizedModel
    {
        /// <summary>
        /// Reference to original USDA Nutrient database model, with entity and property names as in documentation
        /// </summary>
        private DatabaseRepresentation dbModel;

        /// <summary>
        /// Flat representation of food items information in database
        /// </summary>
        public IList<DenormalizedItem> FoodItems = new List<DenormalizedItem>();
        
        /// <summary>
        /// This function builds flat model for food item with arbitrarily-chosen set of data. 
        /// It indends to cover most important values for each food item, but it does not guarantee that all
        /// associated data will be represented in this model.
        /// </summary>
        /// <param name="dbModel"></param>
        public DenormalizedModel(DatabaseRepresentation dbModel)
        {
            this.dbModel = dbModel;

            // Get IDs for interesting nutrients
            int idProtein = dbModel.nutrientDefinition.Where(nd => nd.Tagname == "PROCNT").FirstOrDefault().NutrNo;
            int idFat = dbModel.nutrientDefinition.Where(nd => nd.Tagname == "FAT").FirstOrDefault().NutrNo;
            int idCarbo = dbModel.nutrientDefinition.Where(nd => nd.Tagname == "CHOCDF").FirstOrDefault().NutrNo;
            int idAsh = dbModel.nutrientDefinition.Where(nd => nd.Tagname == "ASH").FirstOrDefault().NutrNo;
            int idEnergy = dbModel.nutrientDefinition.Where(nd => nd.Tagname == "ENERC_KCAL").FirstOrDefault().NutrNo;

            // Dictionaries for interesting nutrients (for performance)
            Dictionary<int, string> proteinNDBNoToValue = dbModel.nutrientData
                .Where(nut => nut.NutrNo == idProtein)
                .ToDictionary(x => x.NDBNo, x => x.NutrVal);
            Dictionary<int, string> fatNDBNoToValue = dbModel.nutrientData
                .Where(nut => nut.NutrNo == idFat)
                .ToDictionary(x => x.NDBNo, x => x.NutrVal);
            Dictionary<int, string> carNDBNoToValue = dbModel.nutrientData
                .Where(nut => nut.NutrNo == idCarbo)
                .ToDictionary(x => x.NDBNo, x => x.NutrVal);
            Dictionary<int, string> ashNDBNoToValue = dbModel.nutrientData
                .Where(nut => nut.NutrNo == idAsh)
                .ToDictionary(x => x.NDBNo, x => x.NutrVal);
            Dictionary<int, string> energyNDBNoToValue = dbModel.nutrientData
                .Where(nut => nut.NutrNo == idEnergy)
                .ToDictionary(x => x.NDBNo, x => x.NutrVal);

            // Food group dictionary (for performance)
            Dictionary<int, string> foodGrpIdToName = dbModel.foodGroupDescription.ToDictionary(g => g.FdGrpCd, g => g.FdGrpDesc);

            // From FoodDescription
            foreach (FoodDescription foodItm in dbModel.foodDescription/*.Take(5)*/) // Take() for fast debugging
            {
                // Fill basic values about food item from FOodDescription entity
                DenormalizedItem flatItem = new DenormalizedItem(foodItm);

                // Fill food group details from FoodGroup entity
                flatItem.FoodGroupName = foodGrpIdToName[foodItm.FoodGroup];

                // Find nutrient values
                int foodId = foodItm.NutrientDatabankNumber;
                flatItem.ProteinGrams = TryGetDecimal(proteinNDBNoToValue, foodId);
                flatItem.FatGrams = TryGetDecimal(fatNDBNoToValue, foodId);
                flatItem.CarbohydrateGrams = TryGetDecimal(carNDBNoToValue, foodId);
                flatItem.AshGrams = TryGetDecimal(ashNDBNoToValue, foodId);
                flatItem.EnergyKcal = TryGetDecimal(energyNDBNoToValue, foodId);
                //...


                this.FoodItems.Add(flatItem);
            }
        }


        private decimal? TryGetDecimal<T1>(Dictionary<T1, string> dict, T1 key)
        {
            string dictValue;
            if (!dict.TryGetValue(key, out dictValue)) return null;
            if (dictValue == null) return null;

            decimal dictValDecimal;
            if (!Decimal.TryParse(dictValue,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out dictValDecimal))
                return null;

            return dictValDecimal;

        }
        
    }
}
