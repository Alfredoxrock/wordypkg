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
            request(args[0]);
            if(args[1] != null && args[1] == "example")
            {
                examples(args[0]);
            }
            else if(args[1] != null && args[1] == "synonyms")
            {
                synonym(args[0]);
            }
            else if(args[1] != null && args[1] == "antonyms")
            {
                antonym(args[0]);
            }



        }

        public static void examples(string query)
        {
            try
            {
                //This is a request from a website and it will return a string
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString("https://dictionaryapi.com/a" +
                        "pi/v3/references/thesaurus/json/" + query + "?key=" + key.keyk);
                    // Now parse with JSON.Net
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    var readable = Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                        Newtonsoft.Json.Formatting.Indented);

                    JArray jsonArray = JArray.Parse(readable);
                    //string defi = (string)text[0]["def"];
                    //Console.WriteLine("Definition: " +
                    //jsonArray[0]["def"][0]["sseq"][0][0][1]["dt"][0][1]);
                    Console.WriteLine("Example: " +
                        jsonArray[0]["def"][0]["sseq"][0][0][1]["dt"][1][1][0]["t"]);


                }
            }
            catch
            {
                Console.WriteLine("Examples not found");
            }
        }

        public static void antonym(string query)
        {
            try
            {
                //This is a request from a website and it will return a string
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString("https://dictionaryapi.com/a" +
                        "pi/v3/references/thesaurus/json/" + query + "?key=" + key.keyk);
                    // Now parse with JSON.Net
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    var readable = Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                        Newtonsoft.Json.Formatting.Indented);

                    JArray jsonArray = JArray.Parse(readable);
                    //string defi = (string)text[0]["def"];
                    //Console.WriteLine("Definition: " +
                    //jsonArray[0]["def"][0]["sseq"][0][0][1]["dt"][0][1]);
                    Console.WriteLine("Antonymns: " +
                        jsonArray[0]["meta"]["ants"][0].ToString().Trim('[')
                            .Trim(']').Replace("\"", ""));


                }
            }
            catch
            {
                Console.WriteLine("Antonyms not found");
            }
        }

        public static void synonym(string query)
        {
            try
            {
                //This is a request from a website and it will return a string
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString("https://dictionaryapi.com/a" +
                        "pi/v3/references/thesaurus/json/" + query + "?key=" + key.keyk);
                    // Now parse with JSON.Net
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    var readable = Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                        Newtonsoft.Json.Formatting.Indented);

                    JArray jsonArray = JArray.Parse(readable);
                    //string defi = (string)text[0]["def"];
                    //Console.WriteLine("Definition: " +
                    //jsonArray[0]["def"][0]["sseq"][0][0][1]["dt"][0][1]);
                    Console.WriteLine("Synonyms: " +
                        jsonArray[0]["meta"]["syns"][0].ToString().Trim('[')
                            .Trim(']').Replace("\"", ""));


                }
            }
            catch
            {
                Console.WriteLine("Synonyms not found");
            }
        }

        public static void request(string query)
        {
            try
            {
                //This is a request from a website and it will return a string
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString("https://dictionaryapi.com/a" +
                        "pi/v3/references/thesaurus/json/" + query + "?key=" + key.keyk);
                    // Now parse with JSON.Net
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    var readable = Newtonsoft.Json.JsonConvert.SerializeObject(obj,
                        Newtonsoft.Json.Formatting.Indented);

                    JArray jsonArray = JArray.Parse(readable);
                    //string defi = (string)text[0]["def"];
                    //Console.WriteLine("Definition: " +
                    //jsonArray[0]["def"][0]["sseq"][0][0][1]["dt"][0][1]);
                    Console.WriteLine("Definition: " +
                        jsonArray[0]["shortdef"].ToString().Trim('[')
                            .Trim(']').Replace("\"", ""));


                }
            }
            catch
            {
                Console.WriteLine("Word not found");
            }
            
        }

        

    }
}