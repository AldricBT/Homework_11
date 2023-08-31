using Homework_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Homework_11.Infrastructure.Validation
{
    class ColumnValidation : ValidationRule
    {
        private ListClientHelper _listClient;

        //Данное свойство является вспомогательным, служит для реализации DependencyProperty
        public ListClientHelper ListClient
        {
            get { return _listClient; }
            set { _listClient = value; }
        }


        //Проверка на валидность данных
        public override ValidationResult Validate
          (object value, System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;
            Client client = bg.Items[0] as Client;

            //Если в коллекции находится объект с таким же паспортом сообщаем об ошибке!
            var result = from c in ListClient.Items
                         where c != client &&
                         (c.Passport == client.Passport)
                         select c;
            if (result.Any())
            {
                return new ValidationResult(false, "Этот паспорт уже зарегистрирован в базе");
            }

            return ValidationResult.ValidResult;
        }
    }
}
