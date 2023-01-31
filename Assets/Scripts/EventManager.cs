using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class EventManager : MonoBehaviour
    {
        public delegate void TileUpdatedEvent(int tileChanged, int[] neighbours);
        
        public event TileUpdatedEvent TileUpdated;
        
        public void PublicTileUpdated(int tileChanged, int[] neighbours)
            => TileUpdated?.Invoke(tileChanged, neighbours);
    }
}