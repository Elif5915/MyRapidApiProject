using Microsoft.AspNetCore.Mvc;
using MyRapidApiProject.Models;
using Newtonsoft.Json;

namespace MyRapidApiProject.Controllers;
public class ImdbMovieController : Controller
{
	public async Task<IActionResult> Index()
	{

		var client = new HttpClient();
		var request = new HttpRequestMessage
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
			Headers =
	{
		{ "x-rapidapi-key", "8be6f92745mshaf73e9b2522c8f1p11a194jsn36e6ac18ef3b" },
		{ "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
	},
		};
		using (var response = await client.SendAsync(request))
		{
			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ImdbMovieModel>>(body);
			return View(values.ToList());
		}
	}
}
