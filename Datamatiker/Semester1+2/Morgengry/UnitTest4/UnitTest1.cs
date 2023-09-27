using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgengry;
using static Morgengry.Controller;

namespace MorgenGryTest4
{
    [TestClass]
    public class UnitTest4
    {
        Book b1, b2, b3;
        Amulet a1, a2, a3;
        Course c1, c2;
        /*
        CourseRepository courses;
        MerchandiseRepository merch;

        [TestInitialize]
        public void Init()
        {
            // Arrange
            b1 = new Book("1");
            b2 = new Book("2", "Falling in Love with Yourself");
            b3 = new Book("3", "Spirits in the Night", 123.55);

            a1 = new Amulet("11");
            a2 = new Amulet("12", Level.high);
            a3 = new Amulet("13", Level.low, "Capricorn");

            c1 = new Course("Eufori med røg");
            c2 = new Course("Nuru Massage using Chia Oil", 157);

            courses = new CourseRepository();
            merch = new MerchandiseRepository();

            // Act
            merch.AddMerchandise(b1);
            merch.AddMerchandise(b2);
            merch.AddMerchandise(b3);

            merch.AddMerchandise(a1);
            merch.AddMerchandise(a2);
            merch.AddMerchandise(a3);

            courses.AddCourse(c1);
            courses.AddCourse(c2);
        }

        [TestMethod]
        public void TestGetBook()
        {
            // Assert
            Assert.AreEqual(b2, merch.GetMerchandise("2"));
        }
        [TestMethod]
        public void TestGetAmulet()
        {
            // Assert
            Assert.AreEqual(a3, merch.GetMerchandise("13"));
        }
        [TestMethod]
        public void TestGetCourse()
        {
            // Assert
            Assert.AreEqual(c1, courses.GetCourse("Eufori med røg"));
        }
        [TestMethod]
        public void TestGetTotalValueForBook()
        {
            // Assert
            Assert.AreEqual(183.55, merch.GetTotalValue());
        }
        [TestMethod]
        public void TestGetTotalValueForAmulet()
        {
            // Assert
            Assert.AreEqual(183.55, merch.GetTotalValue());
        }
        [TestMethod]
        public void TestGetTotalValueForCourse()
        {
            // Assert
            Assert.AreEqual(2625.0, courses.GetTotalValue());
        }*/
    }

}
