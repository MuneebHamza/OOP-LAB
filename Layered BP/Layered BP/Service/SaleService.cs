using Layered_BP.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Service
{
    class SaleService
    {
        private readonly SaleRepository _repository;
        public List<Sale> Sales;
        public float TotalRevenue;

        public SaleService()
        {
            _repository = new SaleRepository();
            Sales = _repository.GetAll();

            // ================================ calculate total revenue from sales
            if (File.Exists("sales.txt"))
            {
                foreach (Sale s in Sales)
                    TotalRevenue += s.Amount;
            }
        }

        public void AddSale(Sale sale)
        {
            Sales.Add(sale);
            TotalRevenue += sale.Amount;
            _repository.SaveAll(Sales);
        }

        public void SaveAll()
        {
            _repository.SaveAll(Sales);
        }

        public List<Sale> GetAllSales()
        {
            return Sales;
        }

        public List<Sale> SortByRevenue()
        {
            List<Sale> sorted = new List<Sale>(Sales);
            sorted.Sort((x, y) => y.Amount.CompareTo(x.Amount));
            return sorted;
        }
    }
}
