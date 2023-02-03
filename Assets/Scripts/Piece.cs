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
    private bool[,] neighbours = new bool[8, 2];
    
    private TileMesh currentTileType;
    private WaterTile waterTile;
    private PathTile pathTile;
    private DefaultTile defaultTile;
    private BridgeTile bridgeTile;

    private void Start()
    {
        mesh = new Mesh();
        mesh.name = "Tile";
        waterTile = new WaterTile();
        pathTile = new PathTile();
        defaultTile = new DefaultTile();
        bridgeTile = new BridgeTile();
    }

    private void Update()
    {
        tile = GetComponent<GridTile>();
        meshFilter = GetComponent<MeshFilter>();


        if (tile.GetProperty(GridTileProperty.Solid) && tile.GetProperty(GridTileProperty.Water)) {
            currentTileType = bridgeTile;
        } else if (tile.GetProperty(GridTileProperty.Solid)) {
            currentTileType = pathTile;
        } else if (tile.GetProperty(GridTileProperty.Water)) {
            currentTileType = waterTile;
        } else {
            currentTileType = defaultTile;
        }
        
        neighbours = new bool[8, 2];
        for (int i = 0; i < 8; i++)
        {
            neighbours[i, 0] = tile.GetNeighbourProperty(i, GridTileProperty.Solid);
            neighbours[i, 1] = tile.GetNeighbourProperty(i, GridTileProperty.Water);
        }
        currentTileType.UpdateMesh(neighbours, mesh);
        meshFilter.sharedMesh = mesh;
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