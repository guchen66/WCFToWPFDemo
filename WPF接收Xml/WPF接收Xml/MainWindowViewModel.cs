using IT.Tangdao.Framework.DaoMvvm;
using IT.Tangdao.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF接收Xml.ServiceReference;

namespace WPF接收Xml
{
    public class MainWindowViewModel:BaseDaoViewModel
    {
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get => _students??(_students=new ObservableCollection<Student>());
            set => SetProperty(ref _students, value);
        }
        public MainWindowViewModel()
        {
           /* Students = new ObservableCollection<Student>()
            {
                new Student(){ Id=1,Age=18,Name="李四"},
            };*/
             Name=GetName();
          

        }
        public static string SimpleReadSpecifiedLine(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                return line;
            }
            return null;
        }
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string GetName()
        {
            StudentClient client = new StudentClient();
            var students= client.GetStudentsFromXml();
            var lists=students.ToList();
            Students=StudentService.ConvertStudentList(lists).ToObservableCollection();
         //   Students.Add(StudentService.Converter(lists.Where(x=>x.Id==1).First()));
            var name = client.GetName();
            // 使用 "client" 变量在服务上调用操作。

            // 始终关闭客户端。
            client.Close();
            return name;
        }
    }
}
