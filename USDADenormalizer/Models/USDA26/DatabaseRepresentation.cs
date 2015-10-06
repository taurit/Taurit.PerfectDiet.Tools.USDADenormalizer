using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDADenormalizer.ImportModules;

namespace USDADenormalizer.Models.USDA26
{
    /// <summary>
    /// Main file that represents database in revision #26
    /// It's a direct mapping of provided database files (in CSV format) to CLR objects, which 
    /// keeps the original names and data types based on documentation.
    /// </summary>
    public class DatabaseRepresentation
    {
        public DatabaseRepresentation(IUsdaDataProvider dataProvider)
        {
            this.dataDerivation = dataProvider.GetDataDerivation();
            this.foodDescription = dataProvider.GetFoodDescription();
            this.foodGroupDescription = dataProvider.GetFoodGroupDescription();
            this.footnote = dataProvider.GetFootnote();
            this.langualFactor = dataProvider.GetLangualFactor();
            this.langualFactorsDescription = dataProvider.GetLangualFactorsDescription();
            this.nutrientData = dataProvider.GetNutrientData();
            this.nutrientDefinition = dataProvider.GetNutrientDefinition();
            this.sourceCode = dataProvider.GetSourceCode();
            this.sourcesOfData = dataProvider.GetSourcesOfData();
            this.sourcesOfDataLink = dataProvider.GetSourcesOfDataLink();
            this.weight = dataProvider.GetWeight();
        }

        internal List<DataDerivation> dataDerivation = null;
        internal List<FoodDescription> foodDescription = null;
        internal List<FoodGroupDescription> foodGroupDescription = null;
        internal List<Footnote> footnote = null;
        internal List<LangualFactor> langualFactor = null;
        internal List<LangualFactorsDescription> langualFactorsDescription = null;
        internal List<NutrientData> nutrientData = null;
        internal List<NutrientDefinition> nutrientDefinition = null;
        internal List<SourceCode> sourceCode = null;
        internal List<SourcesOfData> sourcesOfData = null;
        internal List<SourcesOfDataLink> sourcesOfDataLink = null;
        internal List<Weight> weight = null;

    }
}
