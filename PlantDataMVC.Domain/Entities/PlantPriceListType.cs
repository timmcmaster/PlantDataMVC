namespace PlantDataMVC.Domain.Entities
{
    public class PlantPriceListType: DomainEntity
    {
        public string Name { get; set; }
        public string Kind { get; set; }

        public override string DisplayValue { get { return this.Name; } }

        //public PlantPriceListType(): this(0, "New PriceList", "R")
        //{
        //}

        //public PlantPriceListType(int id, string name, string kind)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Kind = kind;
        //}
    }
}
