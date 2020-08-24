using Dan_LV_Milos_Peric.Model;
using Dan_LV_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LV_Milos_Peric.ViewModel
{
    class PizzaOrderMainViewModel : ViewModelBase
    {
        private PizzaOrderMainView pizzaOrderMainView;

        public PizzaOrderMainViewModel(PizzaOrderMainView pizzaOrderMainView)
        {
            this.pizzaOrderMainView = pizzaOrderMainView;
        }

        private string size;

        public string Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }

        private List<string> sizeList;
        public List<string> SizeList
        {
            get { return sizeList; }
            set
            {
                sizeList = value;
                OnPropertyChanged("SizeList");
            }
        }

        private bool salami;
        public bool Salami
        {
            get { return salami; }
            set
            {
                salami = value;
                OnPropertyChanged("Salami");
            }
        }

        private bool ham;
        public bool Ham
        {
            get { return ham; }
            set
            {
                ham = value;
                OnPropertyChanged("Ham");
            }
        }


        private bool chorizo;
        public bool Chorizo
        {
            get { return chorizo; }
            set
            {
                chorizo = value;
                OnPropertyChanged("Chorizo");
            }
        }

        private bool ketchup;
        public bool Ketchup
        {
            get { return ketchup; }
            set
            {
                ketchup = value;
                OnPropertyChanged("Ketchup");
            }
        }

        private bool mayo;
        public bool Mayo
        {
            get { return mayo; }
            set
            {
                mayo = value;
                OnPropertyChanged("Mayo");
            }
        }

        private bool chillyPepper;
        public bool ChillyPepper
        {
            get { return chillyPepper; }
            set
            {
                chillyPepper = value;
                OnPropertyChanged("ChillyPepper");
            }
        }

        private bool olives;
        public bool Olives
        {
            get { return olives; }
            set
            {
                olives = value;
                OnPropertyChanged("Olives");
            }
        }

        private bool oregano;
        public bool Oregano
        {
            get { return oregano; }
            set
            {
                oregano = value;
                OnPropertyChanged("Oregano");
            }
        }

        private bool sesame;
        public bool Sesame
        {
            get { return sesame; }
            set
            {
                sesame = value;
                OnPropertyChanged("Sesame");
            }
        }

        private bool cheese;
        public bool Cheese
        {
            get { return cheese; }
            set
            {
                cheese = value;
                OnPropertyChanged("Cheese");
            }
        }



    }
}
