using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VitecMvSemester3.Models;

namespace VitecMvSemester3.Controllers
{
    public class ProduktsController : Controller
    {
        private readonly VitecMvSemester3Context _context;

        public ProduktsController(VitecMvSemester3Context context)
        {
            _context = context;
        }

        // GET: Produkts
        public async Task<IActionResult> Index()
        {
            
            List<Produkt> newProd = new List<Produkt>();
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://localhost:44334/api/Products");
                    response.EnsureSuccessStatusCode();

                    string stringResult = await response.Content.ReadAsStringAsync();
                    newProd = JsonConvert.DeserializeObject<List<Produkt>>(stringResult);
                }
                catch (HttpRequestException requestException)
                {
                    return BadRequest($"{requestException}");
                }
            }
            return View(newProd);
        }

        // GET: Produkts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // GET: Produkts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produkts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,Pris,Type,Beskrivelse")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produkt);
        }

        // GET: Produkts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            Produkt prod;
            if (id == null)
            {
                return NotFound();
            }
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://localhost:44334/api/Products/" + id);
                    response.EnsureSuccessStatusCode();

                    string stringResult = await response.Content.ReadAsStringAsync();
                    prod = JsonConvert.DeserializeObject<Produkt>(stringResult);
                }
                catch (HttpRequestException requestException)
                {
                    return BadRequest($"{requestException}");
                }
            }
            return View(prod);

        }

        // POST: Produkts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Navn,Pris,Type,Beskrivelse")] Produkt produkt)
        {
            if (id != produkt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            var json = JsonConvert.SerializeObject(produkt, Formatting.Indented);
                            var stringContent = new StringContent(json);
                            await client.PutAsync("https://localhost:44334/api/Products/" + id, stringContent);
                            //response.EnsureSuccessStatusCode();
                        }
                        catch (HttpRequestException requestException)
                        {
                            return BadRequest($"{requestException}");
                        }
                    }
               /* New n;
                if (id == null)
                {
                    return NotFound();
                }

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var response = await client.GetAsync("https://localhost:44365/api/values/" + id);
                        response.EnsureSuccessStatusCode();

                        string stringResult = await response.Content.ReadAsStringAsync();
                        n = JsonConvert.DeserializeObject<New>(stringResult);
                    }
                    catch (HttpRequestException requestException)
                    {
                        return BadRequest($"{requestException}");
                    }
                }
                return View(n);*/

                /*_context.Update(produkt);
                await _context.SaveChangesAsync();*/

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Produkts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        // POST: Produkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var produkt = await _context.Produkt.FindAsync(id);
            _context.Produkt.Remove(produkt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktExists(long id)
        {
            return _context.Produkt.Any(e => e.Id == id);
        }
    }
}
