using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace lab3.Models
{
    public class Directory
    {
        public string last_name { get; set; }
        public string phone_number { get; set; }


    }

    public class BKS_DB
    {
        List<Directory> directories;
        string path = @"C:\ycheba\3course2sem\ASP.NET\lab3\lab3\lab3\App_Data\directory.json";
        public BKS_DB()
        {
            directories = new List<Directory>();
        }

        public List<Directory> GetAll()
        {
            
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                  directories=JsonConvert.DeserializeObject<List<Directory>>(sr.ReadToEnd());
                }
            }
            return directories;
        }

        public List<Directory> Add(string last_name,string phone_number)
        {
            directories = GetAll();
            directories.Add(new Directory { last_name = last_name, phone_number = phone_number });
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(JsonConvert.SerializeObject(directories));
            }
            return directories;
        }
        public List<Directory> Update(int id,string last_name,string phone_number)
        {
            directories = GetAll();
            directories[id].last_name = last_name;
            directories[id].phone_number = phone_number;
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(JsonConvert.SerializeObject(directories));
            }
            return directories;
        }
        public List<Directory> Delete(int id)
        {
            directories = GetAll();
            directories.RemoveAt(id);
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(JsonConvert.SerializeObject(directories));
            }
            return directories;
        }
    }
}