using InterviewTestQA.InterviewTestAutomation;

namespace InterviewTestQA
{
    public class CalculatorTest
    {
        private const string DIVIDE_EXCEPTION_MESSAGE = "Cannot divide by zero.";
        private const string SQUAREROOT_EXCEPTION_MESSAGE = "Cannot square root zero.";
        private readonly Calculator _calculator;

        public CalculatorTest()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(3, -5, -2)]
        [InlineData(-5, 5, 0)]
        [InlineData(-2, -5, -7)]
        [InlineData(0, 19, 19)]
        public void TestAdd_ReturnsResult(int value1, int value2, int expected)
       {
            int result = _calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(8, 5, 3)]
        [InlineData(6, -9, 15)]
        [InlineData(-5, 5, -10)]
        [InlineData(-7, -7, 0)]
        [InlineData(0, -7, 7)]
        [InlineData(-7, 0, -7)]
        public void TestSubtract_ReturnsResult(int value1, int value2, int expected)
        {
            int result = _calculator.Subtract(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(8, 5, 40)]
        [InlineData(2, -3, -6)]
        [InlineData(-4, 2, -8)]
        [InlineData(-3, -2, 6)]
        [InlineData(0, 5, 0)]
        public void TestMultiply_ReturnsResult(int value1, int value2, int expected)
        {
            int result = _calculator.Multiply(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(8, 4, 2)]
        [InlineData(4, 6, 0)]
        [InlineData(5, 5, 1)]
        [InlineData(0, 5, 0)]
        [InlineData(-4, 2, -2)]
        [InlineData(6, -2, -3)]
        [InlineData(-10, -2, 5)]
        //[InlineData(7, 0, "Cannot divide by zero.")]
        public void TestDivide_ReturnsResult(int value1, int value2, int expected)
        {
            int result = _calculator.Divide(value1, value2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(7, 0)]
        [InlineData(-7, 0)]
        public void TestDivide_ThrowsException(int value1, int value2)
        {
            var actualException = Assert.Throws<ArgumentException>(() => _calculator.Divide(value1, value2));
            Assert.Equal(DIVIDE_EXCEPTION_MESSAGE, actualException.Message);
        }

        [Theory]
        [InlineData(8, 64)]
        [InlineData(-8, 64)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void TestSquare_ReturnsResult(int value1, int expected)
        {
            int result = _calculator.Square(value1);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(64, 8)]
        [InlineData(1, 1)]
        [InlineData(-64, int.MinValue)]
        [InlineData(-1, int.MinValue)]
        public void TestSquareRoot_ReturnsResult(int value1, int expected)
        {
            int result = _calculator.SquareRoot(value1);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        public void TestSquareRoot_ThrowsException(int value1)
        {
            var actualException = Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(value1));
            Assert.Equal(SQUAREROOT_EXCEPTION_MESSAGE, actualException.Message);
        }
    }
}