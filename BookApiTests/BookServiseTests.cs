using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository;
using API_mokymai.Repository.IRepository;
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
        private readonly IBookRepository _bookRepo;
        public BookServiseTests(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }


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
            //var actual = _bookRepo.GetAsync(i => i.Id == 1);
            //var expected = true;

            //Assert.AreEqual(expected, actual.Result.Quantity > 0);

            //sukuriame imituojanti servisa
            var repoMockBook = new Mock<IBookRepository>();
            var repoMockReservation = new Mock<IReservationRepository>();


            //konfiguruojame imituojanti servisa
            var fakeRepoBook = BookSet.Books.First();
            var fakeRepoReservation = ReservationSet.Reservations;

            repoMockBook.Setup(r => r.GetAsync(b => b.Id == fakeRepoBook.Id, true)).ReturnsAsync(fakeRepoBook);
            repoMockReservation.Setup(r => r.GetAllAsync(b => b.BookId == fakeRepoBook.Id)).ReturnsAsync(fakeRepoReservation);
            //var sut = new CarLeasingService(repository_mock.Object);
            //sut.ChangeYear(1, 2001);

            //repository_mock.Verify(r => r.Update(fakeObj), Times.Once);
            //var expected = new DateTime(2001, 1, 1);
            //Assert.AreEqual(expected, fakeObj.Year);

        }
    }
}