namespace PlantDataMVC.Domain.Entities
{
    public class PlantProductType: DomainEntity
    {
        public string Name { get; set; }

        public override string DisplayValue { get { return this.Name; } }

        public PlantProductType() : this(0, "")
        {
        }

        public PlantProductType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
