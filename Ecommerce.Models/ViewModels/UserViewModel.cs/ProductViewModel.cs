using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class ProductViewModel
    {
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public List<ProductAttributeViewModel> ProdAttributes { get; set; }
    }
    public class ProductAttributeViewModel
    {
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
    }
}