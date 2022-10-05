using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

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
            serializedResult = FormatingXml(serializedResult);
            byte[] buffer = Encoding.Default.GetBytes(serializedResult);
            stream.Write(buffer, 0, buffer.Length);
        }

        public string FormatingXml(string xml)
        {
            var stringBuilder = new StringBuilder();
            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }
    }
}
