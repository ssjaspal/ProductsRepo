using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProductsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ProductRepository _products = new ProductRepository();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private Product CaptureUserInput()
        {
            int productCode = int.Parse(TxtProductCode.Text);
            string productName = TxtProductName.Text;
            ProductType productType = Enum.Parse<ProductType>(CmbProductType.SelectedItem.ToString());
            float price = float.Parse(TxtPrice.Text);
            int stock = int.Parse(TxtStock.Text);
            Product product = new Product(productCode, productName, productType, price, stock);
            return product;
        }

        private void OnAddProduct(object sender, RoutedEventArgs e)
        {
            Product product = CaptureUserInput();
            _products.AddProduct(product);
            LstProducts.Items.Add($"{product.ProductCode}, {product.ProductName}");
        }
    }
}
