using Spark.Library.Database;

namespace RoomCoder.Application.Models;

public class ProgrammingCode : BaseModel
{
  public string? ProgCode { get; set; }
  public byte RoomNumber { get; set; }
}
