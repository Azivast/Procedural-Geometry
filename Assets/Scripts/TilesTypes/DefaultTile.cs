using System.Collections;
using System.Collections.Generic;
using Grid;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class DefaultTile : TileMesh
{
    public DefaultTile()
    {
        mesh.name = "Default";
        builder.TextureMatrix = Matrix4x4.Translate(new Vector3(0f, 0.5f, 0f)) *
                                Matrix4x4.Scale(new Vector3(0.25f, 0.5f, 0.5f));
        
    }
    
    public override void UpdateMesh(GridTileProperty[,] neighbours)
    {
        builder.Clear(mesh);
        GenerateUpperPiece(new Vector3(0f, 0 , 0), Quaternion.identity, Vector3.one);
        GenerateUpperPiece(new Vector3(1f, 0 , 0), Quaternion.identity, Vector3.one);
        GenerateUpperPiece(new Vector3(0f, 0 , 1), Quaternion.identity, Vector3.one);
        GenerateUpperPiece(new Vector3(1f, 0 , 1), Quaternion.identity, Vector3.one);
        builder.Build(mesh);
    }

    protected override void GenerateUpperPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-1.5f, 0, -1.5f));

        builder.AddQuad(new Vector3(1f, 0, 1f), new Vector3(0f, 0, 1f), new Vector3(0f, 0, 0f), new Vector3(1f, 0, 0f));
    }
}
