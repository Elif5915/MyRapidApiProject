using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MyRapidApiProject.Controllers;
public class ExchangeController : Controller
{
    public async Task<IActionResult> Index()
    {

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://currency-conversion-and-exchange-rates.p.rapidapi.com/convert?from=USD&to=TRY&amount=1"),
            Headers =
    {
        { "x-rapidapi-key", "8be6f92745mshaf73e9b2522c8f1p11a194jsn36e6ac18ef3b" },
        { "x-rapidapi-host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(body);
            //burada amaç şu body gelen değeri json formatında yakaladık.json formatını bozmadık aşağıdaki kodda
            ///ise json gelen tüm verilerden sadece kendi istediğim alanı değişkenin değerini almak istediğimde onu belirttim 
            ////ve result degerini aldık.
            ViewBag.data = json["result"];
        }
        return View();
    }
}
