using DBProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DBProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientTypesList = GetAllClientTypes();
            var nationalitisList = GetAllNationalities();
            var currencyTypesList = GetAllCurrencyTypes();

            var clientsList = GetAllClients(clientTypesList, nationalitisList);
            var productsList = GetAllProducts();
            GetAllAccouns(clientsList, productsList, currencyTypesList);

            InsertNewClient();

            Console.ReadKey();
        }

        static void InsertNewClient()
        {
            using (SberContext db = new SberContext())
            {
                var client = new Client
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Surname = "Test",
                    BirthDate = new DateOnly(1990, 2, 5),
                    Nationality = 2,
                    ClientType = 1
                };
                db.Clients.Add(client);

                db.SaveChanges();
                Console.WriteLine("\nДобавлен новый клиент");
            }
        }

        static List<DictClientType> GetAllClientTypes()
        {
            using (SberContext db = new SberContext())
            {
                return db.DictClientTypes.ToList();
            }
        }

        static List<DictNationality> GetAllNationalities()
        {
            using (SberContext db = new SberContext())
            {
                return db.DictNationalities.ToList();
            }
        }

        static List<DictCurrency> GetAllCurrencyTypes()
        {
            using (SberContext db = new SberContext())
            {
                return db.DictCurrencies.ToList();
            }
        }

        static List<Client> GetAllClients(List<DictClientType> ClientTypesList, List<DictNationality> NationalitiesList)
        {
            using (SberContext db = new SberContext())
            {
                Console.WriteLine("Клиенты Сбербанка:");
                foreach (var client in db.Clients)
                {
                    var clientType = ClientTypesList?.FirstOrDefault(x => x.IdCode == client.ClientType)?.ValueShort;
                    var clientNanionality = NationalitiesList?.FirstOrDefault(x => x.IdCode == client.Nationality)?.ValueShort;
                    Console.WriteLine($"{client.ClientId.ToString()} {client.LastName} {client.FirstName} {client.Surname ?? ""} {client.BirthDate.ToString()} {clientType} {clientNanionality}");
                }

                return db.Clients.ToList(); ;
            }
        }

        static List<Product> GetAllProducts()
        {
            using (SberContext db = new SberContext())
            {
                Console.WriteLine("Продукты Сбербанка:");
                foreach (var product in db.Products)
                {
                    Console.WriteLine($"{product.ProductId.ToString()} {product.ProductName} {product.Remarks?? ""}");
                }

                return db.Products.ToList(); ;
            }
        }

        static void GetAllAccouns(List<Client> ClientsList, List<Product> ProductsList, List<DictCurrency> CurrencyTypeList)
        {
            using (SberContext db = new SberContext())
            {
                Console.WriteLine("Счета Сбербанка:");
                foreach (var account in db.Accounts)
                {
                    var clientName = $"{ClientsList?.FirstOrDefault(x => x.ClientId == account.ClientId)?.LastName} {ClientsList?.FirstOrDefault(x => x.ClientId == account.ClientId)?.FirstName} {ClientsList?.FirstOrDefault(x => x.ClientId == account.ClientId)?.Surname}";
                    var productName = ProductsList?.FirstOrDefault(x => x.ProductId == account.ProductId)?.ProductName;
                    var currency = CurrencyTypeList?.FirstOrDefault(x => x.IdCode == account.Currency).ValueShort;
                    Console.WriteLine($"{account.AccountId.ToString()} {account.AccountNumber} {clientName} {productName} {currency} {account.OpeningDate.ToString()}");
                }
            }
        }
    }
}