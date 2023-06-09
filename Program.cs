class Program {

    static void Main(string[] args) {
        int[] numbers = RequestEnterNumbers();

        long maxDeterminant = long.MinValue;
        int[] maxDeterminantMatrix = new int[9];

        for (byte a = 0; a < 9; a++) {
            for (byte b = 0; b < 9; b++) {
                if (b == a) continue;

                for (byte c = 0; c < 9; c++) {
                    if (c == a || c == b) continue;

                    for (byte d = 0; d < 9; d++) {
                        if (d == a || d == b || d == c) continue;

                        for (byte e = 0; e < 9; e++) {
                            if (e == a || e == b || e == c || e == d) continue;

                            for (byte f = 0; f < 9; f++) {
                                if (f == a || f == b || f == c || f == d || f == e) continue;

                                for (byte g = 0; g < 9; g++) {
                                    if (g == a || g == b || g == c || g == d || g == e || g == f) continue;

                                    for (byte h = 0; h < 9; h++) {
                                        if (h == a || h == b || h == c || h == d || h == e || h == f || h == g) continue;

                                        for (byte i = 0; i < 9; i++) {
                                            if (i == a || i == b || i == c || i == d || i == e || i == f || i == g || i == h) continue;

                                            int[] matrix = new int[9];
                                            matrix[0] = numbers[a];
                                            matrix[1] = numbers[b];
                                            matrix[2] = numbers[c];
                                            matrix[3] = numbers[d];
                                            matrix[4] = numbers[e];
                                            matrix[5] = numbers[f];
                                            matrix[6] = numbers[g];
                                            matrix[7] = numbers[h];
                                            matrix[8] = numbers[i];

                                            long determinant = CalculateDeterminant(matrix);

                                            if (determinant > maxDeterminant) {
                                                maxDeterminant = determinant;
                                                maxDeterminantMatrix = matrix;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

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
