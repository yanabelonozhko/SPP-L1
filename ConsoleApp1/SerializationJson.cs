using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace lab1
{
    public class SerializationJson:ISerialization
    {
        TraceResult _result;
        
        public SerializationJson(TraceResult result) 
        {
            _result = result;
        }
        public void ShowResult(Stream stream) 
        {
            string serializedResult = JsonConvert.SerializeObject(_result, Formatting.Indented);
            byte[] buffer = Encoding.Default.GetBytes(serializedResult);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
