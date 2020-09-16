using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI { 
    class Program 
    {

        public static string autoor = "";
        static async Task<Root> NewsInformation(int n)
        {
            HttpClient httpClient = new HttpClient();
            var NewsString = httpClient.GetAsync($"http://newsapi.org/v2/everything?q=bitcoin&from=2020-08-16&sortBy=publishedAt&apiKey=a328d18fddb14ea1938c4a37ab650ee3").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var root = JsonConvert.DeserializeObject<Root>(NewsString);
            Root Roots = new Root { Rauthor = root.articles[n].author, Rtitle = root.articles[n].title, Rdescription = root.articles[n].description, RurlToImage = root.articles[n].urlToImage, RpublishedAt = root.articles[n].publishedAt };
            return Roots;
        }
        static void Main(string[] args) 
        {
            NewsInformation(0);
            Console.WriteLine(autoor);
            Console.Read();


        } 
    } 
}
public class Source
{
    public string id { get; set; }
    public string name { get; set; }
}

public class Article
{
    public Source source { get; set; }
    public string author { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string urlToImage { get; set; }
    public DateTime publishedAt { get; set; }
    public string content { get; set; }
}

public class Root
{
    public string RurlToImage { get; set; }
    public DateTime RpublishedAt { get; set; }
    public string Rauthor { get; set; }
    public string Rtitle { get; set; }
    public string Rdescription { get; set; }
    public string status { get; set; }
    public int totalResults { get; set; }
    public List<Article> articles { get; set; }
}

