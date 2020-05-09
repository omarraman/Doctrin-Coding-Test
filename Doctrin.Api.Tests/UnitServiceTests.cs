using System;
using System.Threading.Tasks;
using AutoMapper;
using Doctrin.Api.Controllers;
using Doctrin.Api.Mapping;
using Doctrin.Api.Resources;
using Doctrin.Core.Entities;
using Doctrin.Core.Repositories;
using Doctrin.Core.Services;
using Doctrin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Doctrin.Api.Tests
{
    [TestClass]
    public class UnitServiceTests
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var unit = new Unit();
            unit.ParentId = 1;
            unit.Name = "Test";
            unit.Id = 2;

            var mockRepo = new Mock<IUnitRepository>();
            mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(unit));

            mockUnitOfWork.Setup(m => m.Units).Returns(mockRepo.Object);

            var service = new UnitService(mockUnitOfWork.Object);
            
            var result = await service.GetAsync(1);

            Assert.AreEqual(result.Id, 2);


        }

    }
}
