using System.ComponentModel.DataAnnotations;
namespace ChemeaseWeb.Models
{
    public class CartViewModel
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
