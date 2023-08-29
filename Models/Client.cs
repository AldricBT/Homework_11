﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    /// <summary>
    /// Класс клиента для хранения его данных
    /// </summary>
    /// 
    // По идее должен реализовывать ViewModel! или INotifyPropertyChanged
    internal class Client : ICloneable
    {
        private int _id;
        private string _lastname;
        private string _name;
        private string _patronymic;
        private string _phone;
        private string _passport;
        private DateTime _editTime;
        private string _editData;
        private string _editType;    //добавил или изменил
        private string _editWho;

        public int Id
        {
            get => _id;
        }
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Passport
        {
            get { return _passport; }
            set { _passport = value; }
        }

        public DateTime EditTime
        {
            get { return _editTime; }
            set { _editTime = value; }
        }

        public string EditData
        {
            get { return _editData; }
            set { _editData = value; }
        }

        public string EditType
        {
            get { return _editType; }
            set { _editType = value; }
        }

        public string EditWho
        {
            get { return _editWho; }
            set { _editWho = value; }
        }

        public Client(int id, string lastname, string name, string patronymic, string phone, string passport)
        {
            _id = id;
            _lastname = lastname;
            _name = name;
            _patronymic = patronymic;
            _phone = phone;
            _passport = passport;
            _editTime = DateTime.Now;
            _editWho = "Мененджер";
            _editType = "Добавление";
            _editData = "Новый клиент";
        }

        private Client(int id, string lastname, string name, string patronymic, string phone, string passport, 
            DateTime editTime, string editWho, string editType, string editData)
        {
            _id = id;
            _lastname = lastname;
            _name = name;
            _patronymic = patronymic;
            _phone = phone;
            _passport = passport;
            _editTime = editTime;
            _editWho = editWho;
            _editType = editType;
            _editData = editData;
        }

        public object Clone()
        {
            return new Client(_id, _lastname, _name, _patronymic, _phone, _passport, 
                _editTime, _editWho, _editType, _editData);
        }

        //public Client()
        //{
        //    Random rnd = new Random();
        //    _lastname = "Фамилия_" + rnd.Next(0, 100).ToString();
        //    _name = "Имя_" + rnd.Next(0, 100).ToString();
        //    _patronymic = "Отчество_" + rnd.Next(0, 100).ToString(); ;
        //    _phone = Math.Round((rnd.NextDouble() + 1) * 1e+10).ToString();
        //    _passport = Math.Round((rnd.NextDouble() + 1) * 1e+9).ToString();
        //    _editTime = DateTime.Now;
        //    _editWho = "Мененджер";
        //    _editType = "Добавление";
        //    _editData = "Новый клиент";
        //}
    }
}