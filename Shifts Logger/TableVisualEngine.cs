using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;

namespace Shifts_Logger;

public class TableVisualEngine
{
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        Console.Clear();

        if (tableName == null)
            tableName = "";
        
        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .WithFormat(ConsoleTableBuilderFormat.Default)
            .ExportAndWriteLine(TableAligntment.Left);
    }
}