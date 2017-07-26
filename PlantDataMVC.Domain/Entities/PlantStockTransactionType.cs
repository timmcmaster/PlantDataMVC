namespace PlantDataMVC.Domain.Entities
{
    public class PlantStockTransactionType: DomainEntity
    {
        public string Name { get; set; }
        public int Effect { get; set; }

        public override string DisplayValue { get { return this.Name; } }

        public PlantStockTransactionType()
        {
        }

        //public PlantStockTransactionType() : this(0, "", 0)
        //{
        //}

        //public PlantStockTransactionType(int id, string name, int effect)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Effect = effect;
        //}
    }
}
