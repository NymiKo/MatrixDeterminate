class Program {

    static void Main(string[] args) {
        int[] numbers = RequestEnterNumbers();
        int[] currentMatrix = new int[9];
        bool[] numberUsed = new bool[9];

        long maxDeterminant = long.MinValue;
        int[] maxDeterminantMatrix = new int[9];

        GenerateMatrix(numbers, currentMatrix, numberUsed, 0, ref maxDeterminant, ref maxDeterminantMatrix);

        PrintMatrixWithMaxDeterminant(maxDeterminantMatrix, maxDeterminant);
    }

    static int[] RequestEnterNumbers() {

        int[] numbers = new int[9];
        Console.WriteLine("Введите 9 чисел:");

        for (int i = 0; i < 9; i++) {
            Console.Write($"Число {i + 1}: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                i--; 
                continue;
            }

            bool isValidNumber = int.TryParse(input, out int number);

            if (isValidNumber) {
                numbers[i] = number;
            } else {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                i--; 
            }
        }

        return numbers;
    }

    static void GenerateMatrix(int[] numbers, int[] currentMatrix, bool[] numberUsed, byte index, ref long maxDeterminant, ref int[] maxDeterminantMatrix) {

        if (index == 9) {
            long determinant = CalculateDeterminant(currentMatrix);

            if (determinant > maxDeterminant) {
                maxDeterminant = determinant;
                maxDeterminantMatrix = currentMatrix.ToArray();
            }

            return;
        }

        for (byte i = 0; i < 9; i++) {
            if (!numberUsed[i]) {
                currentMatrix[index] = numbers[i];
                numberUsed[i] = true;
                GenerateMatrix(numbers, currentMatrix, numberUsed, (byte)(index + 1), ref maxDeterminant, ref maxDeterminantMatrix);
                numberUsed[i] = false;
            }
        }
    }

    static long CalculateDeterminant(int[] matrix) {
        long determinant = matrix[0] * (matrix[4] * matrix[8] - matrix[5] * matrix[7])
                - matrix[1] * (matrix[3] * matrix[8] - matrix[5] * matrix[6])
                + matrix[2] * (matrix[3] * matrix[7] - matrix[4] * matrix[6]);

        return determinant;
    }

    static void PrintMatrixWithMaxDeterminant(int[] matrix, long determinant) {
        Console.WriteLine("Матрица с максимальным определителем:");
        Console.WriteLine(matrix[0] + " " + matrix[1] + " " + matrix[2]);
        Console.WriteLine(matrix[3] + " " + matrix[4] + " " + matrix[5]);
        Console.WriteLine(matrix[6] + " " + matrix[7] + " " + matrix[8]);
        Console.WriteLine("Максимальный определитель: " + determinant);
    }
}
