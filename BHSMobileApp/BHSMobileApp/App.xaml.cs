using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BHSMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Page page;
            // -----------------------------
            // Start entering your code here
            // -----------------------------
            var schedulePage = new SchedulePage { Title = "Schedule", /*Icon = "xaml.png"*/ };
            var floorPlanPage = new FloorPlanPage { Title = "BHS Map", /*Icon = "xaml.png"*/ };
            var settingsPage = new SettingsPage { Title = "Settings", /*Icon = "xaml.png"*/ };

            var tabbedLayout = new TabbedPage();
            tabbedLayout.Children.Add(schedulePage);
            tabbedLayout.Children.Add(floorPlanPage);
            tabbedLayout.Children.Add(settingsPage);

            tabbedLayout.SelectedItem = floorPlanPage; // Start on this page

            page = tabbedLayout;
            // -----------------------------
            // Stop entering your code here
            // -----------------------------
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
