using IT.Tangdao.Framework.DaoMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF接收Xml
{
    public class Student : BaseDaoViewModel
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private int _age;

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

    }
}
