using Microsoft.AspNetCore.Components;
using RoomCoder.Application.Models;

namespace RoomCoder.Pages.Shared;

public partial class NavMenu
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout?.User;
}
