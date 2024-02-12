using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;
using Shifts_Logger.Models;

namespace Shifts_Logger;

public class TableVisualEngine
{
    public void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : Shift
    {
        Console.Clear();

        if (tableName == null)
            tableName = "";

        var flattenedData = tableData.Select(shift => new
        {
            ShiftId = shift.shiftId,
            StartTime = shift.startTime,
            EndTime = shift.endTime,
            WorkerName = $"{shift.Worker.firstName} {shift.Worker.lastName}"
        }).ToList();

        ConsoleTableBuilder
            .From(flattenedData)
            .WithColumn("Shift ID", "Start Time", "End Time", "Worker")
            .WithFormat(ConsoleTableBuilderFormat.Default)
            .ExportAndWriteLine();
    }
}