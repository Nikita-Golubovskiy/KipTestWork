using KipTestWork.Extensions;

var random = new Random();

int[,] array;

while (true)
{
    var rowsAmount = random.Next(2, 10);
    var columnsAmount = random.Next(2, 10);

    array = new int[rowsAmount, columnsAmount];

    Console.WriteLine("Array:");

    for (var rowIndex = 0; rowIndex < rowsAmount; ++rowIndex)
    {
        array[rowIndex, 0] = random.Next(0, 50);

        Console.Write($"{array[rowIndex, 0]}");

        for (var columnIndex = 1; columnIndex < columnsAmount; ++columnIndex)
        {
            array[rowIndex, columnIndex] = random.Next(0, 50);

            Console.Write($", {array[rowIndex, columnIndex]}");
        }

        Console.WriteLine();
    }

    Console.WriteLine("Regenerate array?" + Environment.NewLine + "1 - True" + Environment.NewLine + "2 - False");

    var regenerateArray = Console.ReadLine();

    if (!int.TryParse(regenerateArray, out var regenerateArrayToInt))
    {
        throw new ArgumentException();
    }

    if (regenerateArrayToInt == 2)
    {
        break;
    }
}

foreach (var arrayRow in array.GetRows())
{
    Console.WriteLine();
    Console.WriteLine("Строка:");
    Console.WriteLine(arrayRow.GetItemsAsString());
    Console.WriteLine($"Максимальный элемент строки равен: {arrayRow.Max()}");
    Console.WriteLine($"Минимальный элемент строки равен: {arrayRow.Min()}");
    Console.WriteLine($"Cреднее арифметическое значение строки равно: {arrayRow.Average():F2}");
}

Console.ReadLine();