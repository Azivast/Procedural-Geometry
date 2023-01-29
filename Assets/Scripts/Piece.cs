using Grid;
using UnityEngine;

[RequireComponent(typeof(GridTile))]
public class Piece : MonoBehaviour {
    private void OnDrawGizmos() {
        var tile = GetComponent<GridTile>();
        if (tile.GetProperty(GridTileProperty.Solid)) {
            Gizmos.color = Color.red;
        } else if (tile.GetProperty(GridTileProperty.Water))
        {
            Gizmos.color = Color.blue;
        } else {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawCube(transform.position, new Vector3(1, 0.1f, 1));
    }
}