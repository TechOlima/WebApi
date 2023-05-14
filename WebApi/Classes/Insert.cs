using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Classes.Operations;

namespace WebApi.Classes
{
    public class Insert
    {
        public int InsertID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Weight { get; set; }        
        public StoneType StoneType { get; set; }        
        public Product Product { get; set; }

        public Insert()
        {

        }

        public Insert(InsertPost insert, DataContext _context)
        {
            Weight = insert.Weight;
            StoneType = _context.StoneType.FirstOrDefault(i => i.Name == insert.StoneType);
            Product = _context.Product.FirstOrDefault(i => i.ProductID == insert.ProductID);
        }
    }
}
