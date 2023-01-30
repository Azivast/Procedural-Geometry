using System;
using System.Collections;
using System.Collections.Generic;
using Grid;
using UnityEngine;

public struct FiveSegmentBuilder
{
    public MeshBuilder Top, Bottom, Left, Right, Center;
}

public abstract class TileMesh : MonoBehaviour
{
    protected FiveSegmentBuilder builder;
    
    protected Mesh mesh;
    private MeshFilter meshFilter;
    private GridTile tile;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        meshFilter.sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void GenerateMesh()
    {
        // Top
        int a = builder.Top.AddVertex(
            new Vector3(-0.5f, -0.3f, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int e = builder.Top.AddVertex(
            new Vector3(-0.3f, -0.3f, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int h = builder.Top.AddVertex(
            new Vector3(0.3f, -0.3f, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        int d = builder.Top.AddVertex(
            new Vector3(0.5f, -0.3f, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        
        // Right
        a = Builder.AddVertex(
            new Vector3(-0.5f, -0.3f, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        b = Builder.AddVertex(
            new Vector3(-0.5f, -0.3f, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        c = Builder.AddVertex(
            new Vector3(0.5f, -0.3f, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        e = Builder.AddVertex(
            new Vector3(-0.3f, -0.3f, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        f = Builder.AddVertex(
            new Vector3(-0.3f, -0.3f, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));


        builder.Top.AddQuad(d, a, e, h); // Top
        builder.AddQuad(a, b, f, e); // Right
        builder.AddQuad(b, c, g, f); // Bottom
        builder.AddQuad(d, h, g, c); // Left
        builder.AddQuad(h, e, f, g); // Center
    }

    public virtual void UpdateTile(int[] neighbours)
    {
        // TODO: Update based on neighbors. Check only necessary tiles! 
    }
}
