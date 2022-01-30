using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Ecommerce.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        [Write(false)]
        public List<ProductAttribute> ProdAttributes { get; set; }
    }

    [Table("ProductAttribute")]
    public class ProductAttribute
    {
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        [Write(false)]
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}