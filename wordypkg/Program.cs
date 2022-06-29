using System;
using wordypkg;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace wordypkg
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if(args.Length < 1)
            {
                Console.WriteLine("Please enter a vocabulary word");
                Environment.Exit(0);
            }

            string query = args[0];
            
            //This is a request from a website and it will return a string
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://dictionaryapi.com/api/v3/references/thesaurus/json/"+ query +"?key=" + key.keyk);
                // Now parse with JSON.Net
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                var readable = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                JArray jsonArray = JArray.Parse(readable);
                //string defi = (string)text[0]["def"];
                //Console.WriteLine("Definition: " + jsonArray[0]["def"][0]["sseq"][0][0][1]["dt"][0][1]);
                Console.WriteLine("Definition: " + jsonArray[0]["shortdef"].ToString().Trim('[').Trim(']').Replace("\"",""));


            }
            

        }

        

    }
}