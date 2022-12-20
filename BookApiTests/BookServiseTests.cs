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
    }
}