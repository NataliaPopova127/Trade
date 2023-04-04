using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeClientApp.Model.Database;

namespace TradeClientApp.ViewModel
{
    internal class ClientViewModel : BaseViewModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ClientViewModel()
        {
            Initialize();
            LoadData();
        }
        private void Initialize()
        {
            Products = new ObservableCollection<Product>();
        }
        private void LoadData()
        {
            using (TradeDBEntities context = new TradeDBEntities())
            {
                var _productList = context.Product.ToList();
                _productList.ForEach(p => Products.Add(p));
            }
        }
    }
}
