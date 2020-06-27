
using System.Collections.Generic;

namespace KodluyoruzApi.Models
{
    public static class Store
    {
        public static string Name { get; set; } = "Kodluyoruz Store";
        public static List<Product> Products { get; set; } = FillProducts();

        private static List<Product> FillProducts()
        {
            var storeProducts = new List<Product>{
                new Product
                {
                    Id =  1,
                    Name = "Birinci Ürün",
                    Price = 11
                },
                new Product
                {
                    Id =  2,
                    Name = "İkinci Ürün",
                    Price = 2.2M
                },
                new Product
                {
                    Id =  4,
                    Name = "Dördüncü Ürün",
                    Price = 4
                }
            };

            return storeProducts;
        }
    }
}
