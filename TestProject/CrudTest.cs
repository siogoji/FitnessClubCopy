using FitnessClubCopy.Controllers;
using FitnessClubCopy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Security.Claims;
using Xunit;

namespace TestProject
{
    public class CrudTest
    {
        [Fact]
        public void CreateTicket_ValidModelState_RedirectsToTicketsAction()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<FitnessClubDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new FitnessClubDbContext(dbContextOptions);
            var controller = new CrudController(context);

            var ticket = new Ticket
            {
                Type = "ћ≥с€чний",
                Period = "30 дн≥в",
                Price = 1000,
                Description = "јбонемент на м≥с€ць"
            };

            var formFile = new FormFile(new MemoryStream(), 0, 0, "photo", "test.jpg");

            // Act
            var result = controller.Create(ticket, formFile) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Tickets", result.ActionName);
        }


        [Fact]
        public void EditTicket_ValidModelState_RedirectsToTicketsAction()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<FitnessClubDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new FitnessClubDbContext(dbContextOptions);
            var controller = new CrudController(context);

            var existingTicket = new Ticket
            {
                Type = "ћ≥с€чний",
                Period = "30 дн≥в",
                Price = 1000,
                Description = "јбонемент на м≥с€ць"
            };

            context.Tickets.Add(existingTicket);
            context.SaveChanges();

            var updatedTicket = new Ticket
            {
                TicketId = existingTicket.TicketId,
                Type = "Yearly",
                Period = "365 days",
                Price = 500,
                Description = "Yearly Subscription"
            };

            var formFile = new FormFile(new MemoryStream(), 0, 0, "photo", "test.jpg");

            // Act
            var result = controller.Edit(existingTicket.TicketId, updatedTicket, formFile) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Tickets", result.ActionName);
        }

        [Fact]
        public void DeleteTicket_ValidId_RedirectsToTicketsAction()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<FitnessClubDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new FitnessClubDbContext(dbContextOptions);
            var controller = new CrudController(context);

            var ticket = new Ticket
            {
                Type = "ћ≥с€чний",
                Period = "30 дн≥в",
                Price = 1000,
                Description = "јбонемент на м≥с€ць"
            };

            context.Tickets.Add(ticket);
            context.SaveChanges();

            // Act
            var result = controller.DeleteConfirmed(ticket.TicketId) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Tickets", result.ActionName);
        }

        [Fact]
        public void Buy_ValidTicketId_RedirectsToBuyConfirmationAction()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<FitnessClubDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new FitnessClubDbContext(dbContextOptions);
            var controller = new CrudController(context);

            var ticket = new Ticket
            {
                TicketId = 1,
                Type = "ћ≥с€чний",
                Period = "30 дн≥в",
                Price = 1000,
                Description = "јбонемент на м≥с€ць"
            };

            context.Tickets.Add(ticket);
            context.SaveChanges();

            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "testuser"
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var identity = new ClaimsIdentity(claims, "Test");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = controller.Buy(ticket.TicketId) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("BuyConfirmation", result.ActionName);
            Assert.Equal(ticket.TicketId, result.RouteValues["id"]);
        }

        [Fact]
        public void BuyConfirmation_ValidTicketId_ReturnsViewWithTicket()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<FitnessClubDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new FitnessClubDbContext(dbContextOptions);
            var controller = new CrudController(context);

            var ticket = new Ticket
            {
                TicketId = 1,
                Type = "ћ≥с€чний",
                Period = "30 дн≥в",
                Price = 1000,
                Description = "јбонемент на м≥с€ць"
            };

            context.Tickets.Add(ticket);
            context.SaveChanges();

            // Act
            var result = controller.BuyConfirmation(ticket.TicketId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ticket, result.Model);
        }


    }
}
