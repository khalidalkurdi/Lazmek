using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class HomeIndexVM
    {
       public List<Product> products {  get; set; }
       public List<string> categories {  get; set; }
       public string categorytSelected {  get; set; }

    }
}
