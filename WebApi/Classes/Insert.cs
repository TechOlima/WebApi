using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Classes
{
    public class Insert
    {
        public int InsertID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Weight { get; set; }
        public StoneType StoneType { get; set; }
    }
}
