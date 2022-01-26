using Dapper.Contrib.Extensions;

namespace Ecommerce.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        // [Write(false)]
        [Key]
        public int ProdCatId { get; set; }
        public string CategoryName { get; set; }
    }
}