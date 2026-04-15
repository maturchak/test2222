using System;
using Xunit;
using ArrayProcessor;

namespace ArrayProcessor.Tests
{
	public class ArrayOperationsTests
	{
		private const double Tolerance = 1e-10;

		#region Boundary Tests (Тесты граничных значений)

		[Fact]
		public void BoundaryTest_MinDouble_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { double.MinValue };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(double.MinValue, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void BoundaryTest_MaxDouble_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { double.MaxValue };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(double.MaxValue, result.SumOfPositive, Tolerance);
			Assert.Equal(double.MaxValue, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void BoundaryTest_Zero_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 0.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void BoundaryTest_NearZeroPositive_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { double.Epsilon };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(double.Epsilon, result.SumOfPositive, Tolerance);
			Assert.Equal(double.Epsilon, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void BoundaryTest_NearZeroNegative_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -double.Epsilon };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(-double.Epsilon, result.ProductOfEvenIndexes, Tolerance);
		}

		#endregion

		#region Equivalence Partition Tests (Тесты областей эквивалентности)

		[Fact]
		public void EquivalenceTest_AllPositive_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 1.5, 2.5, 3.5, 4.5 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(12.0, result.SumOfPositive, Tolerance);
			Assert.Equal(1.5 * 3.5, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void EquivalenceTest_AllNegative_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -1.5, -2.5, -3.5, -4.5 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(-1.5 * -3.5, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void EquivalenceTest_MixedValues_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 1.0, -2.0, 3.0, -4.0, 5.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(9.0, result.SumOfPositive, Tolerance);
			Assert.Equal(15.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void EquivalenceTest_AllZeros_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 0.0, 0.0, 0.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void EquivalenceTest_LargePositiveNumbers_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 1e100, 2e100, 3e100 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(6e100, result.SumOfPositive, Tolerance);
			Assert.Equal(3e200, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void EquivalenceTest_LargeNegativeNumbers_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -1e100, -2e100, -3e100 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(3e200, result.ProductOfEvenIndexes, Tolerance);
		}

		#endregion

		#region Key Element Position Tests (Тесты позиций ключевых элементов)

		[Fact]
		public void KeyElementTest_PositiveFirst_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 5.0, -2.0, -3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(5.0, result.SumOfPositive, Tolerance);
			Assert.Equal(5.0 * -3.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void KeyElementTest_PositiveMiddle_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -1.0, 5.0, -3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(5.0, result.SumOfPositive, Tolerance);
			Assert.Equal(-1.0 * -3.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void KeyElementTest_PositiveLast_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -1.0, -2.0, 5.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(5.0, result.SumOfPositive, Tolerance);
			Assert.Equal(-1.0 * 5.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void KeyElementTest_NoPositiveElements_ReturnsZeroSum()
		{
			// Arrange
			double[] input = { -1.0, -2.0, -3.0, -4.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
		}

		[Fact]
		public void KeyElementTest_ZeroAtEvenIndex_ReturnsZeroProduct()
		{
			// Arrange
			double[] input = { 0.0, 5.0, 10.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(15.0, result.SumOfPositive, Tolerance);
			Assert.Equal(0, result.ProductOfEvenIndexes, Tolerance);
		}

		#endregion

		#region Path Coverage Tests (Тесты покрытия путей)

		[Fact]
		public void PathTest_SingleElement_Positive_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 42.5 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(42.5, result.SumOfPositive, Tolerance);
			Assert.Equal(42.5, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void PathTest_SingleElement_Negative_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -42.5 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(-42.5, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void PathTest_TwoElements_BothPositive_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 2.0, 3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(5.0, result.SumOfPositive, Tolerance);
			Assert.Equal(2.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void PathTest_TwoElements_FirstPositive_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 2.0, -3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(2.0, result.SumOfPositive, Tolerance);
			Assert.Equal(2.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void PathTest_TwoElements_SecondPositive_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -2.0, 3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(3.0, result.SumOfPositive, Tolerance);
			Assert.Equal(-2.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void PathTest_TwoElements_BothNegative_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -2.0, -3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(0, result.SumOfPositive, Tolerance);
			Assert.Equal(-2.0, result.ProductOfEvenIndexes, Tolerance);
		}

		#endregion

		#region Special Cases Tests (Тесты специальных случаев)

		[Fact]
		public void SpecialTest_AlternatingPositiveNegative_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 1.0, -1.0, 2.0, -2.0, 3.0, -3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(6.0, result.SumOfPositive, Tolerance);
			Assert.Equal(6.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void SpecialTest_LargeArray_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = new double[100];
			for (int i = 0; i < 100; i++)
			{
				input[i] = i + 1;
			}

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			double expectedSum = 100 * 101 / 2.0; // Сумма от 1 до 100
			Assert.Equal(expectedSum, result.SumOfPositive, Tolerance);
		}

		[Fact]
		public void SpecialTest_VerySmallPositiveNumbers_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 1e-100, 2e-100, 3e-100 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(6e-100, result.SumOfPositive, Tolerance);
		}

		[Fact]
		public void SpecialTest_MixedWithZeros_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 1.0, 0.0, -1.0, 0.0, 2.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(3.0, result.SumOfPositive, Tolerance);
			Assert.Equal(0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void SpecialTest_FractionalNumbers_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 0.1, 0.2, 0.3, 0.4 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(1.0, result.SumOfPositive, Tolerance);
			Assert.Equal(0.03, result.ProductOfEvenIndexes, Tolerance);
		}

		#endregion

		#region Exception Tests (Тесты исключений)

		[Fact]
		public void ExceptionTest_NullArray_ThrowsArgumentNullException()
		{
			// Arrange
			double[] input = null;

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => ArrayOperations.Process(input));
		}

		[Fact]
		public void ExceptionTest_EmptyArray_ThrowsArgumentException()
		{
			// Arrange
			double[] input = { };

			// Act & Assert
			Assert.Throws<ArgumentException>(() => ArrayOperations.Process(input));
		}

		#endregion

		#region Additional Coverage Tests

		[Fact]
		public void AdditionalTest_ThreeElements_AllDifferentSigns_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { -5.0, 0.0, 10.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(10.0, result.SumOfPositive, Tolerance);
			Assert.Equal(-50.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void AdditionalTest_FourElements_Pattern_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 2.0, -2.0, 3.0, -3.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(5.0, result.SumOfPositive, Tolerance);
			Assert.Equal(6.0, result.ProductOfEvenIndexes, Tolerance);
		}

		[Fact]
		public void AdditionalTest_FiveElements_IncreasingPositive_ReturnsCorrectResults()
		{
			// Arrange
			double[] input = { 1.0, 2.0, 3.0, 4.0, 5.0 };

			// Act
			var result = ArrayOperations.Process(input);

			// Assert
			Assert.Equal(15.0, result.SumOfPositive, Tolerance);
			Assert.Equal(15.0, result.ProductOfEvenIndexes, Tolerance);
		}

		#endregion
	}
}