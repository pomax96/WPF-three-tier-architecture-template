using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjectTemplate.ViewModel;

namespace WpfProjectTemplate.DI
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get { return IocKernel.Get<MainViewModel>(); } // Loading UserControlViewModel will automatically load the binding for IStorage
        }
    }
}
