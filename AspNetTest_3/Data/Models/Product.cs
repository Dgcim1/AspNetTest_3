namespace AspNetTest_3.Data.Models
{
    public class Product
    {
        public int id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public int EnergyValue { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public string Picture { get; set; }
    }
}
