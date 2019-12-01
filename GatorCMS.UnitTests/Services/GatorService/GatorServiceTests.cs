using System.Collections.Generic;
using FluentAssertions;
using GatorCMS.Core.Models;
using GatorCMS.Core.Services.GatorPagesService;
using NSubstitute;
using NUnit.Framework;

namespace GatorCMS.UnitTests.Services.GatorService {
    public class GatorServiceTests {
        private IGatorPagesService _gatorPagesService;

        [SetUp]
        public void Setup () {
            _gatorPagesService = Substitute.For<IGatorPagesService> ();
        }

        
    }
}