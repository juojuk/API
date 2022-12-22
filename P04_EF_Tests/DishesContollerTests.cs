using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using P04_EF_Applying_To_API.Controllers;
using P04_EF_Applying_To_API.Models;
using P04_EF_Applying_To_API.Models.Dto;
using P04_EF_Applying_To_API.Repository.IRepository;
using P04_EF_Applying_To_API.Services.Adapters.IAdapters;
using System.Linq.Expressions;

namespace P04_EF_Tests
{
    [TestClass]
    public class DishesContollerTests
    {
        [TestMethod]
        public async Task GetDishes_ShouldReturnAllDishes()
        {
            var dish_repository_mock = new Mock<IDishRepository>();
            var dish_adapter_mock = new Mock<IDishAdapter>();
            var fakeObj = new List<Dish>
            {
                new Dish{DishId = 1, Name = "First dish", Type = "Test type", SpiceLevel = "Very spicy", Country = "Test country", RecipeItems = new List<RecipeItem>()},
                new Dish{DishId = 2, Name = "First dish", Type = "Test type", SpiceLevel = "Very spicy", Country = "Test country", RecipeItems = new List<RecipeItem>()},

            };
            var expected = new List<GetDishDTO>
            {
                new GetDishDTO(fakeObj[0]),
                new GetDishDTO(fakeObj[1]),
            };
            dish_repository_mock.Setup(d => d.GetAllAsync(It.IsAny<Expression<Func<Dish, bool>>>()))
                .ReturnsAsync(fakeObj);
            var dishController = new DishesController(dish_repository_mock.Object, dish_adapter_mock.Object);

            // Act
            var sut = await dishController.GetDishes() as OkObjectResult;
            Assert.AreEqual(expected[0].Name, (sut.Value as List<GetDishDTO>)[0]);
            Assert.AreEqual(expected[1].Name, (sut.Value as List<GetDishDTO>)[1]);

        }
    }
}