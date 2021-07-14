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
            //PerishableProduct p = new PerishableProduct(1, "test", ProductType.Food, 10, DateTime.Today.AddDays(3), 20);
        }

        private Product CaptureUserInput()
        {
            Product product=null;
            int productCode = int.Parse(TxtProductCode.Text);
            string productName = TxtProductName.Text;
            ProductType productType = Enum.Parse<ProductType>(CmbProductType.SelectedItem?.ToString());
            float price = float.Parse(TxtPrice.Text);
            int stock = int.Parse(TxtStock.Text);

            if (ChkIsPerishable.IsChecked == true)
                product = new PerishableProduct(productCode, productName, productType, price, DpExpiryDate.Date.Date, stock);
            else
                product = new Product(productCode, productName, productType, price, stock);
            
            //string s = product.ToString(); //Just a test to demonstrate polymorhic behaviour of product
            return product;
        }

        private void OnAddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = CaptureUserInput();
                _products.AddProduct(product);
                //LstProducts.Items.Add($"{product.ProductCode}, {product.ProductName}");
                LstProducts.Items?.Add(product);
            }
            
            catch (Exception ex)
            {
                TxtErrMessage.Text = ex.Message;
            }
        }

        private void OnExpiryDateClicked(object sender, RoutedEventArgs e)
        {
            DpExpiryDate.IsEnabled = ChkIsPerishable.IsChecked??false; //evaluate null in IsChecked as false
        }

        private void OnPlaceOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                int units = int.Parse(TxtUnitsRequired.Text);
                Product product = (Product) LstProducts.SelectedItem;
                product?.SellProduct(units);
            }
            catch (NotEnoughStockException neStockEx)
            {
                TxtErrMessage.Text = $"We have just {neStockEx.Currentstock} items in our stock right now";
                //ask the user to accept as many items as we have in the stock
                //or, place a back order
            }
            catch (Exception ex)
            {
                TxtErrMessage.Text = ex.Message;
            }
        }
    }
}
