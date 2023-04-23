namespace WebApi.Classes
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public bool? Is_Cover { get; set; }
        public Product Product { get; set; }
        public string? photoUrl { get; set; }
    }
}
