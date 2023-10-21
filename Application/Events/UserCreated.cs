using RoomCoder.Application.Models;
using Coravel.Events.Interfaces;

namespace RoomCoder.Application.Events;


public class UserCreated : IEvent
{
    public User User { get; set; }

    public UserCreated(User user)
    {
        this.User = user;
    }
}
