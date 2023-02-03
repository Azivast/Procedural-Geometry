using System.Collections;
using System.Collections.Generic;
using Grid;
using JetBrains.Annotations;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class DefaultTile : TileMesh
{
    [CanBeNull]
    protected override  bool[] type
    {
        get { return new bool[] {false, false}; }
    }


    public override void UpdateMesh(bool[,] neighbours, Mesh mesh)
    {
        builder.Clear(mesh);
        GenerateInnerPiece(new Vector3(0f, 0 , 0), Quaternion.identity, Vector3.one);
        GenerateInnerPiece(new Vector3(1f, 0 , 0), Quaternion.identity, Vector3.one);
        GenerateInnerPiece(new Vector3(0f, 0 , 1), Quaternion.identity, Vector3.one);
        GenerateInnerPiece(new Vector3(1f, 0 , 1), Quaternion.identity, Vector3.one);
        builder.Build(mesh);
    }

    protected override void GenerateInnerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
        float angle;
        rotation.ToAngleAxis(out angle, out _);
        builder.SetTextureMatrix(new Vector3(0f, 0.5f, 0f), angle);
        
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
