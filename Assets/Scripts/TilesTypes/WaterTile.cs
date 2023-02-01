using System.Collections;
using System.Collections.Generic;
using Grid;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class WaterTile : TileMesh
{
    public WaterTile() : base()
    {
        mesh.name = "Water";
        thisTileProperty = GridTileProperty.Water;
    }
    
    protected override void GenerateLowerPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        builder.TextureMatrix = Matrix4x4.Translate(new Vector3(0.25f, 0.5f, 0f)) *
                                Matrix4x4.Scale(new Vector3(0.25f, 0.5f, 0.5f));
        
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            //Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        int a = builder.AddVertex(new Vector3(1f, -0.5f, 0f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int b = builder.AddVertex(new Vector3(0, -0.5f, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int c = builder.AddVertex(new Vector3(0, -0.5f, 1), new Vector3(0, 1, 0), new Vector2(1, 1));
        int d = builder.AddVertex(new Vector3(1, -0.5f, 1), new Vector3(0, 1, 0), new Vector2(1, 0));

        builder.AddQuad(a, b, c ,d);
    }
    
    protected override void GenerateUpperPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        builder.TextureMatrix = Matrix4x4.Translate(new Vector3(1f, 0.5f, 0f)) *
                                Matrix4x4.Scale(new Vector3(0.25f, 0.5f, 1));
        
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        int a = builder.AddVertex(new Vector3(1f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int b = builder.AddVertex(new Vector3(0, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int c = builder.AddVertex(new Vector3(0, 0, 1), new Vector3(0, 1, 0), new Vector2(1, 1));
        int d = builder.AddVertex(new Vector3(1, -0, 1), new Vector3(0, 1, 0), new Vector2(1, 0));
        
        builder.AddQuad(a, b, c ,d);
    }
    
    protected override void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        int a = builder.AddVertex(new Vector3(1f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int b = builder.AddVertex(new Vector3(0.7f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int c = builder.AddVertex(new Vector3(0.3f, 0, 0f), new Vector3(0, 1, 0), new Vector2(1, 1));
        int d = builder.AddVertex(new Vector3(0f, 0, 0f), new Vector3(0, 1, 0), new Vector2(1, 0));
        // TODO: Remake pieces with new function
        builder.AddQuad(new Vector3(1f, 0, 0f), new Vector3(0.7f, 0, 0f), new Vector3(0.7f, 0, 0.25f), new Vector3(1f, 0, 0.3f),
            new Vector2[4]{new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)});
        
        int e = builder.AddVertex(new Vector3(1f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int f = builder.AddVertex(new Vector3(0.7f, 0, 0.25f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int g = builder.AddVertex(new Vector3(0.3f, 0, 0.15f), new Vector3(0, 1, 0), new Vector2(1, 1));
        int h = builder.AddVertex(new Vector3(0f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(1, 0));
        
        int i = builder.AddVertex(new Vector3(1f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int j = builder.AddVertex(new Vector3(0.7f, -0.5f, 0.65f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int k = builder.AddVertex(new Vector3(0.3f, -0.5f, 0.55f), new Vector3(0, 1, 0), new Vector2(1, 1));
        int l = builder.AddVertex(new Vector3(0f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(1, 0));

        int m = builder.AddVertex(new Vector3(1f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int n = builder.AddVertex(new Vector3(0.7f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int o = builder.AddVertex(new Vector3(0.3f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(1, 1));
        int p = builder.AddVertex(new Vector3(0f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(1, 0));
        
        builder.AddQuad(a, b, f,e);
        builder.AddQuad(b, c, g,f);
        builder.AddQuad(c, d, h,g);
        
        builder.AddQuad(e, f, j,i);
        builder.AddQuad(f, g, k,j);
        builder.AddQuad(g, h, l,k);
        
        builder.AddQuad(i, j, n,m);
        builder.AddQuad(j, k, o,n);
        builder.AddQuad(k, l, p,o);
    }
    
    // protected override void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    // {
    //     builder.VertexMatrix =
    //         Matrix4x4.Scale(scale) *
    //         Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
    //         Matrix4x4.Translate(translation) *
    //         Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
    //         Matrix4x4.Rotate(rotation) *
    //         Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
    //     
    //     int a = builder.AddVertex(new Vector3(1f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 0));
    //     int b = builder.AddVertex(new Vector3(0.7f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
    //     int c = builder.AddVertex(new Vector3(0.3f, 0, 0f), new Vector3(0, 1, 0), new Vector2(1, 1));
    //     int d = builder.AddVertex(new Vector3(0f, 0, 0f), new Vector3(0, 1, 0), new Vector2(1, 0));
    //     
    //     int e = builder.AddVertex(new Vector3(1f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 0));
    //     int f = builder.AddVertex(new Vector3(0.7f, 0, 0.25f), new Vector3(0, 1, 0), new Vector2(0, 1));
    //     int g = builder.AddVertex(new Vector3(0.3f, 0, 0.15f), new Vector3(0, 1, 0), new Vector2(1, 1));
    //     int h = builder.AddVertex(new Vector3(0f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(1, 0));
    //     
    //     int i = builder.AddVertex(new Vector3(1f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 0));
    //     int j = builder.AddVertex(new Vector3(0.7f, -0.5f, 0.65f), new Vector3(0, 1, 0), new Vector2(0, 1));
    //     int k = builder.AddVertex(new Vector3(0.3f, -0.5f, 0.55f), new Vector3(0, 1, 0), new Vector2(1, 1));
    //     int l = builder.AddVertex(new Vector3(0f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(1, 0));
    //
    //     int m = builder.AddVertex(new Vector3(1f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 0));
    //     int n = builder.AddVertex(new Vector3(0.7f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
    //     int o = builder.AddVertex(new Vector3(0.3f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(1, 1));
    //     int p = builder.AddVertex(new Vector3(0f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(1, 0));
    //     
    //     builder.AddQuad(a, b, f,e);
    //     builder.AddQuad(b, c, g,f);
    //     builder.AddQuad(c, d, h,g);
    //     
    //     builder.AddQuad(e, f, j,i);
    //     builder.AddQuad(f, g, k,j);
    //     builder.AddQuad(g, h, l,k);
    //     
    //     builder.AddQuad(i, j, n,m);
    //     builder.AddQuad(j, k, o,n);
    //     builder.AddQuad(k, l, p,o);
    // }
    
    protected override void GenerateCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        // TODO: Fix Normals
        int a = builder.AddVertex(new Vector3(1f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int b = builder.AddVertex(new Vector3(0.7f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int c = builder.AddVertex(new Vector3(0.3f, -0.5f, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int d = builder.AddVertex(new Vector3(0f, -0.5f, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        
        int e = builder.AddVertex(new Vector3(1f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int f = builder.AddVertex(new Vector3(0.7f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int g = builder.AddVertex(new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int h = builder.AddVertex(new Vector3(0f, -0.5f, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 1));
        
        int i = builder.AddVertex(new Vector3(1f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int j = builder.AddVertex(new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int k = builder.AddVertex(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int l = builder.AddVertex(new Vector3(0f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 1));

        int m = builder.AddVertex(new Vector3(1f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int n = builder.AddVertex(new Vector3(0.7f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int o = builder.AddVertex(new Vector3(0.3f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int p = builder.AddVertex(new Vector3(0f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
        
        builder.AddQuad(a, b, f,e);
        builder.AddQuad(b, c, g,f);
        builder.AddQuad(c, d, h,g);
        
        builder.AddQuad(e, f, j,i);
        builder.AddQuad(f, g, k,j);
        builder.AddQuad(g, h, l,k);
        
        builder.AddQuad(i, j, n,m);
        builder.AddQuad(j, k, o,n);
        builder.AddQuad(k, l, p,o);
    }
    
    protected override void GenerateInvertedCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        // TODO: Fix Normals
        int a = builder.AddVertex(new Vector3(1f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int b = builder.AddVertex(new Vector3(0.7f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int c = builder.AddVertex(new Vector3(0.3f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int d = builder.AddVertex(new Vector3(0f, 0, 0f), new Vector3(0, 1, 0), new Vector2(0, 1));
        
        int e = builder.AddVertex(new Vector3(1f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int f = builder.AddVertex(new Vector3(0.7f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int g = builder.AddVertex(new Vector3(0.3f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int h = builder.AddVertex(new Vector3(0f, 0, 0.3f), new Vector3(0, 1, 0), new Vector2(0, 1));
        
        int i = builder.AddVertex(new Vector3(1f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int j = builder.AddVertex(new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int k = builder.AddVertex(new Vector3(0.3f, 0, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int l = builder.AddVertex(new Vector3(0f, 0, 0.7f), new Vector3(0, 1, 0), new Vector2(0, 1));

        int m = builder.AddVertex(new Vector3(1f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 0));
        int n = builder.AddVertex(new Vector3(0.7f, -0.5f, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int o = builder.AddVertex(new Vector3(0.3f, 0, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
        int p = builder.AddVertex(new Vector3(0f, 0, 1f), new Vector3(0, 1, 0), new Vector2(0, 1));
        
        builder.AddQuad(a, b, f,e);
        builder.AddQuad(b, c, g,f);
        builder.AddQuad(c, d, h,g);
        
        builder.AddQuad(e, f, j,i);
        builder.AddQuad(f, g, k,j);
        builder.AddQuad(g, h, l,k);
        
        builder.AddQuad(i, j, n,m);
        builder.AddQuad(j, k, o,n);
        builder.AddQuad(k, l, p,o);
    }
}
