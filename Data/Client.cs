using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Data
{
    /// <summary>
    /// Класс клиента для хранения его данных
    /// </summary>
    internal class Client
    {
        private string lastname;
        private string name;
        private string patronymic;
        private string phone;
        private string passport;
        private DateTime editTime;
        private string editData;
        private string editType;    //добавил или изменил
        private string editWho;

        public string Lastname
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Patronymic
        {
            get { return this.patronymic; }
            set { this.patronymic = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Passport
        {
            get { return this.passport; }
            set { this.passport = value; }
        }

        public DateTime EditTime
        {
            get { return this.editTime; }
            set { this.editTime = value; }
        }

        public string EditData
        {
            get { return this.editData; }
            set { this.editData = value; }
        }

        public string EditType
        {
            get { return this.editType; }
            set { this.editType = value; }
        }

        public string EditWho
        {
            get { return this.editWho; }
            set { this.editWho = value; }
        }

        public Client(string lastname, string name, string patronymic, string phone, string passport)
        {
            this.lastname = lastname;
            this.name = name;
            this.patronymic = patronymic;
            this.phone = phone;
            this.passport = passport;
            this.editTime = DateTime.Now;
            this.editWho = "Мененджер";
            this.editType = "Добавление";
            this.editData = "Новый клиент";
        }

        public Client()
        {
            Random rnd = new Random();
            this.lastname = "Фамилия_" + rnd.Next(0, 100).ToString();
            this.name = "Имя_" + rnd.Next(0, 100).ToString();
            this.patronymic = "Отчество_" + rnd.Next(0, 100).ToString(); ;
            this.phone = Math.Round((rnd.NextDouble() + 1) * 1e+10).ToString();
            this.passport = Math.Round((rnd.NextDouble() + 1) * 1e+9).ToString();
            this.editTime = DateTime.Now;
            this.editWho = "Мененджер";
            this.editType = "Добавление";
            this.editData = "Новый клиент";
        }

        public override string ToString()
        {
            return $"{Lastname} {Name} {Patronymic}";
        }
    }
}
