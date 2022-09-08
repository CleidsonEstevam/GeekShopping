using Ecommerce.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.CartAPI.Model
{
    [Table("cart_detail")]
    public class CartDetail : BaseEntity
    {
        [Column("cart_header_id")]
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeadrId")]
        public virtual CartHeader CartHeader { get; set; }

        [Column("product_id")]
        public long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}
