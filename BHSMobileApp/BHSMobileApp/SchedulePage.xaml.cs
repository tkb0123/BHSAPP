using System;
using Xamarin.Forms;

namespace BHSMobileApp
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
            Reset(null, null);
        }

        void Save(object sender, EventArgs e)
        {
            // -----------------------------
            // Start entering your code here
            // -----------------------------
            DataStorage.SaveProperty("class1", Class1.Text);
            DataStorage.SaveProperty("class2", Class2.Text);
            DataStorage.SaveProperty("class3", Class3.Text);
            DataStorage.SaveProperty("class4", Class4.Text);
            DataStorage.SaveProperty("class5", Class5.Text);
            DataStorage.SaveProperty("class6", Class6.Text);
            DataStorage.SaveProperty("class7", Class7.Text);
            DataStorage.SaveProperty("class8", Class8.Text);
            DataStorage.SaveProperty("room1", Room1.Text);
            DataStorage.SaveProperty("room2", Room2.Text);
            DataStorage.SaveProperty("room3", Room3.Text);
            DataStorage.SaveProperty("room4", Room4.Text);
            DataStorage.SaveProperty("room5", Room5.Text);
            DataStorage.SaveProperty("room6", Room6.Text);
            DataStorage.SaveProperty("room7", Room7.Text);
            DataStorage.SaveProperty("room8", Room8.Text);
            // -----------------------------
            // Stop entering your code here
            // -----------------------------

            Application.Current.SavePropertiesAsync();
        }

        void Reset(object sender, EventArgs e)
        {
            // -----------------------------
            // Start entering your code here
            // -----------------------------
            Class1.Text = DataStorage.LoadTextProperty("class1");
            Class2.Text = DataStorage.LoadTextProperty("class2");
            Class3.Text = DataStorage.LoadTextProperty("class3");
            Class4.Text = DataStorage.LoadTextProperty("class4");
            Class5.Text = DataStorage.LoadTextProperty("class5");
            Class6.Text = DataStorage.LoadTextProperty("class6");
            Class7.Text = DataStorage.LoadTextProperty("class7");
            Class8.Text = DataStorage.LoadTextProperty("class8");
            Room1.Text = DataStorage.LoadTextProperty("room1");
            Room2.Text = DataStorage.LoadTextProperty("room2");
            Room3.Text = DataStorage.LoadTextProperty("room3");
            Room4.Text = DataStorage.LoadTextProperty("room4");
            Room5.Text = DataStorage.LoadTextProperty("room5");
            Room6.Text = DataStorage.LoadTextProperty("room6");
            Room7.Text = DataStorage.LoadTextProperty("room7");
            Room8.Text = DataStorage.LoadTextProperty("room8");
            // -----------------------------
            // Stop entering your code here
            // -----------------------------
        }

    }
}
