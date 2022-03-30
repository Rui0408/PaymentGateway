using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PaymentGateway.Srv.Commands.Submit;
using PaymentGateway.Srv.Queries.Payment.Get;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Srv.Services
{
    public class BankServices: IBankService
    {
        private readonly IConfiguration _configuration;
        public BankServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<PaymentResult> Get(System.Guid id)
        {
         
            var httpClient = new HttpClient();

            // Do the actual request and await the response
            var httpResponse = await httpClient.GetAsync(_configuration.GetValue<String>("BankAPIURL") +  "/Bank/Payment" + "/" + id);

            // If the response contains content we want to read it!
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();

                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                return JsonConvert.DeserializeObject<PaymentResult>(responseContent);
            }

            return null;
        }

        public async Task<PaymentProcessResult> Process(PaymentRequest request)
        {
            // Serialize our concrete class into a JSON String
            var stringPayload = JsonConvert.SerializeObject(request);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();

            // Do the actual request and await the response
            var httpResponse = await httpClient.PostAsync(_configuration.GetValue<String>("BankAPIURL") + "/Bank/Payment", httpContent);

            // If the response contains content we want to read it!
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();

                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                return JsonConvert.DeserializeObject<PaymentProcessResult>(responseContent);
            }

            return null;
        }
    }
}
