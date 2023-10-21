using Spark.Library.Database;

namespace RoomCoder.Application.Models;

public class CurrentCode : BaseModel
{
    public byte RoomNumber { get; set; }
    public byte CurrentCodeNumber { get; set; }
}