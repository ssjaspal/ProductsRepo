using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    public enum ProductType
    {
        Electronics,
        Food,
        Clothing
    }

    /// <summary>
    /// Represents the entity Product
    /// </summary>
    public class Product
    {
        private int _productCode;
        private string _productName;
        private ProductType _productType;
        private float _price;
        private int _stock;


        /// <summary>
        /// Initializes a new instance of Product with the specified values.
        /// </summary>
        /// <param name="productCode">Unique identifier of the product</param>
        /// <param name="productName">Name of the product</param>
        /// <param name="productType">Product category </param>
        /// <param name="price">Original price of the product</param>
        /// <param name="stock">Number of items in stock. Default value is 100</param>
        public Product(int productCode, string productName, ProductType productType, float price,
            int stock=100)
        {
            ProductCode = productCode;
            ProductName = productName;
            ProductType = productType;
            Price = price;
            Stock = stock;
        }

        /// <summary>
        /// Unique identifier of the Product
        /// </summary>
        public int ProductCode
        {
            get => _productCode; //equivalent to get { return _productCode;}

            private set
            {
                if (value <= 0)
                    throw new Exception("Product code must be positive");
                _productCode = value;
            }
        }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string ProductName
        {
            get => _productName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Product name cannot be blank");
                _productName = value;
            }
        }

        /// <summary>
        /// The category of the product
        /// </summary>
        public ProductType ProductType
        {
            get => _productType;
            set => _productType = value;
        }

        /// <summary>
        /// Stock level of the Product
        /// </summary>
        public int Stock
        {
            get => _stock;
            private set
            {
                if (value <= 0)
                    throw new Exception("Stock must be positive");
                _stock = value;
            }
        }


        /// <summary>
        /// The original price of the product
        /// </summary>
        public float Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new Exception("Price must be positive");
                _price = value;
            }
        }

        /// <summary>
        /// Allows processing a sale
        /// </summary>
        /// <param name="unitsRequired">Number of units to be sold</param>
        /// <returns>The stock level after the sale</returns>
        public  int SellProduct(int unitsRequired)
        {
            //make sure unitsRequired are greater than zero
            if (unitsRequired <= 0)
                throw new ArgumentException("Units requested must be greater than zero", "unitsRequired");

            //make sure we have enough stock
            if (unitsRequired > Stock)
                throw new NotEnoughStockException();

            //process the sale
            Stock -= unitsRequired;

            return Stock;
        }

        /// <summary>
        /// Converts the current instance of PerishableProduct to its string equivalent.
        /// </summary>
        /// <returns>A string containing comma separated list of all the fields</returns>
        public override string ToString()
        {
            return $"{ProductCode},{ProductName},{ProductType},{Price},{Stock}";
        }
    }
}
