using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;


namespace TestLayer
{
    class AreaContextTests
    {
        private ApplicationDBContext _dbContext;
        private AreaContext _areaContext;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            _dbContext = new ApplicationDBContext(builder.Options);
            _areaContext = new AreaContext(_dbContext);
        }

        [Test]
        public void CreateAreaShouldReturnOK()
        {
            Assert.DoesNotThrow(() => {
                var area = new Area { Name = "Plovdiv" };
                _areaContext.Create(area);
            });
        }

        [Test]
        public void ReadAreaShouldReturnOK()
        {
            var area = new Area { Name = "Plovdiv" };
            _areaContext.Create(area);

            area = _areaContext.Read(1);

            Assert.IsNotNull(area);
        }

        [Test]
        public void ReadAllAreasShouldReturnOK()
        {
            var areaPlovdiv = new Area { Name = "Plovdiv" };
            _areaContext.Create(areaPlovdiv);

            var areaSofia = new Area { Name = "Sofia" };
            _areaContext.Create(areaSofia);

            var areas = _areaContext.ReadAll();

            Assert.IsNotNull(areas);
        }

        [Test]
        public void UpdateAreaShouldReturnOK()
        {
            var area = new Area { Name = "Plovdiv" };
            _areaContext.Create(area);

            area = _areaContext.Read(1);
            area.Name = "Sofia";

            _areaContext.Update(area);

            area = _areaContext.Read(1);

            Assert.IsTrue(area.Name == "Sofia");
        }

        [Test]
        public void DeleteAreaShouldReturnOK()
        {
            var area = new Area { Name = "Plovdiv" };
            _areaContext.Create(area);

            _areaContext.Delete(1);

            area = _areaContext.Read(1);

            Assert.IsNull(area);
        }
    }
}