namespace PlantDataMVC.DTO.DomainFunctions
{
    public static class SpeciesFunctions
    {
        public static string GetBinomial(string genus, string species)
        {
            return $"{genus} {species}";
        }
    }
}
