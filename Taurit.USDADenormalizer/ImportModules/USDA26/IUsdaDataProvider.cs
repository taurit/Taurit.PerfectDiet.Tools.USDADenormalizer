using System.Collections.Generic;
using USDADenormalizer.Models.USDA26;

namespace Taurit.USDADenormalizer.ImportModules.USDA26
{
    /// <summary>
    /// As of 2015, database is provided in two formats:
    /// 1) Directory containing CSV files
    /// 2) Microsoft Access file
    /// 
    /// This library currently uses first of them to read the data (its implemented in DirectoryDataProvider), but if there 
    /// were some changes in the future, Microsoft Access's or other data provider might be created by implementing
    /// this interface.
    /// </summary>
    public interface IUsdaDataProvider
    {
        List<DataDerivation> GetDataDerivation();
        List<FoodDescription> GetFoodDescription();
        List<FoodGroupDescription> GetFoodGroupDescription();
        List<Footnote> GetFootnote();
        List<LangualFactor> GetLangualFactor();
        List<LangualFactorsDescription> GetLangualFactorsDescription();
        List<NutrientData> GetNutrientData();
        List<NutrientDefinition> GetNutrientDefinition();
        List<SourceCode> GetSourceCode();
        List<SourcesOfData> GetSourcesOfData();
        List<SourcesOfDataLink> GetSourcesOfDataLink();
        List<Weight> GetWeight();
    }
}
