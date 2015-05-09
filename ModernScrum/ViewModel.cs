using System.Collections.Generic;
using System.IO.IsolatedStorage;

namespace ModernScrum
{
    class ViewModel
    {
        private List<string> _availableScales = new List<string>(new string[] {
            "standard",
            "fibonacci",
            "doubling",
            "t-shirt"
        });

        public List<string> AvailableScales
        {
            get
            {
                return _availableScales;
            }
        }

        private string _scaleName = "standard";

        public string Scale
        {
            get
            {
                return _scaleName;
            }
        }

        private List<ListItem> _items;

        public List<ListItem> Items
        {
            get
            {
                return _items;
            }
        }


        public ViewModel()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string selectedScale;
            bool settingExists = settings.TryGetValue("selectedScale", out selectedScale);
            if (!settingExists)
            {
                selectedScale = "standard";
            }

            _scaleName = selectedScale;
            switch (selectedScale)
            {
                case "fibonacci":
                    _items = new List<ListItem>(new ListItem[] {
                        new ListItem(10, "0"),
                        new ListItem(11, "1"),
                        new ListItem(12, "2"),
                        new ListItem(13, "3"),
                        new ListItem(14, "5"),
                        new ListItem(15, "8"),
                        new ListItem(16, "13"),
                        new ListItem(17, "21"),
                        new ListItem(18, "34"),
                        new ListItem(19, "55"),
                        new ListItem(20, "89"),
                        new ListItem(21, "144"),
                        new ListItem(22, "?")
                    });
                    break;
                case "t-shirt":
                    _items = new List<ListItem>(new ListItem[] {
                        new ListItem(10, "XS"),
                        new ListItem(11, "S"),
                        new ListItem(12, "M"),
                        new ListItem(13, "L"),
                        new ListItem(14, "XL"),
                        new ListItem(15, "XXL"),
                        new ListItem(16, "∞"),
                        new ListItem(17, "?")
                    });
                    break;
                case "doubling":
                    _items = new List<ListItem>(new ListItem[] {
                        new ListItem(10, "0"),
                        new ListItem(11, "1/2"),
                        new ListItem(12, "1"),
                        new ListItem(13, "2"),
                        new ListItem(14, "4"),
                        new ListItem(15, "8"),
                        new ListItem(16, "16"),
                        new ListItem(17, "32"),
                        new ListItem(18, "64"),
                        new ListItem(19, "?")
                    });
                    break;
                default:
                    _items = new List<ListItem>(new ListItem[] {
                        new ListItem(10, "0"),
                        new ListItem(11, "1/2"),
                        new ListItem(12, "1"),
                        new ListItem(13, "2"),
                        new ListItem(14, "3"),
                        new ListItem(15, "5"),
                        new ListItem(16, "8"),
                        new ListItem(17, "13"),
                        new ListItem(18, "20"),
                        new ListItem(19, "40"),
                        new ListItem(20, "100"),
                        new ListItem(21, "?")
                    });
                    break;
            }
        }
    }
}
