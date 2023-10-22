using IARRoomCoder.Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RoomCoder.Application.Services;

namespace RoomCoder.Pages.Shared;

public partial class RoomCodeTable
{
    [Inject] public CurrentCodeNumbersService? CurrentCodeNumbersService { get; set; }
    [Inject] public RoomCodesService? RoomCodesService { get; set; }
    [Inject] public PostFormService? PostFormService { get; set; }

    private Dictionary<byte, ushort> _roomCodes = new Dictionary<byte, ushort>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        foreach (var keyValuePair in CurrentCodeNumbersService.OrderedCurrentCodeNumbers)
        {
            _roomCodes.Add(keyValuePair.Key, RoomCodesService.GetRoomCode(keyValuePair.Key, keyValuePair.Value));
        }
        var data = PostFormService.Form?["id"];
        string action = data.GetValueOrDefault().ToString();

        if(!action.IsNullOrEmpty())
        {
            if(action.StartsWith("Cycle"))
            {
                Cycle(Int32.Parse(action.Substring(6)));
            }
            else
            {
                Generate(Int32.Parse(action.Substring(9)));
            }
        }
    }
    private void Cycle(int id)
    {
        CurrentCodeNumbersService.CycleCurrentCodeNumber((byte)id);
    }
    private void Generate(int id)
    {
        RoomCodesService.GenerateRoomCodesAsync((byte)id);
        CurrentCodeNumbersService.ResetCurrentCodeNumber((byte)id);
    }
}