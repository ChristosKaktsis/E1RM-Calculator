using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E1RM.ViewModels
{
    public class WorkingWeightCalculatorViewModel : BaseViewModel
    {
        public Command CalculateWWCommand { get; set; }
        public WorkingWeightCalculatorViewModel()
        {
            CalculateWWCommand = new Command(async () => await CalculateWW());
        }
        public double E1RM { get; set; }
        public int Reps { get; set; }
        public double RPE { get; set; }
        private string working_Weight;
        private double intensity;
        public double Intensity
        {
            get => intensity;
            set => SetProperty(ref intensity, value);
        }
        public string Working_Weight
        {
            get => working_Weight;
            set => SetProperty(ref working_Weight, value);
        }
        private async Task CalculateWW()
        {
            try
            {
                IsBusy = true;
                var rpeval = await App.Database.GetRPEValueAsync(RPE, Reps);
                if (rpeval == null)
                    return;
                Intensity = rpeval.Value;
                var result = E1RM * (rpeval.Value / 100);
                Working_Weight = result.ToString("F");

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
