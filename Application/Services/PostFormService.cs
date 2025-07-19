namespace RoomCoder.Application.Services;

using Microsoft.AspNetCore.Http;
public class PostFormService
{
    public IFormCollection? Form { get; set; }

    public PostFormService()
    {
    }

}