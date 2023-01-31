using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class DefaultTile : TileMesh
{
    public DefaultTile() : base()
    {
        mesh.name = "Default";
        builder.TextureMatrix = Matrix4x4.Translate(new Vector3(0.0f, 0.0f, 0.0f)) *
                                Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 1.0f));
    }
    
    public override void GenerateMesh()
    {
        GenerateUpperPiece(Vector3.zero, Quaternion.identity, Vector3.one);
        GenerateUpperPiece(new Vector3(0, 0 , 1), Quaternion.identity, Vector3.one);
        GenerateUpperPiece(new Vector3(1, 0 , 0), Quaternion.identity, Vector3.one);
        GenerateUpperPiece(new Vector3(1, 0 , 1), Quaternion.identity, Vector3.one);
        base.GenerateMesh();
    }
    
    protected override void GenerateUpperPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        builder.VertexMatrix =
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f))* 
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Scale(scale);
        
        int a = builder.AddVertex(
            new Vector3(1f, 0, 0f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 0));
        int b = builder.AddVertex(
            new Vector3(0, 0, 0f), 
            new Vector3(0, 1, 0), 
            new Vector2(0, 1));
        int c = builder.AddVertex(
            new Vector3(0, 0, 1), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 1));
        int d = builder.AddVertex(
            new Vector3(1, -0, 1), 
            new Vector3(0, 1, 0), 
            new Vector2(1, 0));
        
        builder.AddQuad(a, b, c ,d);
    }
}
