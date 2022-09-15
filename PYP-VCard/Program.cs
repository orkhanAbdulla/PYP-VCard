using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PYP_VCard.DAL;
using PYP_VCard.Models;
using System.Net;
using System.Text.Json.Serialization;

AppDbContext context = new AppDbContext();
try
{
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://randomuser.me/api?results=50");
    HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
    Stream responseStream = response.GetResponseStream();
    StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
    string json = readerStream.ReadToEnd();
    readerStream.Close();
    var result = JsonConvert.DeserializeObject<dynamic>(json);
    foreach (var item in result.results)
    {
        VCard vCard = new VCard()
        {
            Firstname = item.name.first.ToString(),
            Surname = item.name.last.ToString(),
            Email = item.email.ToString(),
            Phone = item.phone.ToString(),
            Country = item.location.country.ToString(),
            City = item.location.city.ToString(),
        };
        await context.VCards.AddAsync(vCard);
        await context.SaveChangesAsync();
    }
}
catch (Exception)
{
    Console.WriteLine("Host problem!!!");
}

foreach (var vCard in context.VCards.ToList())
{
    Console.WriteLine(vCard);
}