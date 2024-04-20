using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

public class PaymentService
{
    public async Task<int> CreateTransaction(decimal amount, string user, string callback)
    {
        Random random = new Random();
        await Task.Delay(random.Next(20000, 30000));

        HttpClient client = new HttpClient();
        var content = new StringContent($"Payment successful for to user {user}", Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync(callback, content);
        while (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            response = await client.PostAsync(callback, content);
        }
        return 200;
    }
}