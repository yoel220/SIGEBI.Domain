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
    public class AutoresController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public AutoresController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        // GET: Listado
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("api/Home/autores");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var autores = JsonConvert.DeserializeObject<List<Autor>>(json);
                return View(autores);
            }
            return View(new List<Autor>());
        }

        // GET: Formulario Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agregar Autor
        [HttpPost]
        public async Task<IActionResult> Create(Autor autor)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var json = JsonConvert.SerializeObject(autor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Home/autores", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = "Error al agregar el autor.";
            return View();
        }

        // GET: Editar Autor
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/Home/autores/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var autor = JsonConvert.DeserializeObject<Autor>(json);
                return View(autor);
            }

            return NotFound();
        }

        // POST: Editar Autor
        [HttpPost]
        public async Task<IActionResult> Edit(Autor autor)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var json = JsonConvert.SerializeObject(autor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/Home/autores/{autor.id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = "Error al editar el autor.";
            return View(autor);
        }

        // GET: Confirmación Eliminar
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"api/Home/autores/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var autor = JsonConvert.DeserializeObject<Autor>(json);
                return View(autor);
            }

            return NotFound();
        }

        // POST: Eliminar Autor
        [HttpPost]
        public async Task<IActionResult> Delete(Autor autor)
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.DeleteAsync($"api/Home/autores/{autor.id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Mensaje = "Error al eliminar el autor.";
            return View(autor);
        }
    }
}