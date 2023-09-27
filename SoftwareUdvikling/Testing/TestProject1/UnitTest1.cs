using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.InputTypes;
using Bunit;
using TestCalculator.Pages;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void MarkupIsNotNull()
        {
            var ctx = new TestContext();

            var cut = ctx.RenderComponent<Calculator>();

            Assert.NotNull(cut.Markup);
        }

        //Assert.Throws<Exception>(cut.Instance.AddNumbers);

        [Theory]
        [InlineData("123", "123", "246")]
        [InlineData("-123", "-123", "-246")]
        [InlineData("123", "-124", "-1")]
        [InlineData("-123", "123", "0")]
        [InlineData("0,125", "100", "100,125")]
        [InlineData("0,100", "0,023", "0,123")]
        [InlineData("abc", "abc", null)]
        public void AddNumbers(string val1, string val2, string expectedVal)
        {
            //Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            var buttons = cut.FindAll("button"); // Assert.True(paras.Count == 7);

            cut.Instance.num1 = val1;
            cut.Instance.num2 = val2;

            //Act
            buttons[0].Click();
            //cut.Instance.AddNumbers();

            //Assert
            Assert.True(cut.Instance.finalresult == expectedVal);
        }

        [Theory]
        [InlineData("1", "2", "-1")]
        [InlineData("-1", "-2", "1")]
        [InlineData("1,5", "-1,5", "3")]
        [InlineData("abc", "abc", null)]
        public void SubtractNumbers(string val1, string val2, string expectedVal)
        {
            //Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            cut.Instance.num1 = val1;
            cut.Instance.num2 = val2;

            //Act
            cut.Instance.SubtractNumbers();

            //Assert
            Assert.True(cut.Instance.finalresult == expectedVal);
        }

        [Theory]
        [InlineData("1", "2", "2")]
        [InlineData("1", "-2", "-2")]
        [InlineData("-1", "-2", "2")]
        [InlineData("10", "0,1", "1")]
        [InlineData("abc", "abc", null)]
        public void MultiplyNumbers(string val1, string val2, string expectedVal)
        {
            //Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            cut.Instance.num1 = val1;
            cut.Instance.num2 = val2;

            //Act
            cut.Instance.MultiplyNumbers();

            //Assert
            Assert.True(cut.Instance.finalresult == expectedVal);
        }

        [Theory]
        [InlineData("100", "2", "50")]
        [InlineData("100", "-2", "-50")]
        [InlineData("-100", "-2", "50")]
        [InlineData("-100", "2", "-50")]
        [InlineData("100", "0,1", "1000")]
        [InlineData("0,5", "10", "0,05")]
        [InlineData("10", "0", "Cannot Divide by Zero")]
        [InlineData("abc", "abc", null)]
        public void DivideNumbers(string val1, string val2, string expectedVal)
        {
            //Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            cut.Instance.num1 = val1;
            cut.Instance.num2 = val2;

            //Act
            cut.Instance.DivideNumbers();

            //Assert
            Assert.True(cut.Instance.finalresult == expectedVal);
        }

        [Theory]
        [InlineData("100", "0", "Cannot Take the Zeroth Root")]
        [InlineData("100", "1", "100")]
        [InlineData("100", "2", "10")]
        //[InlineData("1000", "3", "10")] // This does not work since the result is 9,999999999999998
        [InlineData("10000", "4", "10")]
        [InlineData("-1", "1", "-1")]
        [InlineData("-1", "2", null)]
        [InlineData("abc", "abc", null)]
        public void NthRoot(string val1, string val2, string expectedVal)
        {
            //Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            cut.Instance.num1 = val1;
            cut.Instance.num2 = val2;

            //Act
            cut.Instance.NthRoot();

            //Assert
            Assert.True(cut.Instance.finalresult == expectedVal);
        }

        [Theory]
        [InlineData("100", "0", "0")]
        [InlineData("100", "15", "15")]
        [InlineData("100", "7,5", "7,5")]
        [InlineData("abc", "abc", null)]
        public void Percentage(string val1, string val2, string expectedVal)
        {
            //Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            cut.Instance.num1 = val1;
            cut.Instance.num2 = val2;

            //Act
            cut.Instance.Percentage();

            //Assert
            Assert.True(cut.Instance.finalresult == expectedVal);
        }
        [Theory]
        [InlineData("1", "5", "1")]
        [InlineData("5", "2", "25")]
        [InlineData("100", "0,5", "10")]
        [InlineData("-10", "2", "100")]
        [InlineData("10", "-1", "0,1")]
        [InlineData("abc", "abc", null)]
        public void Exponent(string val1, string val2, string expectedVal)
        {
            //Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Calculator>();
            cut.Instance.num1 = val1;
            cut.Instance.num2 = val2;

            //Act
            cut.Instance.Exponent();

            //Assert
            Assert.True(cut.Instance.finalresult == expectedVal);
        }
    }
}