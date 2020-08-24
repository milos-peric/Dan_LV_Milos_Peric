using Dan_LV_Milos_Peric.Command;
using Dan_LV_Milos_Peric.Model;
using Dan_LV_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dan_LV_Milos_Peric.ViewModel
{
    class PizzaOrderMainViewModel : ViewModelBase
    {
        private PizzaOrderMainView pizzaOrderMainView;

        public PizzaOrderMainViewModel(PizzaOrderMainView pizzaOrderMainView)
        {
            this.pizzaOrderMainView = pizzaOrderMainView;
            pizzaSize = GetAvailableSizes();
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
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

        private string fiscalBill;
        public string FiscalBill
        {
            get { return fiscalBill; }
            set
            {
                fiscalBill = value;
                OnPropertyChanged("FiscalBill");
            }
        }

        private double totalPrice;
        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        private Pizza pizza;
        public Pizza Pizza
        {
            get { return pizza; }
            set
            {
                pizza = value;
                OnPropertyChanged("Pizza");
            }
        }

        private List<string> pizzaSize;
        public List<string> PizzaSize
        {
            get { return pizzaSize; }
            set
            {
                pizzaSize = value;
                OnPropertyChanged("PizzaSize");
            }
        }

        private Dictionary<string, double> ingredientList;
        public Dictionary<string, double> IngredientList
        {
            get { return ingredientList; }
            set
            {
                ingredientList = value;
                OnPropertyChanged("IngredientList");
            }
        }

        #region Ingredients

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

        #endregion

        private List<string> GetAvailableSizes()
        {
            List<string> sizes = new List<string>();
            sizes.Add("Small");
            sizes.Add("Medium");
            sizes.Add("Large");
            return sizes;
        }

        private Dictionary<string, double> GetIngredientPrices()
        {
            Dictionary<string, double> ingredientPrices = new Dictionary<string, double>();
            ingredientPrices.Add("Salami", 5.2);
            ingredientPrices.Add("Ham", 6.5);
            ingredientPrices.Add("Chorizo", 7.6);
            ingredientPrices.Add("Ketchup", 2.4);
            ingredientPrices.Add("Mayo", 3.1);
            ingredientPrices.Add("ChillyPepper", 2.5);
            ingredientPrices.Add("Olives", 1.8);
            ingredientPrices.Add("Oregano", 0.7);
            ingredientPrices.Add("Sesame", 1.3);
            ingredientPrices.Add("Cheese", 4.4);
            return ingredientPrices;
        }

        private ICommand calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (calculateCommand == null)
                {
                    calculateCommand = new RelayCommand(param => CalculateCommandExecute(), param => CanCalculateCommandExecute());
                }
                return calculateCommand;
            }
        }

        private void CalculateCommandExecute()
        {
            try
            {
                TotalPrice = 0d;
                if (Size == "Small")
                {
                    TotalPrice += 12;
                }
                if (Size == "Medium")
                {
                    TotalPrice += 15;
                }
                if (Size == "Large")
                {
                    TotalPrice += 19;
                }
                double doughPrice = TotalPrice;
                Dictionary<string, double> ingredientPrices = GetIngredientPrices();
                Dictionary<string, bool> ingredientList = GetSelectedIngredients();
                List<string> ingredientBrakedown = new List<string>();
                foreach (var ingredient in ingredientPrices)
                {
                    if (ingredientList.ContainsKey(ingredient.Key))
                    {
                        TotalPrice += ingredient.Value;
                        ingredientBrakedown.Add(string.Format($"\n{ingredient.Key}: ${ingredient.Value}"));
                    }                   
                }
                TotalPrice = Convert.ToDouble(TotalPrice.ToString("#.##"));
                StringBuilder priceBrakedown = new StringBuilder();
                priceBrakedown.Append("**********************\n");
                priceBrakedown.Append($"Item: Pizza - {Size}");
                priceBrakedown.Append($"\nTotal Price: ${TotalPrice}");
                priceBrakedown.Append("\n**********************");
                priceBrakedown.Append($"\nPizza dough: ${doughPrice}");
                foreach (var ingredient in ingredientBrakedown)
                {
                    priceBrakedown.Append(ingredient);
                }
                priceBrakedown.Append("\n**********************");
                FiscalBill = priceBrakedown.ToString();
                IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCalculateCommandExecute()
        {
            if (string.IsNullOrEmpty(Size) || IsEnabled == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand confirmCommand;
        public ICommand ConfirmCommand
        {
            get
            {
                if (confirmCommand == null)
                {
                    confirmCommand = new RelayCommand(param => ConfirmCommandExecute(), param => CanConfirmCommandExecute());
                }
                return confirmCommand;
            }
        }

        private void ConfirmCommandExecute()
        {
            try
            {
                MessageBox.Show("Order has been confirmed successfully.","Success");
                IsEnabled = true;
                FiscalBill = "";
                TotalPrice = 0d;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanConfirmCommandExecute()
        {
            if (IsEnabled == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private Dictionary<string, bool> GetSelectedIngredients()
        {
            Dictionary<string, bool> selectedIngredients = new Dictionary<string, bool>();
            if (Salami == true)
            {
                selectedIngredients.Add("Salami", Salami);
            }
            if (Ham == true)
            {
                selectedIngredients.Add("Ham", Ham);
            }
            if (Chorizo == true)
            {
                selectedIngredients.Add("Chorizo", Chorizo);
            }
            if (Mayo == true)
            {
                selectedIngredients.Add("Mayo", Mayo);
            }
            if (Ketchup == true)
            {
                selectedIngredients.Add("Ketchup", Ketchup);
            }
            if (ChillyPepper == true)
            {
                selectedIngredients.Add("ChillyPepper", ChillyPepper);
            }
            if (Olives == true)
            {
                selectedIngredients.Add("Olives", Olives);
            }
            if (Oregano == true)
            {
                selectedIngredients.Add("Oregano", Oregano);
            }
            if (Sesame == true)
            {
                selectedIngredients.Add("Sesame", Sesame);
            }
            if (Cheese == true)
            {
                selectedIngredients.Add("Cheese", Cheese);
            }
            return selectedIngredients;
        }

        private ICommand quitCommand;
        public ICommand QuitCommand
        {
            get
            {
                if (quitCommand == null)
                {
                    quitCommand = new RelayCommand(param => QuitCommandExecute());
                }
                return quitCommand;
            }
        }

        private void QuitCommandExecute()
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
