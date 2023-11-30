using FitnessClubCopy.Controllers;
using FitnessClubCopy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.IO;
using Xunit;

namespace TestProject
{
    public class ContactTest
    {
        [Fact]
        public async Task ProcessFormIndex_ValidModelState_RedirectsToIndexAction()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FitnessClubDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new FitnessClubDbContext(options))
            {
                var controller = new ContactController(context);
                var feedbackForm = new FeedbackForm
                {
                    Name = "Name",
                    Email = "name@example.com",
                    SubjectOfMessage = "subject",
                    Message = "message"
                };

                // Act
                var result = await controller.ProcessFormIndex(feedbackForm) as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
                Assert.Equal("Home", result.ControllerName);
            }
        }


    }
}
