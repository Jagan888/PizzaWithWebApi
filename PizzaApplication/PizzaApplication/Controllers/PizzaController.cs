using Microsoft.AspNetCore.Mvc;
using PizzaApplication.Models;
using PizzaApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaService _service;

        public PizzaController(PizzaService pizzaService)
        {
            _service = pizzaService;
        }
        public IActionResult GetAll()
        {
            List<string> PizzaList1 = new List<string>();
            if (TempData["token"] != null)
            {
                string PizzaList = _service.GetAll(TempData.Peek("token").ToString());
                ViewBag.Pizza = PizzaList;
                PizzaList1 = PizzaList.Split('}').ToList();
                
              
                
            }
            var PizzaList2 = new PizzaDTO()
            {
                Pizza = PizzaList1
            };

            return View(PizzaList2);
        }
    }
}
