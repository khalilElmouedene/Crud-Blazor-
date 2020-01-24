using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaysDataLibrary;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp11.Data
{
    public class paysService
    {
        string baseUrl = "http://localhost:35000/api/Pays";

        public async Task<PaysDto[]> GetPaysAsync()
        {
            HttpClient http = new HttpClient();
            var json = JObject.Parse(await http.GetStringAsync(baseUrl));
            return JsonConvert.DeserializeObject<PaysDto[]>(json["items"].ToString());
        }
        public async Task<PaysDto> GetPaysByIdAsync(int id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}/{id}");
            return JsonConvert.DeserializeObject<PaysDto>(json);
        }

        public async Task<HttpResponseMessage> InsertPayAsync(AddPays paysDto)
        {
            var client = new HttpClient();
            return await client.PostAsync(baseUrl, getStringContentFromObject(paysDto));
        }

        public async Task<HttpResponseMessage> UpdatePayAsync(int id, PaysDto paysDto)
        {
            var client = new HttpClient();
            return await client.PutAsync($"{baseUrl}/{id}", getStringContentFromObject(paysDto));
        }

        public async Task<HttpResponseMessage> DeletePayAsync(string id)
        {
            var client = new HttpClient();
            return await client.DeleteAsync($"{baseUrl}/{id}");
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
