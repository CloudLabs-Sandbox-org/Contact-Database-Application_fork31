using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new UserController();
        }

        [Test]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = users;

            // Act
            var result = _controller.Index() as ViewResult;
            var model = result.Model as List<User>;

            // ClassicAssert
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(users.Count, model.Count);
            ClassicAssert.AreEqual(users[0].Id, model[0].Id);
            ClassicAssert.AreEqual(users[0].Name, model[0].Name);
            ClassicAssert.AreEqual(users[0].Email, model[0].Email);
            ClassicAssert.AreEqual(users[1].Id, model[1].Id);
            ClassicAssert.AreEqual(users[1].Name, model[1].Name);
            ClassicAssert.AreEqual(users[1].Email, model[1].Email);
        }

        [Test]
        public void Details_ExistingUserId_ReturnsViewWithUser()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = users;
            var userId = 1;

            // Act
            var result = _controller.Details(userId) as ViewResult;
            var model = result.Model as User;

            // ClassicAssert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(users[0].Id, model.Id);
            ClassicAssert.AreEqual(users[0].Name, model.Name);
            ClassicAssert.AreEqual(users[0].Email, model.Email);
        }

        [Test]
        public void Details_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = users;
            var userId = 3;

            // Act
            var result = _controller.Details(userId);

            // ClassicAssert
            ClassicAssert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Create_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            var result = _controller.Create(user) as RedirectToRouteResult;

            // ClassicAssert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void Edit_ExistingUserId_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = users;
            var userId = 1;
            var updatedUser = new User { Id = 1, Name = "John Doe", Email = "johndoe@example.com" };

            // Act
            var result = _controller.Edit(userId, updatedUser) as RedirectToRouteResult;

            // ClassicAssert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void Edit_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = users;
            var userId = 3;
            var updatedUser = new User { Id = 3, Name = "John Doe", Email = "johndoe@example.com" };

            // Act
            var result = _controller.Edit(userId, updatedUser);

            // ClassicAssert
            ClassicAssert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Delete_ExistingUserId_RedirectsToIndex()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = users;
            var userId = 1;

            // Act
            var result = _controller.Delete(userId) as RedirectToRouteResult;

            // ClassicAssert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void Delete_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = users;
            var userId = 3;

            // Act
            var result = _controller.Delete(userId);

            // ClassicAssert
            ClassicAssert.IsInstanceOf<HttpNotFoundResult>(result);
        }
    }
}
