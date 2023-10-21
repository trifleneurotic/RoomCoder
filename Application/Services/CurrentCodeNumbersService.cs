using Microsoft.EntityFrameworkCore;
using RoomCoder.Application.Database;
using RoomCoder.Application.Models;
using Spark.Library.Extensions;

namespace RoomCoder.Application.Services;

public class CurrentCodeNumbersService
{
    private const int CodeLimit = 19;

    private readonly DatabaseContext _db;

    private static SortedDictionary<byte, byte> _orderedCurrentCodeNumbers;
    public SortedDictionary<byte, byte> OrderedCurrentCodeNumbers
    {
        get
        {
            this.GetCurrentCodeNumbersAsync();
            return _orderedCurrentCodeNumbers;
        }
    }

    public CurrentCodeNumbersService(DatabaseContext db)
    {
        _db = db;

        if (!_db.CurrentCodes.Any())
        {
            for (int i = 0; i < CodeLimit; i++)
            {
                var currentCode = new CurrentCode();
                currentCode.RoomNumber = (byte)(i + 1);
                currentCode.CurrentCodeNumber = 1;
                _db.CurrentCodes.Save<CurrentCode>(currentCode);
            }
          }
    }

    private async void GetCurrentCodeNumbersAsync()
    {
        _orderedCurrentCodeNumbers = new SortedDictionary<byte, byte>();

        for (int i = 0; i < CodeLimit; i++)
        {
            var currentCodeRecord = (CurrentCode)await _db.CurrentCodes.FirstAsync(x => x.RoomNumber == (byte)(i + 1));
            _orderedCurrentCodeNumbers.Add(currentCodeRecord.RoomNumber, currentCodeRecord.CurrentCodeNumber);
        }
    }
}