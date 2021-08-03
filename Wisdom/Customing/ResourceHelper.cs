using System.Windows;

namespace Wisdom.Customing
{
    public static class ResourceHelper
    {
        public static string FindName(ResourceDictionary dictionary, object resourceItem)
        {
            foreach (object key in dictionary.Keys)
                if (dictionary[key] == resourceItem)
                    return key.ToString();
            return null;
        }
        public static Style GetStyle(string name)
        {
            return Application.Current.FindResource(name) as Style;
        }
    }
}
