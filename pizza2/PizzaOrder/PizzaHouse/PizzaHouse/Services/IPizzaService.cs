using System.Collections.Generic;
using PizzaHouse.Models;
using PizzaHouse.ViewModels;

namespace PizzaHouse.Services
{
    public interface IPizzaService
    {
        Menu GetMenu();
        void CreatePizza(PizzaViewModel pizza);
        List<Ingredient> GetAllIngredients();
        Pizza GetPizzaDetails(int id);
        PizzaViewModel GetEditPizzaModel(int id);
    }
}
