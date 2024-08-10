using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IT.Tangdao.Framework.Helpers;
namespace WCF发送Xml
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Student”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Student.svc 或 Student.svc.cs，然后开始调试。
    public class Student : IStudent
    {     
        public string GetName()
        {
            return "李四";
        }

        public StudentModel GetModel()
        {
            string path = "E://Temp//Student.xml";
            string xmlContent = TxtFolderHelper.ReadByFileStream(path);
            StudentModel student = XmlFolderHelper.Deserialize<StudentModel>(xmlContent);
            return student;
        }

        public List<StudentModel> GetStudentsFromXml()
        {
            string path = "E://Temp//StudentList.xml";
            string xmlContent = TxtFolderHelper.ReadByFileStream(path);
            Data datas = XmlFolderHelper.Deserialize<Data>(xmlContent);
            List<StudentModel> students = datas.Students;
            return students;

        }
    }

    public class TxtFolderHelper
    {
        public static string SimpleRead(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            return File.ReadAllText(path);
        }

        public static string[] SimpleReadStringArray(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            return File.ReadAllLines(path);
        }

        public static string ReadByFileStream(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        public static Task<string> SimpleReadAsync(string path)
        {
            return Task.Factory.StartNew(() =>
            {
                if (!File.Exists(path))
                {
                    return null;
                }
                return File.ReadAllText(path);
            });
        }
        public static Task<string[]> SimpleReadStringArrayAsync(string path)
        {
            return Task.Factory.StartNew(() =>
            {
                if (!File.Exists(path))
                {
                    return null;
                }
                return File.ReadAllLines(path);
            });
        }
        public static async Task<string> ReadByFileStreamAsync(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return await sr.ReadToEndAsync();
                }
            }
        }
    }

    public class XmlFolderHelper
    {
        public static string SerializeXML<T>(T t)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
                xmlSerializer.Serialize(sw, t);
                return sw.ToString();
            }
        }

        /// <summary>
        /// XML反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(xml);
            return (T)xmlSerializer.Deserialize(stringReader);
        }
    }
}
