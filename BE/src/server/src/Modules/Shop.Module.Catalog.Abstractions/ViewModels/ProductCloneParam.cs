using System.ComponentModel.DataAnnotations;

namespace Shop.Module.Catalog.ViewModels
{
    public class ProductCloneParam
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        /// <summary>
        /// Copy Image
        /// </summary>
        public bool IsCopyImages { get; set; }

        /// <summary>
        /// Copy Inventory 
        /// </summary>
        public bool IsCopyStock { get; set; }
    }
}
