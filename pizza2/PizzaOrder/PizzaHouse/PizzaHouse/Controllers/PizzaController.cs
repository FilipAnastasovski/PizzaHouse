﻿using Microsoft.AspNetCore.Mvc;
using PizzaHouse.Models;
using PizzaHouse.Services;
using PizzaHouse.ViewModels;

namespace PizzaHouse.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Menu()
        {
            Menu menu = _pizzaService.GetMenu();
            return View(menu);
        }

        public IActionResult ListAllIngredients()
        {
            var allIngredients = _pizzaService.GetAllIngredients();
            return View(allIngredients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var pizza = new PizzaViewModel();
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Create(PizzaViewModel pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            _pizzaService.CreatePizza(pizza);
            return RedirectToAction("Menu", "Pizza");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
           var chosenPizza = _pizzaService.GetPizzaDetails(id);
            return View(chosenPizza);
        }

        [HttpGet]
        public IActionResult Modify(int id)
        {
            var chosenPizza = _pizzaService.GetEditPizzaModel(id);
            return View(chosenPizza);

        }

        [HttpPost]
        public IActionResult Modify(PizzaViewModel pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            _pizzaService.CreatePizza(pizza);
            return RedirectToAction("Menu", "Pizza");
        }
    }
}