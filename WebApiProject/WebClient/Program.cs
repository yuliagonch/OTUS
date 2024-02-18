using System;
using System.Threading.Tasks;

namespace WebClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            DataProvider dataProvider = DataProvider.GetInstance("localhost", 5001);

            while (true)
            {
                #region GetCustomerById

                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Принимаем с консоли ID клиента, запрашиваем его с сервера и отображаем полученные данные:");
                Console.WriteLine("");

                Console.WriteLine("Введите Id клиента");
                string idStr = Console.ReadLine();
                long id = 0;
                try
                {
                    id = Convert.ToInt64(idStr);

                    Customer newCustomer = await dataProvider.GetCustomerById(id);
                    if (newCustomer != null)
                    {
                        Console.WriteLine($"Запрос данных клиента по его id = {id} с сервера вернул следующие данные:");
                        Console.WriteLine($"{newCustomer.Firstname} {newCustomer.Lastname}");
                    }
                    else
                        Console.Error.WriteLine($"Ошибка получения клиента по его Id = {id}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }

                #endregion

                #region CreateRandomCustomer

                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Генерируем случайным образом данные для создания нового Клиента на сервере:");
                Console.WriteLine("");

                Console.WriteLine("Введите Id клиента");
                idStr = Console.ReadLine();
                try
                {
                    id = Convert.ToInt64(idStr);

                    Console.WriteLine("Введите имя клиента");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Введите фамилию клиента");
                    string lastName = Console.ReadLine();

                    long? res = await dataProvider.CreateCustomer(new Customer { Id = id, Firstname = firstName, Lastname = lastName });
                    if (res != null)
                        Console.WriteLine($"Создан новый клиент {firstName} {lastName} c Id = {res}");
                    else
                        Console.WriteLine($"Ошибка создания клиента с Id = {id}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }

                #endregion

                #region GetCreatedCustomerById

                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("По полученному Id от сервера запрашиваем созданного пользователя с сервера и выводим на экран");
                Console.WriteLine("");

                Console.WriteLine("Введите Id клиента");
                idStr = Console.ReadLine();
                id = 0;
                try
                {
                    id = Convert.ToInt64(idStr);

                    Customer newCustomer = await dataProvider.GetCustomerById(id);

                    Console.WriteLine($"Запрос данных клиента по его id = {id} с сервера вернул следующие данные:");
                    Console.WriteLine($"{newCustomer.Firstname} {newCustomer.Lastname}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }

                #endregion
            }
        }
    }
}