using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    class ProductRepository
    {
        private List<Product> _products;

        /// <summary>
        /// Read-only property that return the collection of products in the repository
        /// </summary>
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        /// <summary>
        /// Initializes the collection of products
        /// </summary>
        public ProductRepository()
        {
            _products = new List<Product>();
        }

        /// <summary>
        /// Adds a product to the repository.
        /// </summary>
        /// <param name="product">The new product to be added to the repository.</param>
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        
    }
}
