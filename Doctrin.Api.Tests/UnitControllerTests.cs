using System;
using System.Threading.Tasks;
using AutoMapper;
using Doctrin.Api.Controllers;
using Doctrin.Api.Mapping;
using Doctrin.Api.Resources;
using Doctrin.Core.Entities;
using Doctrin.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Doctrin.Api.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var mockUnitService = new Mock<IUnitService>();
            var unit = new Unit();
            unit.ParentId = 1;
            unit.Name = "Test";
            unit.Id = 2;

            var mockMapper = new Mock<IMapper>();
            var profile = new MappingProfile();
            var configuratio = new MapperConfiguration(cfg=>cfg.AddProfile(profile));
            var mapper = new Mapper(configuratio);

            mockUnitService.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(unit));
            var controller = new OrganisationsController(mockUnitService.Object,mapper);
            var response = await controller.Get(1);
            var x = response.Result as OkObjectResult;
            Assert.IsInstanceOfType(x.Value,typeof(UnitResource));

            Assert.AreEqual((x.Value as UnitResource).Id,2);


        }
    }
}
