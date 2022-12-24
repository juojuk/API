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

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAvailableReservationTest()
        {
            var fakeMeasures = new List<Measure>()
            {
                new Measure()
                {
                    Id = 1,
                    MaxBorrowingDays = 28,
                    MaxOverdueBooks = 2,
                    MaxBooksOnHand = 5,
                    MinBorrowingFee = 10,
                    MaxBorrowingFee = 50,
                }
            };
        

        var fakeReservations = new List<Reservation>()
            {
                new Reservation{Id = 1, CheckOutDateTime = new DateTime(2020, 1, 1), ReturnDateTime = new DateTime(2020, 6, 1), PersonId = 4, BookId = 1, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 2, CheckOutDateTime = new DateTime(2020, 2, 1), ReturnDateTime = new DateTime(2020, 6, 1), PersonId = 4, BookId = 2, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 3, CheckOutDateTime = new DateTime(2020, 3, 1), ReturnDateTime = null, PersonId = 4, BookId = 3, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 4, CheckOutDateTime = new DateTime(2020, 4, 1), ReturnDateTime = null, PersonId = 4, BookId = 4, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 5, CheckOutDateTime = new DateTime(2020, 5, 1), ReturnDateTime = null, PersonId = 4, BookId = 5, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 6, CheckOutDateTime = new DateTime(2020, 6, 1), ReturnDateTime = null, PersonId = 4, BookId = 6, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
            };

            var sut = new BookManager();
            var actual = sut.IsAvailableReservation(fakeMeasures, fakeReservations);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNumberOfBooksOnHandTest()
        {
            var fakeMeasures = new List<Measure>()
            {
                new Measure()
                {
                    Id = 1,
                    MaxBorrowingDays = 28,
                    MaxOverdueBooks = 2,
                    MaxBooksOnHand = 5,
                    MinBorrowingFee = 10,
                    MaxBorrowingFee = 50,
                }
            };

            var fakeReservations = new List<Reservation>()
            {
                new Reservation{Id = 1, CheckOutDateTime = new DateTime(2020, 1, 1), ReturnDateTime = new DateTime(2020, 6, 1), PersonId = 4, BookId = 1, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 2, CheckOutDateTime = new DateTime(2020, 2, 1), ReturnDateTime = new DateTime(2020, 6, 1), PersonId = 4, BookId = 2, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 3, CheckOutDateTime = new DateTime(2020, 3, 1), ReturnDateTime = null, PersonId = 4, BookId = 3, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 4, CheckOutDateTime = new DateTime(2020, 4, 1), ReturnDateTime = null, PersonId = 4, BookId = 4, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 5, CheckOutDateTime = new DateTime(2020, 5, 1), ReturnDateTime = null, PersonId = 4, BookId = 5, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 6, CheckOutDateTime = new DateTime(2020, 6, 1), ReturnDateTime = null, PersonId = 4, BookId = 6, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
            };

            var sut = new BookManager();
            var actual = sut.GetNumberOfBooksOnHand(fakeReservations);
            var expected = 4;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void GetNumberOfOverDueBooksTest()
        {
            var fakeMeasures = new List<Measure>()
            {
                new Measure()
                {
                    Id = 1,
                    MaxBorrowingDays = 28,
                    MaxOverdueBooks = 2,
                    MaxBooksOnHand = 5,
                    MinBorrowingFee = 10,
                    MaxBorrowingFee = 50,
                }
            };

            var fakeReservations = new List<Reservation>()
            {
                new Reservation{Id = 1, CheckOutDateTime = new DateTime(2022, 1, 1), ReturnDateTime = new DateTime(2022, 1, 31), PersonId = 4, BookId = 1, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 2, CheckOutDateTime = new DateTime(2022, 2, 1), ReturnDateTime = new DateTime(2022, 2, 28), PersonId = 4, BookId = 2, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 3, CheckOutDateTime = new DateTime(2022, 11, 1), ReturnDateTime = null, PersonId = 4, BookId = 3, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 4, CheckOutDateTime = new DateTime(2022, 11, 1), ReturnDateTime = null, PersonId = 4, BookId = 4, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 5, CheckOutDateTime = new DateTime(2022, 12, 1), ReturnDateTime = null, PersonId = 4, BookId = 5, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 6, CheckOutDateTime = new DateTime(2022, 12, 1), ReturnDateTime = null, PersonId = 4, BookId = 6, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
            };

            var sut = new BookManager();
            var actual = sut.GetNumberOfOverDueBooks(fakeReservations);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetBorrowingFeeTest()
        {
            var fakeMeasures = new List<Measure>()
            {
                new Measure()
                {
                    Id = 1,
                    MaxBorrowingDays = 28,
                    MaxOverdueBooks = 2,
                    MaxBooksOnHand = 5,
                    MinBorrowingFee = 10,
                    MaxBorrowingFee = 50,
                    BorrowingFeeRatio = 0.0m,
                },
                new Measure()
                {
                    Id = 2,
                    MaxBorrowingDays = 21,
                    MaxOverdueBooks = 2,
                    MaxBooksOnHand = 5,
                    MinBorrowingFee = 10,
                    MaxBorrowingFee = 50,
                    BorrowingFeeRatio = 0.2m,
                }

            };

            var fakeReservations = new List<Reservation>()
            {
                new Reservation{Id = 1, CheckOutDateTime = new DateTime(2022, 1, 1), ReturnDateTime = new DateTime(2022, 1, 31), PersonId = 4, BookId = 1, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 2, CheckOutDateTime = new DateTime(2022, 2, 1), ReturnDateTime = new DateTime(2022, 2, 28), PersonId = 4, BookId = 2, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 3, CheckOutDateTime = new DateTime(2022, 11, 1), ReturnDateTime = new DateTime(2022, 11, 15), PersonId = 4, BookId = 3, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 4, CheckOutDateTime = new DateTime(2022, 11, 1), ReturnDateTime = new DateTime(2022, 11, 15), PersonId = 4, BookId = 4, MeasureId = 1, Measure = fakeMeasures.Find(m => m.Id == 1) },
                new Reservation{Id = 5, CheckOutDateTime = new DateTime(2022, 12, 1), ReturnDateTime = null, PersonId = 4, BookId = 5, MeasureId = 2, Measure = fakeMeasures.Find(m => m.Id == 2) },
                new Reservation{Id = 6, CheckOutDateTime = new DateTime(2022, 12, 1), ReturnDateTime = null, PersonId = 4, BookId = 6, MeasureId = 2, Measure = fakeMeasures.Find(m => m.Id == 2) },
            };

            var sut = new BookManager();
            var actual = sut.GetBorrowingFee(fakeReservations);
            var expected = 1.6;

            Assert.AreEqual((decimal)expected, actual);
        }


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
            //measureRepoMock.Setup(r => r.CreateAsync(fakeMeasure));
            //measureRepoMock.Object.CreateAsync();
            //measureRepoMock.Setup(r => r.GetAsync(m => m.Id == It.IsAny<Measure>().Id, true));
            //var expected = measureRepoMock.Object.CreateAsync(fakeMeasure);
            //measureRepoMock.Verify(r => r.ExistAsync(m => m.Id == fakeMeasure.Id));
            //measureRepoMock.Verify(r => r.CreateAsync(fakeMeasure), Times.Once);
            //var actual = measureRepoMock.Object.GetAsync(m => m.Id == 1).Result;
            //Assert.AreEqual(expected, 1);

        }

    }
}