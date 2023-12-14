using Microsoft.AspNetCore.Components;
using RoomCoder.Application.Models;
using RoomCoder.Pages.Shared;

namespace RoomCoder.Pages;

public partial class Dashboard
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout.User;
}
