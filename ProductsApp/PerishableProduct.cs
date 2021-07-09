using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    /// <summary>
    /// Represents products that must be used before a specific date.
    /// </summary>
    class PerishableProduct : Product
    {
        private DateTime _expiryDate;

        /// <summary>
        /// Initializes nes instances of Perishable Products
        /// </summary>
        /// <param name="productCode">Unique identifier of the product</param>
        /// <param name="productName">Name of the product</param>
        /// <param name="productType">Product category </param>
        /// <param name="price">Original price of the product</param>
        /// <param name="expiryDate">The date before which the product should be used.</param>
        /// <param name="stock">Number of items in stock. Default value is 100</param>
        public PerishableProduct(int productCode, string productName, ProductType productType, float price, DateTime expiryDate, int stock = 100)
        :base (productCode, productName, productType, price, stock)
        {
            ExpiryDate = expiryDate;
        }

        /// <summary>
        /// Represents the date before which the product must be used.
        /// </summary>
        public DateTime ExpiryDate
        {
            get => _expiryDate;
            set
            {
                if (value <= DateTime.Today)
                    throw new Exception("Expiry date should be a future date");
                _expiryDate = value;
            }
        }

        /// <summary>
        /// Converts the current instance of PerishableProduct to its string equivalent.
        /// </summary>
        /// <returns>A string containing comma separated list of all the fields</returns>
        public override string ToString()
        {
            return $"{base.ToString()},{ExpiryDate}";
        }
    }
}
