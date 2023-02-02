using System;
using System.IO;
using Grid;
using UnityEngine;
using Events;

[RequireComponent(typeof(GridTile))]
[ExecuteInEditMode]
public class Piece : MonoBehaviour {
    private Mesh mesh;
    private MeshFilter meshFilter;
    private GridTile tile;
    private GridTileProperty[,] neighbours = new GridTileProperty[8, 2];
    
    private TileMesh currentTileType;
    private WaterTile waterTile;
    private PathTile pathTile;
    private DefaultTile defaultTile;
    private BridgeTile bridgeTile;

    private void Start()
    {
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

        // TODO: Get neighbours and pass to tileMesh
        neighbours = new GridTileProperty[8, 2];
        for (int i = 0; i < 8; i++)
        {
            if (tile.GetNeighbourProperty(i, GridTileProperty.Solid))
                neighbours[i, 0] = GridTileProperty.Solid;
            else neighbours[i, 0] = default;
            if (tile.GetNeighbourProperty(i, GridTileProperty.Water))
                neighbours[i, 1] = GridTileProperty.Water;
            else neighbours[i, 1] = default;
        }
        currentTileType.UpdateMesh(neighbours);
        meshFilter.sharedMesh = currentTileType.Mesh;
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