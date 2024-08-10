using IT.Tangdao.Framework.DaoAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WPF接收Xml.ServiceReference;

namespace WPF接收Xml
{
    public class StudentService
    {
        public static WPF接收Xml.Student ConverterStudent(ServiceReference.Student student)
        {
            return new WPF接收Xml.Student
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
            };
        }

        public static List<WPF接收Xml.Student> ConvertStudentList(List<ServiceReference.Student> serviceStudents)
        {
            return serviceStudents.Select(serviceStudent => new WPF接收Xml.Student
            {
                Id = serviceStudent.Id,
                Age = serviceStudent.Age,
                Name = serviceStudent.Name
              
            }).ToList();
        }
    }
}
