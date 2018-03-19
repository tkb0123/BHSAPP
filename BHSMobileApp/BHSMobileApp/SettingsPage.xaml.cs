using System;
using Xamarin.Forms;

namespace BHSMobileApp
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            Reset(null, null);
        }

        void Save(object sender, EventArgs e)
        {
            DataStorage.SaveProperty("Username", username.Text);
            DataStorage.SaveProperty("RestroomDisplayEnabled", restroomsEnabled.On);
            DataStorage.SaveProperty("ElevatorDisplayEnabled", elevatorsEnabled.On);
            DataStorage.SaveProperty("StairwellDisplayEnabled", stairwellsEnabled.On);

            Application.Current.SavePropertiesAsync();
        }

        void Reset(object sender, EventArgs e)
        {
            username.Text = DataStorage.LoadTextProperty("Username");
            restroomsEnabled.On = DataStorage.LoadBoolProperty("RestroomDisplayEnabled", false);
            stairwellsEnabled.On = DataStorage.LoadBoolProperty("StairwellDisplayEnabled", false);
            elevatorsEnabled.On = DataStorage.LoadBoolProperty("ElevatorDisplayEnabled", false); 
        }

    }
}
