using Spark.Library.Database;

namespace RoomCoder.Application.Models;

public class RoomCode : BaseModel
{
    public ushort Code1 { get; set; }
    public ushort Code2 { get; set; }
    public ushort Code3 { get; set; }
    public ushort Code4 { get; set; }
    public ushort Code5 { get; set; }
    public ushort Code6 { get; set; }
    public ushort Code7 { get; set; }
    public byte RoomNumber { get; set; }
}