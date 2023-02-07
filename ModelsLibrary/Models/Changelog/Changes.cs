using System;


namespace ModelsLibrary.Models
{
    public class Changes
    {
        public string Name { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Change { get; set; }        

        public Changes(string name, string propertyName, string oldValue, string newValue) 
        {
            Name = name;
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
            Change = $"{DateTime.Now}\nИзменение: {propertyName}\n{oldValue} -> {newValue}";
        }
    }
}
