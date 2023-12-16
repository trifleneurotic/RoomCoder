using RoomCoder.Application.Database;
using RoomCoder.Application.Models;
using Spark.Library.Extensions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AsyncBridge;

namespace RoomCoder.Application.Services;

public class RoomCodesService
{
    private const int CodeLimit = 7;
    private const int RoomCount = 25;

    private readonly DatabaseContext _db;

    private Random _random = new Random();

    private Dictionary<byte, string> _progCodes;

    public Dictionary<byte, string> ProgrammingCodes
    {
        get
        {
            using (var A = AsyncHelper.Wait)
            {
             A.Run(this.GetProgrammingCodesAsync());
            }
            return _progCodes;
        }
    }

    public async Task GetProgrammingCodesAsync()
    {
        _progCodes = new Dictionary<byte, string>();

        for (int i = 0; i < RoomCount; i++)
        {
            var programmingCodeRecord = (ProgrammingCode)await _db.ProgrammingCodes.FirstAsync(x => x.RoomNumber == (byte)(i + 1));
            _progCodes.TryAdd(programmingCodeRecord.RoomNumber, programmingCodeRecord.ProgCode);
        }
    }

    private string GenerateRoomCode()
    {
        int i = _random.Next(0, 9999);
        if(i < 1000)
        {
            i += (1000 * _random.Next(1, 10));
        }
        return i.ToString("D4");
    }

    public List<ushort> GetAllCodesForRoom(byte roomNumber)
    {
        List<ushort>? _orderedCodeNumbersForRoom = new List<ushort>();
        var roomCodeRecord = (RoomCode)_db.RoomCodes.First(x => x.RoomNumber == roomNumber);

        for (int i = 0; i < CodeLimit; i++)
        {
            switch (i)
            {
                case 0: _orderedCodeNumbersForRoom.Add(roomCodeRecord.Code1); break;
                case 1: _orderedCodeNumbersForRoom.Add(roomCodeRecord.Code2); break;
                case 2: _orderedCodeNumbersForRoom.Add(roomCodeRecord.Code3); break;
                case 3: _orderedCodeNumbersForRoom.Add(roomCodeRecord.Code4); break;
                case 4: _orderedCodeNumbersForRoom.Add(roomCodeRecord.Code5); break;
                case 5: _orderedCodeNumbersForRoom.Add(roomCodeRecord.Code6); break;
                case 6: _orderedCodeNumbersForRoom.Add(roomCodeRecord.Code7); break;
            }
        }
        return _orderedCodeNumbersForRoom;
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

    public async Task GenerateRoomCodesAsync(byte roomNumber)
    {
        var roomCodeRecord = (RoomCode)await _db.RoomCodes.FirstAsync(x => x.RoomNumber == roomNumber);
        roomCodeRecord.Code1 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code2 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code3 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code4 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code5 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code6 = ushort.Parse(GenerateRoomCode());
        roomCodeRecord.Code7 = ushort.Parse(GenerateRoomCode());
        _db.RoomCodes.Save<RoomCode>(roomCodeRecord);
    }
    public RoomCodesService(DatabaseContext db)
    {
        _db = db;

        if (!_db.RoomCodes.Any())
        {
            for (int i = 0; i < RoomCount; i++)
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
                _db.RoomCodes.Save<RoomCode>(roomCodeRecord);
            }
        }

        if (!_db.ProgrammingCodes.Any())
        {
            for (int i = 0; i < RoomCount; i++)
            {
                var programmingCodeRecord = new ProgrammingCode();
                byte roomNum = (byte)(i + 1);
                programmingCodeRecord.RoomNumber = roomNum;

                switch (roomNum)
                {
                  case 1:
                    programmingCodeRecord.ProgCode = "0";
                    break;
                  case 2:
                    programmingCodeRecord.ProgCode = "151672";
                    break;
                  case 3:
                    programmingCodeRecord.ProgCode = "0";
                    break;
                  case 4:
                    programmingCodeRecord.ProgCode = "584856";
                    break;
                  case 5:
                    programmingCodeRecord.ProgCode = "524116";
                    break;
                  case 6:
                    programmingCodeRecord.ProgCode = "406785";
                    break;
                  case 7:
                    programmingCodeRecord.ProgCode = "0";
                    break;
                  case 8:
                    programmingCodeRecord.ProgCode = "716190";
                    break;
                  case 9:
                    programmingCodeRecord.ProgCode = "735216";
                    break;
                  case 10:
                    programmingCodeRecord.ProgCode = "240456";
                    break;
                  case 11:
                    programmingCodeRecord.ProgCode = "0";
                    break;
                  case 12:
                    programmingCodeRecord.ProgCode = "168435";
                    break;
                  case 14:
                    programmingCodeRecord.ProgCode = "752420";
                    break;
                  case 15:
                    programmingCodeRecord.ProgCode = "738256";
                    break;
                  case 16:
                    programmingCodeRecord.ProgCode = "315198";
                    break;
                  case 17:
                    programmingCodeRecord.ProgCode = "516785";
                    break;
                  case 18:
                    programmingCodeRecord.ProgCode = "696785";
                    break;
                  case 19:
                    programmingCodeRecord.ProgCode = "534503";
                    break;
                  case 20:
                    programmingCodeRecord.ProgCode = "616298";
                    break;
                  default:
                    programmingCodeRecord.ProgCode = "0";
                    break;
                }
                _db.ProgrammingCodes.Save<ProgrammingCode>(programmingCodeRecord);
            }
        }
    }
}