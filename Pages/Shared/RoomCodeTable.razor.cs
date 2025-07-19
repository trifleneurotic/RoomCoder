using RoomCoder.Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using RoomCoder.Application.Services;
using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AsyncBridge;

namespace RoomCoder.Pages.Shared;

public partial class RoomCodeTable
{
    [Inject] public CurrentCodeNumbersService? CurrentCodeNumbersService { get; set; }
    [Inject] public RoomCodesService? RoomCodesService { get; set; }
    [Inject] public PostFormService? PostFormService { get; set; }

    private ConfirmPopup? confirmPopup;

    private ModalPopup? showCodesPopup;

    private Dictionary<byte, ushort> _roomCodes = new Dictionary<byte, ushort>();

    private Dictionary<byte, bool> _viewStatus = new Dictionary<byte, bool>();

    private Dictionary<byte, bool> _cycleStatus = new Dictionary<byte, bool>();

    public Dictionary<byte, ElementReference> _roomViewElements = new Dictionary<byte, ElementReference>();

    public Dictionary<byte, ElementReference> _cycleElements = new Dictionary<byte, ElementReference>();

    private byte RoomNumber;
    private const int RoomCount = 25;

    private bool Initializing = true;

    protected override async Task OnInitializedAsync()
    {
        var data = PostFormService.Form?["id"];
        string action = data.GetValueOrDefault().ToString();

        if(!action.IsNullOrEmpty())
        {
            Generate(Int32.Parse(action.Substring(9)));
        }

        base.OnInitialized();
    }

    private void CycleCheckpoint(int id)
    {
        RoomNumber = (byte)id;
        _cycleStatus[(byte)id] = true;
        JS.InvokeVoidAsync("setButtonElementDisable", _cycleElements[(byte)id]);
        StateHasChanged();
        // InvokeAsync(StateHasChanged);
    }

    private string GetRoomName(byte roomNumber)
    {
        switch(roomNumber)
        {
            case < 13: return roomNumber.ToString();
            case < 20: return (roomNumber + 1).ToString();
            case 20: return "Laundry";
            case 21: return "Main Entry";
            case 22: return "Maintenance";
            case 23: return "Lower East";
            case 24: return "Upper East";
            case 25: return "(no room set)";
            default: return "Room doesn't exist";
        }
    }

    private async void ShowAllRoomCodesForRoom(int id)
    {
        RoomNumber = (byte)id;
        _viewStatus[(byte)id] = true;

        JS.InvokeVoidAsync("setButtonElementDisable", _roomViewElements[(byte)id]);
        StateHasChanged();

        List<ushort> codeList = RoomCodesService.GetAllCodesForRoom(RoomNumber);

        showCodesPopup.CodeList = codeList;
        showCodesPopup.RoomNameForCodeList = GetRoomName(RoomNumber);
    }

    private void CycleProceed()
    {
        using (var A = AsyncHelper.Wait)
        {
             A.Run(CurrentCodeNumbersService.CycleCurrentCodeNumber(RoomNumber));
        }

       // CurrentCodeNumbersService.GetCurrentCodeNumbersAsync();

       _roomCodes = new Dictionary<byte, ushort>();
        foreach (var keyValuePair in CurrentCodeNumbersService.OrderedCurrentCodeNumbers)
        {
            _roomCodes.Add(keyValuePair.Key, RoomCodesService.GetRoomCode(keyValuePair.Key, keyValuePair.Value));
        }
    }

    private void Generate(int id)
    {
        using (var A = AsyncHelper.Wait)
        {
             A.Run(RoomCodesService.GenerateRoomCodesAsync((byte)id));
        }

        using (var A = AsyncHelper.Wait)
        {
             A.Run(CurrentCodeNumbersService.ResetCurrentCodeNumber((byte)id));
        }
    }
}