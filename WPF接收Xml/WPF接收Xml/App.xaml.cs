using IT.Tangdao.Framework;
using IT.Tangdao.Framework.Extensions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF接收Xml
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var container = new TangdaoContainer();
            ServerLocator.InitContainer(container);
            container.RegisterType<MainWindow>();
            container.RegisterType<MainWindowViewModel>();
        }
    }
}
