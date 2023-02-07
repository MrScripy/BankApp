using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;


namespace ModelsLibrary.Models
{
    public class DataService
    {
        public static ObservableCollection<T> DataLoad<T>(string _filePath = "data.txt")
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Dispose();
                return new ObservableCollection<T>();
            }
            using (StreamReader sr = new StreamReader(_filePath))
            {
                var json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
            }
        }
        public static void DataSave<T>(ObservableCollection<T> data, string _filePath = "data.txt")
        {
            using (StreamWriter sw = new StreamWriter(_filePath, false))
            {
                string output = JsonConvert.SerializeObject(data);
                sw.Write(output);
            }
        }
    }
}
