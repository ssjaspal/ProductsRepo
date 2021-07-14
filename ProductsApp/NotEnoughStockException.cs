using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    class NotEnoughStockException : Exception
    {
        private int _productCode;
        private int _currentStock;
        private int _unitsRequested;

        public NotEnoughStockException(string message, int productCode, int currentStock, int unitsRequested)
        :base(message)
        {
            _productCode = productCode;
            _currentStock = currentStock;
            _unitsRequested = unitsRequested;
        }

        public int ProductCode => _productCode;
        public int Currentstock => _currentStock;
        public int UnitsRequired => _unitsRequested;


    }
}
