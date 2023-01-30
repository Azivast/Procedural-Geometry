using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : TileMesh
{
    protected override void Start()
    {
        mesh = new Mesh { name = "Water" };
        builder.TextureMatrix = 
            Matrix4x4.Translate(new Vector3(0.0f, 0.0f, 0.0f)) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 1.0f));
        base.Start();
    }

    public override void GenerateMesh()
    {
        int a = Builder.AddVertex(
            new Vector3(-0.5f, -0.3f, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int b = Builder.AddVertex(
            new Vector3(-0.5f, -0.3f, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int c = Builder.AddVertex(
            new Vector3(0.5f, -0.3f, 0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int d = Builder.AddVertex(
            new Vector3(0.5f, -0.3f, -0.5f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        int e = Builder.AddVertex(
            new Vector3(-0.3f, -0.3f, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int f = Builder.AddVertex(
            new Vector3(-0.3f, -0.3f, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int g = Builder.AddVertex(
            new Vector3(0.3f, -0.3f, 0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int h = Builder.AddVertex(
            new Vector3(0.3f, -0.3f, -0.3f), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        Builder.AddQuad(d, a, e, h); // Top
        Builder.AddQuad(a, b, f, e); // Right
        Builder.AddQuad(b, c, g, f); // Bottom
        Builder.AddQuad(d, h, g, c); // Left
        Builder.AddQuad(h, e, f, g); // Center
        
        Builder.Build(mesh);
    }
}
