namespace Agri_Energy_app.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public Product()
        {
            
        }

    }
}
