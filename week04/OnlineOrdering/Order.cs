using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public Customer Customer
        {
            get { return _customer; }
        }

        public IReadOnlyList<Product> Products
        {
            get { return _products.AsReadOnly(); }
        }

        public void AddProduct(Product p)
        {
            if (p != null)
            {
                _products.Add(p);
            }
        }

        public decimal CalculateTotalCost()
        {
            decimal sum = 0m;
            foreach (var prod in _products)
            {
                sum += prod.GetTotalCost();
            }

            decimal shipping = _customer.IsInUSA() ? 5.00m : 35.00m;
            return sum + shipping;
        }

        public string GetPackingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var prod in _products)
            {
                sb.AppendLine($"- {prod.Name} (ID: {prod.ProductId})");
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            return _customer.GetShippingLabel();
        }
    }
}
