using System.Collections.ObjectModel;


namespace ModelsLibrary.Models.Changelog
{
    public class ChangelogData
    {
        private static ObservableCollection<Changes> changelog;
        public ObservableCollection<Changes> Changelog { get => changelog; set => changelog = value; }
        public static void TrackChanges(string name, string propertyName, string oldValue, string newValue)
        {
            if (changelog != null) changelog.Add(new Changes(name, propertyName, oldValue, newValue));
        }
    }
}
