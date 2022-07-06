using System.Collections.Generic;

namespace EcsLiteTest.View
{
    public class ViewsCache
    {
        public readonly Dictionary<int, PlayerView> Players = new Dictionary<int, PlayerView>();
        public readonly Dictionary<int, DoorView> Doors = new Dictionary<int, DoorView>();
        public readonly Dictionary<int, DoorButtonView> DoorButtons = new Dictionary<int, DoorButtonView>();
    }
}