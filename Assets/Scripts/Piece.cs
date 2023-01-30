using System;
using Grid;
using UnityEngine;

[RequireComponent(typeof(GridTile))]
[ExecuteInEditMode]
public class Piece : MonoBehaviour {
    private Mesh mesh;
    private MeshBuilder builder;
    private MeshFilter meshFilter;
    private GridTile tile;
    private WaterTile waterTile;

    private void Start()
    {
        waterTile = new WaterTile();
    }

    private void Update()
    {
        tile = GetComponent<GridTile>();
        builder = new MeshBuilder();
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.sharedMesh = waterTile.Mesh;

        if (tile.GetProperty(GridTileProperty.Solid) && tile.GetProperty(GridTileProperty.Water))
        {
            waterTile.UpdateMesh();
        } else if (tile.GetProperty(GridTileProperty.Solid)) {
            waterTile.UpdateMesh();
        } else if (tile.GetProperty(GridTileProperty.Water)) {
            waterTile.UpdateMesh();
        } else {
            waterTile.UpdateMesh();
        }
    }

    private void OnDrawGizmos()
    {
        tile = GetComponent<GridTile>();
        builder = new MeshBuilder();
        meshFilter = GetComponent<MeshFilter>();
        
        if (tile.GetProperty(GridTileProperty.Solid) && tile.GetProperty(GridTileProperty.Water)) {
            Gizmos.color = Color.yellow;
        } else if (tile.GetProperty(GridTileProperty.Solid)) {
            Gizmos.color = Color.gray;
        } else if (tile.GetProperty(GridTileProperty.Water)) {
            Gizmos.color = Color.blue;
        } else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawCube(transform.position, new Vector3(1, 0.1f, 1));
    }
}