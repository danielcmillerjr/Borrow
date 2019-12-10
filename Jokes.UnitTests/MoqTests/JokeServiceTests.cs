using Jokes.WebApi.Controllers;
using Jokes.WebApi.Data.GenericRepository;
using Jokes.WebApi.Models;
using Jokes.WebApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jokes.UnitTests.MoqTests
{
    [TestFixture]
    public class JokeServiceTests
    {
        [SetUp]
        public void Startup()
        {

        }

        [TearDown]
        public void TearDown() { }

        [Test]
        public async Task JokeTestGetAsync()
        {
            IEnumerable<Joke> expectedList = new List<Joke>
            {
                new Joke {
                    Answer = "",
                    Question = "",
                    JokeId = Guid.NewGuid(),
                    RandomId = 1
                }
            };

            var logger = new Mock<ILogger<JokeController>>();
            var mockService = new Mock<IJokeService>();
            mockService.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(expectedList));

            var serviceUnderTest = new JokeController(logger.Object, mockService.Object);
            var results = await serviceUnderTest.GetAsync();

            Assert.AreEqual(expectedList.FirstOrDefault()?.JokeId, results.FirstOrDefault()?.JokeId);
        }


        [Test]
        public async Task JokeTestGetRandomAsync()
        {


            var expected = new Joke
            {
                Answer = "",
                Question = "",
                JokeId = Guid.NewGuid(),
                RandomId = 1
            }; 
            IEnumerable<Joke> expectedList = new List<Joke>
            {
               expected
            };

            var logger = new Mock<ILogger<JokeController>>();
            var mockService = new Mock<IJokeService>();
            mockService.Setup(repo => repo.GetAsync()).Returns(Task.FromResult(expectedList));
            mockService.Setup(repo => repo.GetByRandomIdAsync(1)).Returns(Task.FromResult(expected));

            var serviceUnderTest = new JokeController(logger.Object, mockService.Object);
            var results = await serviceUnderTest.GetRandomAsync();

            Assert.AreEqual(expected.JokeId, results.JokeId);
        }
    }
}
