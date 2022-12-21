using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository;
using API_mokymai.Repository.IRepository;
using API_mokymai.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookApiTests
{
    [TestClass]
    public class BookServiseTests
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

        [TestMethod]
        public void CanBorrowBookTest()
        {
            var fakeBook = BookSet.Books.First();
            var fakeReservations = ReservationSet.Reservations;

            var sut = new BookManager();
            var actual = sut.IsAvailableBook(fakeBook, fakeReservations);
            var expected = false;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void PostMeasureTest()
        {
            var measureRepoMock = new Mock<IMeasureRepository>();

            var fakeMeasure = new API_mokymai.Models.Measure
            {
                Id = 1,
                MaxBorrowingDays = 28,
                MaxOverdueBooks = 2,
                MaxBooksOnHand = 5,
                MinBorrowingFee = 10,
                MaxBorrowingFee = 50,
            };
            //measureRepoMock.Setup(r => r.GetAsync(m => m.Id == It.IsAny<Measure>().Id, true));
            var expected = measureRepoMock.Object.CreateAsync(fakeMeasure);
            measureRepoMock.Verify(r => r.ExistAsync(m => m.Id == fakeMeasure.Id), Times.Once);
            Assert.AreEqual(expected.IsCompleted, true);

        }

    }
}