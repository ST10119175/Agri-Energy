namespace Agri_Energy_app.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }

        public Farmer()
        {
            
        }
    }
}
