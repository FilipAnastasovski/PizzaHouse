using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaHouse.Data;
using PizzaHouse.Models;
using PizzaHouse.ViewModels;

namespace PizzaHouse.Services
{
    public static class Mapper
    {
        public static PizzaViewModel ToModel(Pizza pizza, List<Ingredient> allingredients)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                BasePrice = pizza.GetPrice(SizeEnum.Small),
                AllIngredients = allingredients.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList(),
                SelectedIngredients = pizza.Ingredients.Select(x => x.Id).ToList()
            };
        }
    }
}

