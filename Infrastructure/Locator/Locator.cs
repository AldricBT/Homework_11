using Homework_11.Models;
using Homework_11.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Infrastructure.Locator
{
    public class Locator
    {
        
        internal MainWindowViewModel MainWindowVM { get; }
        internal AddClientWindowViewModel AddClientWindowVM { get; }

        public Locator()
        {
            MainWindowVM = new MainWindowViewModel();
            AddClientWindowVM = new AddClientWindowViewModel();
        }
    }
}
