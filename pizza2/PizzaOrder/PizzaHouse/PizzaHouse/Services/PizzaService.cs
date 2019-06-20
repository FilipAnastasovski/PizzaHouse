using System;
using System.Collections.Generic;
using System.Linq;
using PizzaHouse.Data;
using PizzaHouse.Models;
using PizzaHouse.ViewModels;

namespace PizzaHouse.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Ingredient> _ingredientRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository,
        IRepository<User> userRepository, 
        IRepository<Ingredient> ingredientRepository)
        {
            _pizzaRepository = pizzaRepository;
            _userRepository = userRepository;
            _ingredientRepository = ingredientRepository;
        }

        public Menu GetMenu()
        {
            return new Menu(restaurantName:"Pizza Restaurant", _pizzaRepository.GetAll());
        }

        public void CreatePizza(PizzaViewModel pizza)
        {
            var nextId = Storage.Pizzas.Last().Id + 1;

            var ingredients = new List<Ingredient>();
            foreach (var selectedIngredient in pizza.SelectedIngredients)
            {
                var ingredient = Storage.Ingredients.FirstOrDefault(x => x.Id == selectedIngredient);

                if (ingredient == null)
                {
                    throw new Exception($"Ingredient with Id {selectedIngredient} does not exist");
                }

                ingredients.Add(ingredient);
            }

            var pizzaModel = new Pizza(nextId, pizza.Name, pizza.Description, ingredients, pizza.BasePrice);

            _pizzaRepository.Create(pizzaModel);
        }

        public List<Ingredient> GetAllIngredients()
        {
            //var all = _userRepository.GetAll();
            //_userRepository.Create(new User(2, "Martin", "Skopje", "222222"));
            //var all2 = _userRepository.GetAll();
            //_userRepository.Update(new User(2, "Martin Panovski", "Skopje", "222222"));
            //var all3 = _userRepository.GetAll();
            //var martin = _userRepository.GetById(2);
            //_userRepository.Delete(martin);
            //var all4 = _userRepository.GetAll();

            var allIngredients = _ingredientRepository.GetAll();
            return allIngredients;
        }
        public Pizza GetPizzaDetails(int id)
        {
            return _pizzaRepository.GetById(id);
        }

       public PizzaViewModel GetEditPizzaModel(int id)
        {
            var modifyPizza = _pizzaRepository.GetById(id);
            var sostojki = modifyPizza.Ingredients;
           var mapEdPizza= Mapper.ToModel(modifyPizza, sostojki);
            return mapEdPizza;
        }

       
    }
}
