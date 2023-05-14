namespace WebApi.Classes
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public bool? Is_Cover { get; set; }
        public int ProductID { get; set; }
        public string? photoUrl { get; set; }
    }
}
