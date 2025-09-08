using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class DashboardVM
    {
        public int timePeriod { get; set; }
        public int numberOfUsers { get; set; }
        public int growNumberOfUsers { get; set; }
        public int numberOfOrders { get; set; }
        public int growNumberOfOrders { get; set; }
        public int numberOfProducts { get; set; }
        public int growNumberOfProducts { get; set; }
        public double totalOfSales { get; set; }
        public double growTotalOfSales { get; set; }

        public List<WalletActivities> financialActivities { get; set; }

    }
    public class WalletActivities
    {
        public double total { get; set; }
        public string status { get; set; }
    }
}
