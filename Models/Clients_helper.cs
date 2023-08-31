using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework_11.Models
{
    public class ListClientHelper : DependencyObject
    {
        //К свойству Items можно привиязать данные в XAML, так как оно объявленно как DependencyProperty
        public ObservableCollection<Client> Items
        {
            get { return (ObservableCollection<Client>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
          DependencyProperty.Register
          ("Items",
          typeof(ObservableCollection<Client>),
          typeof(ListClientHelper),
          new UIPropertyMetadata(null));


    }
}
