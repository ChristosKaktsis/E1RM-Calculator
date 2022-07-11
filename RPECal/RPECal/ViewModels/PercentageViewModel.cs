using E1RM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace E1RM.ViewModels
{
    public class PercentageViewModel : BaseViewModel
    {
        private string showResult;
        public float Weight { get; set; }
        public int Reps { get; set; }
        public string ShowResult 
        { 
            get => showResult; 
            set => SetProperty(ref showResult,value); 
        }
        public ObservableCollection<PercentageItem> PercentageList { get; set; }
        public Command Calculate { get;}
        public PercentageViewModel()
        {
            Calculate = new Command(CalculatePercent);
            PercentageList = new ObservableCollection<PercentageItem>();
        }

        private void CalculatePercent()
        {
            PercentageList.Clear();
            float repr =(float) 36 / (37 - Reps);
            var result = Weight * repr;
            int rep = 1;

            for (int i = 100; i >= 70; i = i - 5)
            {
                PercentageList.Add(new PercentageItem
                {
                    Percent = i, Weight =(float) Math.Round(result,1), Reps = rep
                });
                result = result * (i - 5) / i;
                if (rep >= 2)
                    rep += 2;
                else
                    rep++;
            }
        }
    }
}
