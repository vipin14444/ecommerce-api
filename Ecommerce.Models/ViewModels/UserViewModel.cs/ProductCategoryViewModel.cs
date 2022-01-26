namespace Ecommerce.Models
{
    public class ProductCategoryViewModel
    {
        public long ProdCatId { get; set; }
        public string CategoryName { get; set; }
    }

    public class ProductAttributeLookupViewModel
    {
        public int AttributeId { get; set; }
        public int ProdCatId { get; set; }
        public string AttributeName { get; set; }
    }
}