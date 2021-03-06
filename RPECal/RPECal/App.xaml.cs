using E1RM.Data;
using E1RM.Services;
using E1RM.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E1RM
{
    public partial class App : Application
    {
        static RPEDatabase database;
        public static RPEDatabase Database {
            get
            {
                if (database == null)
                    database = new RPEDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RPE.db"));
                return database;
            } 
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
