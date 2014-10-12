using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BoatClub.Model;
using System.IO;

namespace BoatClub.Serializer
{
    class SerializerXML
    {
        private string path = System.IO.Path.GetFullPath(@"../../Serializer\MemberList.xml");
        public MemberList SerializerXMLIsNullOrNot(MemberList member)
        {
            if (member == null)
            {
                SerializeToXML(member);
            }
            member = DeserializeFromXML();
            return member;
        }

        public void SerializeToXML(MemberList members)
        {            
            XmlSerializer serializer = new XmlSerializer(typeof(MemberList));
            TextWriter textWriter = new StreamWriter(path);
            serializer.Serialize(textWriter, members);
            textWriter.Close();
        }

        public MemberList DeserializeFromXML()
        {            
            XmlSerializer deserializer = new XmlSerializer(typeof(MemberList));
            TextReader textReader = new StreamReader(path);
            MemberList members;
            members = (MemberList)deserializer.Deserialize(textReader);
            textReader.Close();
            return members;
        }
    }
}
