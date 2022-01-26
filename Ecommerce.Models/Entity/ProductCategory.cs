using Dapper.Contrib.Extensions;

namespace Ecommerce.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public int ProdCatId { get; set; }
        public string CategoryName { get; set; }
    }
    [Table("ProductAttributeLookup")]
    public class ProductAttributeLookup
    {
        [Key]
        public int AttributeId { get; set; }
        public int ProdCatId { get; set; }
        public string AttributeName { get; set; }
    }
}