using System.IO;
using System.Collections.Generic;
using Framework.Data;
using System;
using System.Text.Json;
using Microsoft.VisualBasic;

namespace Framework.Utils
{
    public class JsonReader
    {
        public static List<LoginDataModel> GetLoginData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "LoginData.json");

        try
        {
             string jsonText = File.ReadAllText(filePath);

             var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

             List <LoginDataModel> dataList = JsonSerializer.Deserialize<List<LoginDataModel>>(jsonText, options) ?? new List<LoginDataModel>();
             
                  return dataList;

            }
            catch(Exception ex)
            {
                Console.WriteLine($"CRITICAL ERROR : Failed to load and deserialize json files : {ex.Message}");

                return new List<LoginDataModel>();

            }
        

        }

        
    }

}