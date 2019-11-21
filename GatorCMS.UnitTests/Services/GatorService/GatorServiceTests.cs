using System.Collections.Generic;
using FluentAssertions;
using GatorCMS.Core.Models;
using GatorCMS.Core.Services.GatorService;
using NSubstitute;
using NUnit.Framework;

namespace GatorCMS.UnitTests.Services.GatorService {
    public class GatorServiceTests {
        private IGatorService _gatorService;

        [SetUp]
        public void Setup () {
            _gatorService = Substitute.For<IGatorService> ();
        }

        [Test]
        public void Get_ValidRequest_ListGatorBoii () {
            //arrage
            var gatorBoiiList = new List<GatorBoii> {
                new GatorBoii (),
                new GatorBoii (),
                new GatorBoii ()
            };
            _gatorService.Get ().Returns (gatorBoiiList);

            //act
            var result = _gatorService.Get ();

            //assert
            result.Should().AllBeOfType<GatorBoii>().And.HaveCount(3);
            _gatorService.Received().Get();
        }
    }
}