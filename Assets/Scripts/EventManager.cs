using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public static class EventManager
    {
        public delegate void TileUpdatedEvent(Vector2 tileChanged, int[] neighbours);
        
        public static event TileUpdatedEvent TileUpdated;
        
        public static void PublicTileUpdated(Vector2 tileChanged, int[] neighbours)
            => TileUpdated?.Invoke(tileChanged, neighbours);
    }
}