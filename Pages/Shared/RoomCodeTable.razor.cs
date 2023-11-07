using IARRoomCoder.Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using RoomCoder.Application.Services;

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

    private byte RoomNumber;

    private const int CodeLimit = 7;
    private const int RoomCount = 25;

    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        var data = PostFormService.Form?["id"];
        string action = data.GetValueOrDefault().ToString();

        if(!action.IsNullOrEmpty())
        {
            Generate(Int32.Parse(action.Substring(9)));
        }
    }

    private void CycleCheckpoint(int id)
    {
        RoomNumber = (byte)id;
        _cycleStatus[(byte)id] = true;
        InvokeAsync(StateHasChanged);
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

    private void ShowAllRoomCodesForRoom(int id)
    {
        RoomNumber = (byte)id;
        _viewStatus[(byte)id] = true;
        InvokeAsync(StateHasChanged);

        List<ushort> codeList = RoomCodesService.GetAllCodesForRoom(RoomNumber);
        
        showCodesPopup.CodeList = codeList;
        showCodesPopup.RoomNameForCodeList = GetRoomName(RoomNumber);
    }

    private void CycleProceed()
    {
       CurrentCodeNumbersService.CycleCurrentCodeNumber(RoomNumber);
       CurrentCodeNumbersService.GetCurrentCodeNumbersAsync();

       _roomCodes = new Dictionary<byte, ushort>();
        foreach (var keyValuePair in CurrentCodeNumbersService.OrderedCurrentCodeNumbers)
        {
            _roomCodes.Add(keyValuePair.Key, RoomCodesService.GetRoomCode(keyValuePair.Key, keyValuePair.Value));
        }
    }

    private void Generate(int id)
    {
        RoomCodesService.GenerateRoomCodesAsync((byte)id);
        CurrentCodeNumbersService.ResetCurrentCodeNumber((byte)id);
    }
}