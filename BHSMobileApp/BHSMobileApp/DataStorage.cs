using Xamarin.Forms;

namespace BHSMobileApp
{
    public static class DataStorage
    {
        public static void SaveProperty(string propertyName, object value)
        {
            if (propertyName != null && propertyName != "")
            {
                Application.Current.Properties[propertyName] = value;
            }
        }

        public static string LoadTextProperty(string propertyName)
        {
            if (propertyName != null && propertyName != "")
            {
                if (Application.Current.Properties.ContainsKey(propertyName) && Application.Current.Properties[propertyName] != null)
                {
                    return Application.Current.Properties[propertyName].ToString();
                }
            }
            return null;
        }

        public static bool LoadBoolProperty(string propertyName, bool defaultValue)
        {
            if (propertyName != null && propertyName != "")
            {
                if (Application.Current.Properties.ContainsKey(propertyName) && Application.Current.Properties[propertyName] != null)
                {
                    return (bool)Application.Current.Properties[propertyName];
                }
            }
            return defaultValue;
        }
    }
}
