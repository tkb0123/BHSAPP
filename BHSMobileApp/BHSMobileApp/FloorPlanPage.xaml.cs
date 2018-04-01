using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BHSMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloorPlanPage : ContentPage
    {
        public static Dictionary<string, double[]> Rooms;

        public FloorPlanPage()
        {
            InitializeComponent();

            Rooms = new Dictionary<string, double[]>()
            { { "C28", new[] {0.157,0.283} }
            , { "C29", new[] {0.111,0.33} }
            , { "C27", new[] {0.143,0.336} }
            , { "C26", new[] {0.197,0.284} }
            , { "C24", new[] {0.227,0.29} }
            , { "C22", new[] {0.259,0.297} }
            , { "C20", new[] {0.296,0.31} }
            , { "D20", new[] {0.441,0.286} }
            , { "D21", new[] {0.36,0.28} }
            , { "D22", new[] {0.437,0.297} }
            , { "D23", new[] {0.374,0.261} }
            , { "D24", new[] {0.45,0.28} }
            , { "ISS", new[] {0.391,0.241} }
            , { "D25", new[] {0.401,0.221} }
            , { "D26", new[] {0.474,0.239} }
            , { "D28", new[] {0.493,0.217} }
            , { "D27", new[] {0.419,0.21} }
            , { "D29A", new[] {0.426,0.13} }
            , { "D29B", new[] {0.51,0.116} }
            , { "SENIOR BALCONY", new[] {0.591,0.196} }
            , { "SR. BALCONY", new[] {0.591,0.196} }
            , { "SR BALCONY", new[] {0.591,0.196} }
            , { "BALCONY", new[] {0.591,0.196} }
            , { "A28", new[] {0.757,0.26} }
            , { "A26", new[] {0.733,0.293} }
            , { "A24", new[] {0.693,0.327} }
            , { "COMMONS", new[] {0.577,0.763} }
            , { "CAFE", new[] {0.577,0.763} }
            , { "LUNCH", new[] {0.577,0.763} }
            , { "A22", new[] {0.677,0.354} }
            , { "A20", new[] {0.654,0.37} }
            , { "A27", new[] {0.687,0.244} }
            , { "A25", new[] {0.666,0.267} }
            , { "A23", new[] {0.644,0.29} }
            , { "MS. BYRD", new[] {0.631,0.31} }
            , { "MS BYRD", new[] {0.631,0.31} }
            , { "A21", new[] {0.62,0.326} }
            , { "F20", new[] {0.36,0.203} }
            , { "F22", new[] {0.377,0.18} }
            , { "F23", new[] {0.403,0.146} }
            , { "F24", new[] {0.489,0.116} }
            , { "F25", new[] {0.523,0.094} }
            , { "F26", new[] {0.567,0.09} }
            , { "LECTURE HALL", new[] {0.727,0.07} }
            , { "F28", new[] {0.77,0.1} }
            , { "F29", new[] {0.844,0.139} }
            , { "F21", new[] {0.484,0.163} }
            , { "COMPUTER LAB", new[] {0.681,0.139} }
            , { "COMPUTERS", new[] {0.681,0.139} }
            , { "F27", new[] {0.756,0.173} }
            , { "B28", new[] {0.569,0.414} }
            , { "B27", new[] {0.577,0.353} }
            , { "B25", new[] {0.531,0.344} }
            , { "B23", new[] {0.487,0.336} }
            , { "B21", new[] {0.463,0.331} }
            , { "B22", new[] {0.431,0.384} }
            , { "B24", new[] {0.463,0.391} }
            , { "B26", new[] {0.519,0.403} }
            };
        }

        private Rectangle GetRoomRectangle(double xPercent, double yPercent)
        {
            return new Rectangle(xPercent * floor.Width - 21, yPercent* floor.Height - 37, 43, 40);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ReloadClassDropdown();

            classDropdown.SelectedIndexChanged -= ClassSelection;
            classDropdown.SelectedIndexChanged += ClassSelection;

            searchBar.SearchButtonPressed -= RoomSearch;
            searchBar.SearchButtonPressed += RoomSearch;

            pin.LayoutTo(GetRoomRectangle(.1, .1));
            pinLabel.Text = "Buzz";

            bool restroomEnabled = DataStorage.LoadBoolProperty("RestroomDisplayEnabled", false);
            bool stairwellsEnabled = DataStorage.LoadBoolProperty("StairwellDisplayEnabled", false);
            bool elevatorsEnabled = DataStorage.LoadBoolProperty("ElevatorDisplayEnabled", false);

            restroom1.IsVisible = restroomEnabled;
            restroom2.IsVisible = restroomEnabled;
            restroom3.IsVisible = restroomEnabled;
            restroom4.IsVisible = restroomEnabled;

            stairs1.IsVisible = stairwellsEnabled;
            stairs1a.IsVisible = stairwellsEnabled;
            stairs2.IsVisible = stairwellsEnabled;
            stairs2a.IsVisible = stairwellsEnabled;
            stairs3.IsVisible = stairwellsEnabled;
            stairs3a.IsVisible = stairwellsEnabled;
            stairs4.IsVisible = stairwellsEnabled;
            stairs4a.IsVisible = stairwellsEnabled;
            stairs5.IsVisible = stairwellsEnabled;
            stairs5a.IsVisible = stairwellsEnabled;
            stairs6.IsVisible = stairwellsEnabled;
            stairs6a.IsVisible = stairwellsEnabled;

            elevator1.IsVisible = elevatorsEnabled;
            elevator1a.IsVisible = elevatorsEnabled;
        }

        private void ReloadClassDropdown()
        {
            classDropdown.Items.Clear();
            classDropdown.Items.Add("");
            for (int i = 1; i <= 8; i++)
            {
                var className = DataStorage.LoadTextProperty("class" + i);
                var roomNumber = DataStorage.LoadTextProperty("room" + i);
                if (className != null && className != "" && roomNumber != null && roomNumber != "")
                {
                    classDropdown.Items.Add(className + " - " + roomNumber);
                }
            }
        }

        private void RoomSearch(object sender, EventArgs e)
        {
            MovePin(searchBar.Text);
            ReloadClassDropdown();
        }

        private void ClassSelection(object sender, EventArgs e)
        {
            string item = classDropdown.SelectedItem as string;
            string room = "";
            if ( item != null && item.Contains(" - ") )
            {
                room = item.Substring(item.LastIndexOf(" - ") + 3);
            }
            MovePin(room);
            searchBar.Text = null;
        }

        private void MovePin(string room)
        {
            if ( Rooms == null || room == null || room == "" )
            {
                return;
            }

            if ( Rooms.ContainsKey(room.Trim().ToUpper()) )
            {
                var coords = Rooms[room.Trim().ToUpper()];
                pin.LayoutTo(GetRoomRectangle(coords[0], coords[1]));
                pinLabel.Text = room;
            }
            else
            {
                pin.LayoutTo(GetRoomRectangle(.1, .1));
                pinLabel.Text = "???";
            }
        }

    }
}