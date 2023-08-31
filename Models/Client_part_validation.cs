using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    internal partial class Client : IDataErrorInfo, IEditableObject
    {
        #region Реализация IDataErrorInfo
        public string Error
        {
            get
            {
                string error;
                StringBuilder sb = new StringBuilder();

                error = this["Lastname"];
                if (error != string.Empty)
                    sb.AppendLine(error);

                error = this["Name"];
                if (error != string.Empty)
                    sb.AppendLine(error);

                error = this["Patronymic"];
                if (error != string.Empty)
                    sb.AppendLine(error);

                error = this["Phone"];
                if (error != string.Empty)
                    sb.AppendLine(error);

                error = this["Passport"];
                if (error != string.Empty)
                    sb.AppendLine(error);

                if (!string.IsNullOrEmpty(sb.ToString()))
                    return sb.ToString();

                return "";
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Lastname":
                        if (string.IsNullOrEmpty(this.Lastname))
                            return "Введите фамилию!";
                        break;
                    case "Name":
                        if (string.IsNullOrEmpty(this.Name))
                            return "Введите имя!";
                        break;
                    case "Patronymic":
                        if (string.IsNullOrEmpty(this.Patronymic))
                            return "Введите отчество!";
                        break;
                    case "Phone":
                        if (string.IsNullOrEmpty(this.Phone))
                            return "Введите номер телефона!";
                        break;
                    case "Passport":
                        if (string.IsNullOrEmpty(this.Passport))
                            return "Введите номер паспорта!";
                        break;
                    default:
                        break;
                }
                return "";
            }
        }
        #endregion

        #region Реализация IEditableObject
        bool inEdit = false;
        Client tempClient;

        /// <summary>
        /// При начале редактирования, запоминает изначальные данные
        /// </summary>
        public void BeginEdit()
        {
            if (inEdit)
                return;

            inEdit = true;
            tempClient = new Client(this.Id,this.Lastname,this.Name,this.Patronymic,this.Phone,this.Passport);            
        }

        /// <summary>
        /// При отмене редактирования все возвращает назад, как было
        /// </summary>
        public void CancelEdit()
        {
            if (!inEdit)
                return;

            inEdit = false;
            this.Lastname = tempClient.Lastname;
            this.Name = tempClient.Name;
            this.Patronymic = tempClient.Patronymic;
            this.Phone = tempClient.Phone;
            this.Passport = tempClient.Passport;

            tempClient = null!;
        }

        public void EndEdit()
        {
            if (!inEdit)
                return;

            inEdit = false;
            tempClient = null!;
        }
        #endregion
    }
}
