using AutoBogus;
using Moq;
using CodeTest.Controllers;
using EngineeringWeekly.API.Componets;
using EngineeringWeekly.API.Componets.Interfaces;
using EngineeringWeekly.DTOS;
using FluentAssertions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EngineeringWeekly.Tests.Components
{
    public class ChuckNorrisJokeGetterTest
    {
        Mock<ILogger<IChuckNorrisJokeGetter>> Logger { get; }
        ExternalAPIUrs ExternalAPIUrs { get; }
        IChuckNorrisJokeGetter ChuckNorrisJokeGetter { get; }
        public ChuckNorrisJokeGetterTest()
        {
            Logger = new Mock<ILogger<IChuckNorrisJokeGetter>>();
            ExternalAPIUrs = new ExternalAPIUrs
            {
                 ChuckNorrisAPIURL = "https://api.chucknorris.io/jokes/"
            };
            ChuckNorrisJokeGetter = new ChuckNorrisJokeGetter(Logger.Object, Options.Create(ExternalAPIUrs));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task ChuckNorrisJokeGetter_GetJokeNullAndEmptyCategory_Return_IsSuccess(string category)
        {
            //Arrange

            //Act
            var result = await ChuckNorrisJokeGetter.GetJoke(category);

            //Validate

            //Assert
            result.IsSuccess.Should().BeTrue(); 
            result.Value.Should().BeOfType<string>();
            result.Value.Should().NotBeNull();
        }
        [Theory]
        [InlineData("animal")]
        [InlineData("career")]
        [InlineData("celebrity")]
        [InlineData("dev")]
        [InlineData("explicit")]
        [InlineData("fashion")]
        [InlineData("food")]
        [InlineData("history")]
        [InlineData("money")]
        [InlineData("movie")]
        [InlineData("music")]
        [InlineData("political")]
        [InlineData("religion")]
        [InlineData("science")]
        [InlineData("sport")]
        [InlineData("travel")]
        public async Task ChuckNorrisJokeGetter_GetJokeValidCategories_Return_IsSuccess(string category)
        {
            //Arrange

            //Act
            var result = await ChuckNorrisJokeGetter.GetJoke(category);

            //Validate

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeOfType<string>();
            result.Value.Should().NotBeNull();
        }

        [Theory]
        [InlineData("No Valid ategory 01")]
        [InlineData("No Valid ategory 02")]
        [InlineData("No Valid ategory 03")]
        [InlineData("No Valid ategory 04")]
        [InlineData("No Valid ategory 05")]
        public async Task ChuckNorrisJokeGetter_GetJokeInalidCategories_Return_IsFailed(string category)
        {
            //Arrange

            //Act
            var result = await ChuckNorrisJokeGetter.GetJoke(category);

            //Validate

            //Assert
            result.IsFailed.Should().BeTrue();
        }

        [Fact]
        public async Task ChuckNorrisJokeGetter_GetCategories_Return_IsSuccess()
        {
            //Arrange

            //Act
            var result = await ChuckNorrisJokeGetter.GetJokeCategories();

            //Validate

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeOfType<List<string>>();
            result.Value.Should().NotBeNull();
            result.Value.Should().HaveCountGreaterThan(1);  
        }

    }
}
