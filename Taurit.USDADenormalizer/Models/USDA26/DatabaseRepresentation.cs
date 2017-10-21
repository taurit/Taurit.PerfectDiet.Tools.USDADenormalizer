using System.Collections.Generic;
using Taurit.USDADenormalizer.ImportModules.USDA26;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global

namespace Taurit.USDADenormalizer.Models.USDA26
{
    /// <summary>
    ///     Main file that represents database in revision #26
    ///     It's a direct mapping of provided database files (in CSV format) to CLR objects, which
    ///     keeps the original names and data types based on documentation.
    /// </summary>
    public class DatabaseRepresentation
    {
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
#pragma warning disable IDE1006 // Naming Styles. Intentional - names should match those in external documentation
        public List<DataDerivation> dataDerivation { get; }
        public List<FoodDescription> foodDescription { get; }
        public List<FoodGroupDescription> foodGroupDescription { get; }
        public List<Footnote> footnote { get; }
        public List<LangualFactor> langualFactor { get; }
        public List<LangualFactorsDescription> langualFactorsDescription { get; }
        public List<NutrientData> nutrientData { get; }
        public List<NutrientDefinition> nutrientDefinition { get; }
        public List<SourceCode> sourceCode { get; }
        public List<SourcesOfData> sourcesOfData { get; }
        public List<SourcesOfDataLink> sourcesOfDataLink { get; }
        public List<Weight> weight { get; }
#pragma warning restore IDE1006 // Naming Styles
    }
}