namespace KipTestWork.Extensions;

/// <summary>
/// <see cref="Array"/> extensions implementation class.
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    /// Transform the specified 2D array to array rows getting method.
    /// </summary>
    /// <typeparam name="TItemsType">Array items type.</typeparam>
    /// <param name="array">Current array value.</param>
    /// <returns>Array rows collection value.</returns>
    public static IEnumerable<TItemsType[]> GetRows<TItemsType>(this TItemsType[,] array)
    {
        if (array is null)
        {
            throw new NullReferenceException();
        }

        var rowsAmount = array.GetLength(0);
        var columnsAmount = array.GetLength(1);

        if (rowsAmount <= 0 ||
            columnsAmount <= 0
        ) {
            throw new ArgumentException();
        }

        for (var rowIndex = 0; rowIndex < rowsAmount; ++rowIndex)
        {
            var row = new TItemsType[columnsAmount];

            for (var columnIndex = 0; columnIndex < columnsAmount; ++columnIndex)
            {
                row[columnIndex] = array[rowIndex, columnIndex];
            }

            yield return row;
        }
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <typeparam name="TItemsType">Array items type.</typeparam>
    /// <param name="array">Current array value.</param>
    /// <returns>A string that represents the current object.</returns>
    public static string GetItemsAsString<TItemsType>(this TItemsType[] array)
    {
        var result = array
            .Aggregate(string.Empty, (current, item) =>
                current + $"{item} "
            );

        return result;
    }
}