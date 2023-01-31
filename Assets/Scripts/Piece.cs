using System;
using System.IO;
using Grid;
using UnityEngine;

[RequireComponent(typeof(GridTile))]
[ExecuteInEditMode]
public class Piece : MonoBehaviour {
    private Mesh mesh;
    private MeshFilter meshFilter;
    private GridTile tile;
    private WaterTile waterTile;
    private PathTile pathTile;
    private DefaultTile defaultTile;

    private void Start()
    {
        waterTile = new WaterTile();
        pathTile = new PathTile();
        defaultTile = new DefaultTile();
        waterTile.GenerateMesh();
        pathTile.GenerateMesh();
        defaultTile.GenerateMesh();
    }

    private void Update()
    {
        tile = GetComponent<GridTile>();
        meshFilter = GetComponent<MeshFilter>();


        if (tile.GetProperty(GridTileProperty.Solid) && tile.GetProperty(GridTileProperty.Water)) {
            //meshFilter.sharedMesh = defaultTile.Mesh;
        } else if (tile.GetProperty(GridTileProperty.Solid)) {
            meshFilter.sharedMesh = pathTile.Mesh;
        } else if (tile.GetProperty(GridTileProperty.Water)) {
            meshFilter.sharedMesh = waterTile.Mesh;
        } else {
            meshFilter.sharedMesh = defaultTile.Mesh;
        }
    }

    private void OnDrawGizmos()
    {
        tile = GetComponent<GridTile>();
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
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.1f, 0.5f));
    }
}