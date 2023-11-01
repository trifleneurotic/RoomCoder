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

    private ConfirmPopup? confirmPopup;

    private ModalPopup? showCodesPopup;

    private Dictionary<byte, ushort> _roomCodes = new Dictionary<byte, ushort>();

    private byte RoomNumber;

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
            Generate(Int32.Parse(action.Substring(9)));
        }
    }

    private void CycleCheckpoint(int id)
    {
        RoomNumber = (byte)id;
        confirmPopup.ShowPop();
    }

    private void ShowAllRoomCodesForRoom(int id)
    {
        RoomNumber = (byte)id;
        List<ushort> codeList = RoomCodesService.GetAllCodesForRoom(RoomNumber);
        showCodesPopup.CodeList = codeList;
        showCodesPopup.RoomNumberForCodeList = id;
        showCodesPopup.ShowPop();
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