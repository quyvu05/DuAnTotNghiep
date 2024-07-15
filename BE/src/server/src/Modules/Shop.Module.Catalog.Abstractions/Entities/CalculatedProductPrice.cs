namespace Shop.Module.Catalog.Entities
{
    public class CalculatedProductPrice
    {
        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        /// <summary>
        /// Discount
        /// </summary>
        public int PercentOfSaving { get; set; }
    }
}
