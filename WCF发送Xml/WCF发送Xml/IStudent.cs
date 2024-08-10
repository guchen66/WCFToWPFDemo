using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;

namespace WCF发送Xml
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IStudent”。
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract]
        string GetName();

        [OperationContract]
        StudentModel GetModel();
       
        [OperationContract]
        List<StudentModel> GetStudentsFromXml();
    }

    [XmlRoot("Student", Namespace = "")]
    [DataContract(Name = "Student")]
    public class StudentModel
    {
        [XmlAttribute("target")]
        public string Target { get; set; }

        [XmlElement("Id")]
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [XmlElement("Age")]
        [DataMember(Name = "Age")]
        public int Age { get; set; }

        [XmlElement("Name")]
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
    [XmlRoot("Data")]
    [DataContract(Name = "Data")]
    public class Data
    {
        [XmlElement("Student")]
        [DataMember(Name = "Student")]
        public List<StudentModel> Students { get; set; }
    }
}
