using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BHSMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloorPlanPage : ContentPage
    {
        public FloorPlanPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            classDropdown.SelectedIndexChanged += ClassSelection;
            searchBar.SearchButtonPressed += RoomSearch;

            bool restroomEnabled = DataStorage.LoadBoolProperty("RestroomDisplayEnabled", false);
            bool stairwellsEnabled = DataStorage.LoadBoolProperty("StairwellDisplayEnabled", false);
            bool elevatorsEnabled = DataStorage.LoadBoolProperty("ElevatorDisplayEnabled", false);

            restroom1.IsVisible = restroomEnabled;
            restroom2.IsVisible = restroomEnabled;
            restroom3.IsVisible = restroomEnabled;
            restroom4.IsVisible = restroomEnabled;
            //TODO
        }

        private void RoomSearch(object sender, EventArgs e)
        {
            pin.LayoutTo(new Rectangle(0, 0, 43, 40));
            pinLabel.Text="Hmm";
        }

        private void ClassSelection(object sender, EventArgs e)
        {
            pin.LayoutTo(new Rectangle(0, 0, 43, 40));
            pinLabel.Text = "Hmm";
        }
    }
}