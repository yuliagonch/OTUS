using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebClient
{
    internal class DataProvider
    {
        public static string customerByIdEndpoint = "/customers";
        public static string allCustomersEndpoint = "/customers/all";
        public static string createCustomerEndpoint = "/customers/create";

        public static DataProvider GetInstance(string host, int port)
        {
            if (_instance == null)
                _instance = new DataProvider(host, port);

            return _instance;
        }

        /// <summary>
        /// Получает клиента по его идентификатору customerId
        /// </summary>
        /// <param name="customerId">Идентификатор клиента</param>
        /// <returns>Объект Customer с данными клиента</returns>
        public async Task<Customer> GetCustomerById(long customerId)
        {            
            try
            {
                var res = await GetCommand($"https://{_host}:{_port}{customerByIdEndpoint}/{customerId}");
                if (res?.Length > 0)
                    return JsonConvert.DeserializeObject<Customer>(res);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Create customer by Id error:");
                Console.Error.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Создает нового клиента
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns>Идентификатор Id нового клиента</returns>
        public async Task<long?> CreateCustomer(Customer newCustomer)
        {
            if (newCustomer == null)
                return null;

            var request = new CustomerCreateRequest
            {
                Id = newCustomer.Id,
                Firstname = newCustomer.Firstname,
                Lastname = newCustomer.Lastname
            };

            try
            {
                var res = await PostCommand($"https://{_host}:{_port}{createCustomerEndpoint}", JsonConvert.SerializeObject(request));
                if (res?.Length > 0)
                    return JsonConvert.DeserializeObject<Customer>(res)?.Id;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Create customer by Id error:");
                Console.Error.WriteLine(ex.Message);
            }

            return null;
        }
        
        private DataProvider(string host, int port)
        {
            _host = host;
            _port = port;
        }

        private async Task<string> GetCommand(string url)
        {
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"Error: {response.StatusCode}");
                return "";
            }

            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> PostCommand(string url, string data)
        {
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"Error: {response.StatusCode}");
                return "";
            }

            return await response.Content.ReadAsStringAsync();
        }

        private static DataProvider _instance;
        private HttpClient _client = new HttpClient();
        private string _host;
        private int _port;
    }
}
