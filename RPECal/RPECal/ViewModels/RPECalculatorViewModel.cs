using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E1RM.ViewModels
{
    public class RPECalculatorViewModel : BaseViewModel
    {
        private string e1rm;
        public Command CalculateE1RMCommand { get;}
        public RPECalculatorViewModel()
        {
            CalculateE1RMCommand = new Command(async () => await CalculateE1RM());
        }
        public double Weight { get; set; }
        public int Reps { get; set; }
        public double RPE { get; set; }
        public string E1RM 
        { 
            get => e1rm; 
            set => SetProperty(ref e1rm,value); 
        }
        private async Task CalculateE1RM()
        {
            try
            {
                IsBusy = true;
                var rpeval = await App.Database.GetRPEValueAsync(RPE, Reps);
                if (rpeval == null)
                    return;
                var result = Weight / (rpeval.Value / 100);
                E1RM = result.ToString("F");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
