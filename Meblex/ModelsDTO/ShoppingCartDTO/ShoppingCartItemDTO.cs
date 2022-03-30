namespace Meblex.ModelsDTO.ShoppingCartDTO
{
    public class ShoppingCartItemDTO
    {
        public int ShoppingCartItemId { get; set; }

        public ProductDTO Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
