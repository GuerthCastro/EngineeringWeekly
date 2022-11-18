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


    }
}
