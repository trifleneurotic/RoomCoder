using RoomCoder.Application.Database;
using RoomCoder.Application.Models;
using Spark.Library.Extensions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RoomCoder.Application.Services;

public class RoomCodesService
{
    private const int CodeLimit = 19;

    private readonly DatabaseContext _db;

    private Random _random = new Random();

    private string GenerateRoomCode()
    {
        int i = _random.Next(0, 9999);
        if(i < 1000)
        {
            i += (1000 * _random.Next(1, 10));
        }
        return i.ToString("D4");
    }

    public ushort GetRoomCode(byte roomNumber, byte codeNumber)
    {
        var roomCodeRecord = (RoomCode)_db.RoomCodes.First(x => x.RoomNumber == roomNumber);
        switch (codeNumber)
        {
            case 1: return roomCodeRecord.Code1;
            case 2: return roomCodeRecord.Code2;
            case 3: return roomCodeRecord.Code3;
            case 4: return roomCodeRecord.Code4;
            case 5: return roomCodeRecord.Code5;
            case 6: return roomCodeRecord.Code6;
            case 7: return roomCodeRecord.Code7;
            case 8: return roomCodeRecord.Code8;
            case 9: return roomCodeRecord.Code9;
            case 10: return roomCodeRecord.Code10;
            case 11: return roomCodeRecord.Code11;
            case 12: return roomCodeRecord.Code12;
            case 13: return roomCodeRecord.Code13;
            case 14: return roomCodeRecord.Code14;
            case 15: return roomCodeRecord.Code15;
            case 16: return roomCodeRecord.Code16;
            case 17: return roomCodeRecord.Code17;
            case 18: return roomCodeRecord.Code18;
            case 19: return roomCodeRecord.Code19;
        }
        return 0;
    }
    private ushort GetInitialRoomCode(byte roomNumber, ushort codeNumber)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(roomNumber);
        sb.Append(codeNumber);
        return ushort.Parse(sb.ToString());
    }

    public async void GenerateRoomCodesAsync(byte roomNumber)
    {
        var roomCodeRecord = (RoomCode)await _db.RoomCodes.FirstAsync(x => x.RoomNumber == roomNumber);
        roomCodeRecord.Code1 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code2 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code3 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code4 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code5 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code6 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code7 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code8 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code9 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code10 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code11 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code12 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code13 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code14 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code15 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code16 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code17 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code18 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code19 = ushort.Parse(GenerateRoomCode());
        _db.RoomCodes.Save<RoomCode>(roomCodeRecord);
    }
    public RoomCodesService(DatabaseContext db)
    {
        _db = db;

        if (!_db.RoomCodes.Any())
        {
            for (int i = 0; i < CodeLimit; i++)
            {
                var roomCodeRecord = new RoomCode();
                byte roomNumber = (byte)(i + 1);
                roomCodeRecord.RoomNumber = roomNumber;
                roomCodeRecord.Code1 = GetInitialRoomCode(roomNumber, (ushort)1);
                roomCodeRecord.Code2 = GetInitialRoomCode(roomNumber, (ushort)2);
                roomCodeRecord.Code3 = GetInitialRoomCode(roomNumber, (ushort)3);
                roomCodeRecord.Code4 = GetInitialRoomCode(roomNumber, (ushort)4);
                roomCodeRecord.Code5 = GetInitialRoomCode(roomNumber, (ushort)5);
                roomCodeRecord.Code6 = GetInitialRoomCode(roomNumber, (ushort)6);
                roomCodeRecord.Code7 = GetInitialRoomCode(roomNumber, (ushort)7);
                roomCodeRecord.Code8 = GetInitialRoomCode(roomNumber, (ushort)8);
                roomCodeRecord.Code9 = GetInitialRoomCode(roomNumber, (ushort)9);
                roomCodeRecord.Code10 = GetInitialRoomCode(roomNumber, (ushort)10);
                roomCodeRecord.Code11 = GetInitialRoomCode(roomNumber, (ushort)11);
                roomCodeRecord.Code12 = GetInitialRoomCode(roomNumber, (ushort)12);
                roomCodeRecord.Code13 = GetInitialRoomCode(roomNumber, (ushort)13);
                roomCodeRecord.Code14 = GetInitialRoomCode(roomNumber, (ushort)14);
                roomCodeRecord.Code15 = GetInitialRoomCode(roomNumber, (ushort)15);
                roomCodeRecord.Code16 = GetInitialRoomCode(roomNumber, (ushort)16);
                roomCodeRecord.Code17 = GetInitialRoomCode(roomNumber, (ushort)17);
                roomCodeRecord.Code18 = GetInitialRoomCode(roomNumber, (ushort)18);
                roomCodeRecord.Code19 = GetInitialRoomCode(roomNumber, (ushort)19);
                _db.RoomCodes.Save<RoomCode>(roomCodeRecord);
            }
        }
    }
}