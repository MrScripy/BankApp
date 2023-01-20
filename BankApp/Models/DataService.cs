using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;


namespace BankApp.Models
{
    class DataService
    {
        static readonly string _filePath = "data.txt";

        public static ObservableCollection<T> DataLoad<T>()
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

        public static void DataSave(ObservableCollection<Client> data)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, false))
            {
                string output = JsonConvert.SerializeObject(data);
                sw.Write(output);
            }
        }
    }
}
