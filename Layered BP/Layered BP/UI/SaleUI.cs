using Layered_BP.Sales;
using Layered_BP.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.UI
{
    class SaleUI
    {
        private readonly SaleService _saleService;

        public SaleUI(SaleService saleService)
        {
            _saleService = saleService;
        }

        public void ViewSalesUI()
        {
            Console.Clear();
            Console.WriteLine("Date \t\t Toy \t\t Qty \t Amount");
            foreach (Sale s in _saleService.GetAllSales())
                Console.WriteLine(s.SaleDate + "\t" + s.ToyName + "\t\t" + s.Quantity + "\t" + s.Amount);
            Console.WriteLine("Total Revenue: Rs." + _saleService.TotalRevenue);
        }

        public void SortSalesByRevenueUI()
        {
            Console.Clear();
            List<Sale> sorted = _saleService.SortByRevenue();
            Console.WriteLine("Date \t\t Toy \t\t Qty \t Amount");
            foreach (Sale s in sorted)
                Console.WriteLine(s.SaleDate + "\t" + s.ToyName + "\t\t" + s.Quantity + "\t" + s.Amount);
        }
    }
}
