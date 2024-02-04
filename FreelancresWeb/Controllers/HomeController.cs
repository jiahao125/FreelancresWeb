using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using Microsoft.CodeAnalysis;
using System.Collections.ObjectModel;
using FreelancresWeb.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Reflection.Metadata;

namespace FreelancresWeb.Controllers
{
    public class HomeController:Controller
    {
        public List<Freelancers> freelancers1 { get; set; }
        public async Task<IActionResult> Index()
        {
            await GetUser();
            return View();
        }
        private async Task GetUser()
        {
            var client = new HttpClient();
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.GetAsync("https://localhost:7138/GetFreelances");
            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                freelancers1 = JsonConvert.DeserializeObject<List<Freelancers>>(jsonString);
            }
            ViewBag.User = freelancers1;
        }

        public async Task<IActionResult> Insert_PostBack(string userName)
        {
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(userName);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:7138/AddFreelancers?userName="+userName, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
                
        }

        public async Task<IActionResult> Update_PostBack(string oldName,string newName)
        {
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(oldName + newName);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://localhost:7138/UpdateFreelancer?oldName=" + oldName +"&newName=" +newName, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Delete_PostBack(string userName)
        {
            var client = new HttpClient();
            string json = JsonConvert.SerializeObject(userName);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7138/DeleteFreelancers?userName=" + userName);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

    }
}
