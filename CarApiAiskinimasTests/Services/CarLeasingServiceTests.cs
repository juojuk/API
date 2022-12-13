using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarApiAiskinimas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarApiAiskinimas.Repositories;
using Moq;
using Castle.Components.DictionaryAdapter.Xml;

namespace CarApiAiskinimasTests.Services
{
    [TestClass] //atributas test runnerui pasako kuri klase yra testas
    public class CarLeasingServiceTests
    {

        [AssemblyInitialize] //pirmas dalykas kuri bus paleistas
        public static void MyAssemblyInitialize(TestContext context)
        {
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext context) //antras dalykas kuris bus paleistas
        {
            //cia geriausiai vieta atlikti konfiguracinius dalykus
        }

        [TestInitialize]
        public void MyTestInitialize() //trecias dalykas kuris bus paleistas
        {
        }


        #region Paprasti testai
        [TestMethod] //atributas test runnerui pasako kad metodas yra testas
        public void AddPriceTest() //ketvirtas dalykas kuris bus paleistas
        {
            var sut = new CarLeasingService(null);
            var actual = sut.AddPrice(100, 10);
            var expected = 110;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CanLeaseTest()
        {
            var sut = new CarLeasingService(null);
            Assert.ThrowsException<NotImplementedException>(() => sut.CanLease(1));
        }
        #endregion

        #region data-drivem testai
        [DataTestMethod]
        [DataRow(100.0, 1.0, 101.0)]
        [DataRow(100.0, 10.0, 110.0)]
        [DataRow(0.0, 10.0, 0.0)]
        [DataRow(0.0, 1.0, 1.0)]// cia klaidingas testas
        public void AddPrice_FromDataRow_Test(double price, double percent, double expected)
        {
            var sut = new CarLeasingService(null);
            decimal actual = sut.AddPrice(price, percent);

            Assert.AreEqual((decimal)expected, actual);
        }

        public static IEnumerable<object[]> AddPriceTestData => new List<object[]>
        {
            new object[] { 100.0, 1.0, 101.0m },
            new object[] { 100.0, 10.0, 110.0m },
            new object[] { 0.0, 10.0, 0.0m },
            new object[] { 0.0, 1.0, 1.0m }
        };

        [TestMethod]
        [DynamicData(nameof(AddPriceTestData), DynamicDataSourceType.Property)]
        public void AddPrice_FromDynamic_Test(double price, double percent, decimal expected)
        {
            var sut = new CarLeasingService(null);
            decimal actual = sut.AddPrice(price, percent);

            Assert.AreEqual(expected, actual);
        }
        #endregion



        [TestMethod]
        public void ChangeYearTest()
        {
            //sukuriame imituojanti servisa
            var repository_mock = new Mock<ICarRepository>();
            //konfiguruojame imituojanti servisa
            var fakeObj = new CarApiAiskinimas.Models.Car { Id = 1, Year = new DateTime(2020, 1, 1) };
            repository_mock.Setup(r => r.Get(It.IsAny<int>())).Returns(fakeObj);

            var sut = new CarLeasingService(repository_mock.Object);
            sut.ChangeYear(1, 2001);

            repository_mock.Verify(r => r.Update(fakeObj), Times.Once);
            var expected = new DateTime(2001, 1, 1);
            Assert.AreEqual(expected, fakeObj.Year);

        }

    }
}