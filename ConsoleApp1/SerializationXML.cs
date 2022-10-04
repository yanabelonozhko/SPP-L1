using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab1
{
    public class SerializationXML : ISerialization
    {
        TraceResult _result;
        public SerializationXML(TraceResult result) 
        {
            _result = result;
        }  
        public void ShowResult(Stream stream)
        {
            string serializedResult;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResult),
            new Type[] { typeof(MethodResult), typeof(ThreadResult) });
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, _result);
                serializedResult = textWriter.ToString();
            }
            byte[] buffer = Encoding.Default.GetBytes(serializedResult);
            stream.Write(buffer, 0, buffer.Length);
        } 
    }
}
