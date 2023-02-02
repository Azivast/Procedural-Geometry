using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to represent tile type as single int instead of GridTileProperty.cs' 2 bools
public enum GridTileType {
    Solid = 0,
    Water = 1,
    None = 3,
    Both = 4
}