using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SIGEBI.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Web.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public EditorialesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("api/Home/editoriales");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var editoriales = JsonConvert.DeserializeObject<List<Editorial>>(json);
                return View(editoriales);
            }
            return View(new List<Editorial>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Editorial editorial)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var json = JsonConvert.SerializeObject(editorial);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Home/editoriales", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(editorial);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/Home/editoriales/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var editorial = JsonConvert.DeserializeObject<Editorial>(json);
                return View(editorial);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Editorial editorial)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var json = JsonConvert.SerializeObject(editorial);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"api/Home/editoriales/{editorial.id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(editorial);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/Home/editoriales/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var editorial = JsonConvert.DeserializeObject<Editorial>(json);
                return View(editorial);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.DeleteAsync($"api/Home/editoriales/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return NotFound();
        }
    }
}