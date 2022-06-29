using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;

namespace wordypkg
{
    [Serializable]

    public class WordsList
    {
        public List<Words> myList { get; set; }
    }

    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }

    public class Words
    {
        public string Word { get; set; }
        public string Phonetic { get; set; }
        public string Definition { get; set; }
    }
}
