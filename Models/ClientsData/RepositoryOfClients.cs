﻿using Homework_11.Models.ClientsData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Homework_11.Models
{
    internal class RepositoryOfClients : PublicRepositoryOfClients, ICloneable
    {
        #region Поля
        private ObservableCollection<Client> _clients;
        private readonly string _pathToClientsData;

        #endregion

        //public new ObservableCollection<Client> Clients
        //{
        //    get => _clients;
        //    set => _clients = value;
        //}

        /// <summary>
        /// Конструктор. В случае отсутствия базы данных создает случайную
        /// </summary>
        /// <param name="path"></param>
        public RepositoryOfClients(string pathToClientsData)
        {
            _pathToClientsData = pathToClientsData;
            _clients = new ObservableCollection<Client>();
            if (File.Exists(_pathToClientsData))
            {
                Load();
            }
            else
            {
                CreateRandomDB(10);
                Save();
            }

        }

        #region Private methods
        /// <summary>
        /// Создание базы случайных клиентов
        /// </summary>
        /// <param name="size">Количество клиентов в базе</param>
        private void CreateRandomDB(int size)
        {
            Client client;
            for (int i = 0; i < size; i++)
            {
                client = new Client();
                _clients.Add(client);
            }
        }

        

        /// <summary>
        /// Загрузка базы из файла в память
        /// </summary>
        private void Load()
        {
            string jsonString = File.ReadAllText(_pathToClientsData);
            if (_clients != null)
                _clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(jsonString)!;
        }
        #endregion


        #region Public methods
        /// <summary>
        /// Сохранение базы из памяти в файл
        /// </summary>
        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(_clients);
            File.WriteAllText(_pathToClientsData, jsonString);
        }

        /// <summary>
        /// Реализация интерфейса ICloneable для клонирования коллекции
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new RepositoryOfClients(_pathToClientsData);
        }



        ///// <summary>
        ///// Изменение данных клиента
        ///// </summary>
        ///// <param name="clientPresent">Клиент, данные которого нужно изменить</param>
        ///// <param name="clientNew">Данные, на которые изменяются текущие</param>
        //public void Edit(Client clientPresent, Client clientNew)
        //{
        //    int index = _clients.FindIndex(c => c == clientPresent);
        //    if (index != -1)
        //        clients[index] = clientNew;
        //}
        #endregion







    }
}
