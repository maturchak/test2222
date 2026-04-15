namespace ArrayProcessor
{
    public class ArrayOperations
    {
        public class Result
        {
            public double SumOfPositive { get; set; }
            public double ProductOfEvenIndexes { get; set; }
        }

        public static Result Process(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty", nameof(array));
            }

            double sumOfPositive = 0;
            double productOfEvenIndexes = 1;
            bool hasEvenIndex = false;

            for (int i = 0; i < array.Length; i++)
            {
                // Сумма положительных элементов
                if (array[i] > 0)
                {
                    sumOfPositive += array[i];
                }

                // Произведение элементов с четными индексами
                if (i % 2 == 0)
                {
                    productOfEvenIndexes *= array[i];
                    hasEvenIndex = true;
                }
            }

            // Если нет элементов с четными индексами, произведение = 0
            if (!hasEvenIndex)
            {
                productOfEvenIndexes = 0;
            }

            return new Result
            {
                SumOfPositive = sumOfPositive,
                ProductOfEvenIndexes = productOfEvenIndexes
            };
        }
    }
}