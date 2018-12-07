using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MCI_Common.Communication
{
    static public class Serialization
    {
        /// <summary>
        /// Serialize an object to a XML string
        /// </summary>
        /// <param name="AnObject">The object to serialize</param>
        /// <returns>an XML string</returns>
        public static string SerializeAnObject(object AnObject)
        {
            XmlSerializer Xml_Serializer = new XmlSerializer(AnObject.GetType());

            StringWriter Writer = new StringWriter();
            Xml_Serializer.Serialize(Writer, AnObject);

            return Writer.ToString();
        }

        /// <summary>
        /// Deserialize an XML string to an object
        /// </summary>
        /// <param name="XmlOfAnObject">the xml string</param>
        /// <param name="ObjectType">The type of the object</param>
        /// <returns>A typed object</returns>
        public static Object DeSerializeAnObject(string XmlOfAnObject, Type ObjectType)
        {
            StringReader StrReader = new StringReader(XmlOfAnObject);
            XmlSerializer Xml_Serializer = new XmlSerializer(ObjectType);
            XmlTextReader XmlReader = new XmlTextReader(StrReader);

            try
            {
                Object AnObject = Xml_Serializer.Deserialize(XmlReader);
                return AnObject;
            }
            finally
            {
                XmlReader.Close();
                StrReader.Close();
            }
        }
    }
}
