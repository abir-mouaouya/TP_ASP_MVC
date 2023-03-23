namespace Restaurant_MVC.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }    
       public string Cuisine  { get; set; }
       public List<Cuisine> Cuisines { get; set; }


    }
}
