using System.Collections.Generic;
using Taurit.USDADenormalizer.ImportModules.USDA26;

namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Main file that represents database in revision #26
    ///     It's a direct mapping of provided database files (in CSV format) to CLR objects, which
    ///     keeps the original names and data types based on documentation.
    /// </summary>
    public class DatabaseRepresentation
    {
        internal List<DataDerivation> dataDerivation;
        internal List<FoodDescription> foodDescription;
        internal List<FoodGroupDescription> foodGroupDescription;
        internal List<Footnote> footnote;
        internal List<LangualFactor> langualFactor;
        internal List<LangualFactorsDescription> langualFactorsDescription;
        internal List<NutrientData> nutrientData;
        internal List<NutrientDefinition> nutrientDefinition;
        internal List<SourceCode> sourceCode;
        internal List<SourcesOfData> sourcesOfData;
        internal List<SourcesOfDataLink> sourcesOfDataLink;
        internal List<Weight> weight;

        public DatabaseRepresentation(IUsdaDataProvider dataProvider)
        {
            dataDerivation = dataProvider.GetDataDerivation();
            foodDescription = dataProvider.GetFoodDescription();
            foodGroupDescription = dataProvider.GetFoodGroupDescription();
            footnote = dataProvider.GetFootnote();
            langualFactor = dataProvider.GetLangualFactor();
            langualFactorsDescription = dataProvider.GetLangualFactorsDescription();
            nutrientData = dataProvider.GetNutrientData();
            nutrientDefinition = dataProvider.GetNutrientDefinition();
            sourceCode = dataProvider.GetSourceCode();
            sourcesOfData = dataProvider.GetSourcesOfData();
            sourcesOfDataLink = dataProvider.GetSourcesOfDataLink();
            weight = dataProvider.GetWeight();
        }
    }
}