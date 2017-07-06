namespace PlantDataMVC.Domain.Entities
{
    public class PlantPriceListType: DomainEntity
    {
        public string Name { get; set; }
        public string Kind { get; set; }

        public PlantPriceListType(): this(0, "New PriceList", "R")
        {
        }

        public PlantPriceListType(int id, string name, string kind)
        {
            this.Id = id;
            this.Name = name;
            this.Kind = kind;
        }
    }
}
