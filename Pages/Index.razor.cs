using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RoomCoder.Application.Services;
using Spark.Library.Logging;
using ILogger = Spark.Library.Logging.ILogger;

namespace RoomCoder.Pages;

public partial class Index
{
    [Inject] public ILogger Logger { get; set; } = default!;

    [Inject] public CurrentCodeNumbersService? CurrentCodeNumbersService { get; set; }
    [Inject] public RoomCodesService? RoomCodesService { get; set; }
    protected override void OnInitialized()
    {
        Logger.Information($"Initialized at {DateTime.Now}");
    }
}
