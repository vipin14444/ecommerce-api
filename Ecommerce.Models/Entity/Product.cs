using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecommerce.Models
{
    public class Product : BaseModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
    }
}