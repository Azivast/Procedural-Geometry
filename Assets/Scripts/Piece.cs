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

    private void Update()
    {
        tile = GetComponent<GridTile>();
        builder = new MeshBuilder();
        meshFilter = GetComponent<MeshFilter>();

        if (tile.GetProperty(GridTileProperty.Solid) && tile.GetProperty(GridTileProperty.Water)) {
            DrawBoth();
        } else if (tile.GetProperty(GridTileProperty.Solid)) {
            DrawSolid();
        } else if (tile.GetProperty(GridTileProperty.Water)) {
            DrawWater();
        } else {
            DrawNeither();
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

    private void DrawWater() 
    {
        mesh = new Mesh { name = "Water" };
        meshFilter.sharedMesh = mesh;
        
        // Top
        builder.TextureMatrix = 
            Matrix4x4.Translate(new Vector3(0.0f, 0.0f, 0.0f)) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 1.0f));
        int a = builder.AddVertex(
            new Vector3(-0.5f, -0.3f, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int b = builder.AddVertex(
            new Vector3(-0.5f, -0.3f, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int c = builder.AddVertex(
            new Vector3(0.5f, -0.3f, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int d = builder.AddVertex(
            new Vector3(0.5f, -0.3f, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        int e = builder.AddVertex(
            new Vector3(-0.3f, -0.3f, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int f = builder.AddVertex(
            new Vector3(-0.3f, -0.3f, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int g = builder.AddVertex(
            new Vector3(0.3f, -0.3f, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int h = builder.AddVertex(
            new Vector3(0.3f, -0.3f, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        builder.AddQuad(d, a, e, h); // Top
        builder.AddQuad(a, b, f, e); // Right
        builder.AddQuad(b, c, g, f); // Bottom
        builder.AddQuad(d, h, g, c); // Left
        builder.AddQuad(h, e, f, g); // Center
        
        builder.Build(mesh);
    }
    
    private void DrawSolid() 
    {
        mesh = new Mesh { name = "Solid" };
        meshFilter.sharedMesh = mesh;
        
        // Top
        builder.TextureMatrix = 
            Matrix4x4.Translate(new Vector3(0.0f, 0.0f, 0.0f)) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 1.0f));
        int a = builder.AddVertex(
            new Vector3(-0.5f, 1, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int b = builder.AddVertex(
            new Vector3(-0.5f, 1, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int c = builder.AddVertex(
            new Vector3(0.5f, 1, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int d = builder.AddVertex(
            new Vector3(0.5f, 1, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        int e = builder.AddVertex(
            new Vector3(-0.3f, 1, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int f = builder.AddVertex(
            new Vector3(-0.3f, 1, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int g = builder.AddVertex(
            new Vector3(0.3f, 1, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int h = builder.AddVertex(
            new Vector3(0.3f, 1, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        builder.AddQuad(d, a, e, h); // Top
        builder.AddQuad(a, b, f, e); // Right
        builder.AddQuad(b, c, g, f); // Bottom
        builder.AddQuad(d, h, g, c); // Left
        builder.AddQuad(h, e, f, g); // Center

        builder.Build(mesh);
    }

    private void DrawBoth()
    {
        mesh = new Mesh { name = "Solid" };
        meshFilter.sharedMesh = mesh;
        
        // Top
        builder.TextureMatrix = 
            Matrix4x4.Translate(new Vector3(0.0f, 0.0f, 0.0f)) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 1.0f));
        int a = builder.AddVertex(
            new Vector3(-0.5f, 0, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int b = builder.AddVertex(
            new Vector3(-0.5f, 0, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int c = builder.AddVertex(
            new Vector3(0.5f, 0, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int d = builder.AddVertex(
            new Vector3(0.5f, 0, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        int e = builder.AddVertex(
            new Vector3(-0.3f, 0, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int f = builder.AddVertex(
            new Vector3(-0.3f, 0, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int g = builder.AddVertex(
            new Vector3(0.3f, 0, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int h = builder.AddVertex(
            new Vector3(0.3f, 0, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        builder.AddQuad(d, a, e, h); // Top
        builder.AddQuad(a, b, f, e); // Right
        builder.AddQuad(b, c, g, f); // Bottom
        builder.AddQuad(d, h, g, c); // Left
        //builder.AddQuad(h, e, f, g); // Center

        builder.Build(mesh);
    }
    
    private void DrawNeither()
    {
        mesh = new Mesh { name = "Solid" };
        meshFilter.sharedMesh = mesh;
        
        // Top
        builder.TextureMatrix = 
            Matrix4x4.Translate(new Vector3(0.0f, 0.0f, 0.0f)) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 1.0f));
        int a = builder.AddVertex(
            new Vector3(-0.5f, 0, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int b = builder.AddVertex(
            new Vector3(-0.5f, 0, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int c = builder.AddVertex(
            new Vector3(0.5f, 0, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int d = builder.AddVertex(
            new Vector3(0.5f, 0, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        int e = builder.AddVertex(
            new Vector3(-0.3f, 0, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int f = builder.AddVertex(
            new Vector3(-0.3f, 0, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int g = builder.AddVertex(
            new Vector3(0.3f, 0, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int h = builder.AddVertex(
            new Vector3(0.3f, 0, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        builder.AddQuad(d, a, e, h); // Top
        builder.AddQuad(a, b, f, e); // Right
        builder.AddQuad(b, c, g, f); // Bottom
        builder.AddQuad(d, h, g, c); // Left
        builder.AddQuad(h, e, f, g); // Center

        builder.Build(mesh);
    }
}