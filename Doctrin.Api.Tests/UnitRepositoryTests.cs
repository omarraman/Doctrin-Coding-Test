using System;
using System.Threading.Tasks;
using AutoMapper;
using Doctrin.Api.Controllers;
using Doctrin.Api.Mapping;
using Doctrin.Api.Resources;
using Doctrin.Core.Entities;
using Doctrin.Core.Repositories;
using Doctrin.Core.Services;
using Doctrin.Data;
using Doctrin.Data.Repositories;
using Doctrin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Doctrin.Api.Tests
{
    [TestClass]
    public class UnitRepositoryTests
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var unit = new Unit();
            unit.ParentId = 1;
            unit.Name = "Test";

            var repository = GetInMemory();

            await repository.AddAsync(unit);

            var addedUnit = await repository.SingleOrDefaultAsync(m=>m.Id==unit.Id);

            Assert.IsNotNull(addedUnit);
            Assert.AreEqual(unit.Id, addedUnit.Id);



        }

        private IUnitRepository GetInMemory()
        {
            DbContextOptions<MyDbContext> options;
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseInMemoryDatabase("DoctrinDb");
            options = builder.Options;
            MyDbContext dbContext = new MyDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return new UnitRepository(dbContext);


        }

    }
}
