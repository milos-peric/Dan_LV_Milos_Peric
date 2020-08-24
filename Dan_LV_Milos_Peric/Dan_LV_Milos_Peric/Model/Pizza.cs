using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dan_LV_Milos_Peric.Model
{
    class Pizza
    {
        List<Ingredients> ingredientsList = new List<Ingredients>();
        public string Size { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
