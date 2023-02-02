using System.Collections;
using System.Collections.Generic;
using Grid;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BridgeTile : TileMesh
{
    public BridgeTile() : base()
    {
        mesh.name = "Bridge";
        type = new []{ GridTileProperty.Solid, GridTileProperty.Water };
    }
    
    protected override void GenerateLowerPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        float angle;
        rotation.ToAngleAxis(out angle, out _);
        builder.SetTextureMatrix(new Vector3(0.5f, 0f, 0f), angle);

        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        builder.AddQuad(new Vector3(1f, -0.5f, 1f), new Vector3(0f, -0.5f, 1f), new Vector3(0f, -0.5f, 0f), new Vector3(1f, -0.5f, 0f));
    }
    
    protected override void GenerateUpperPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
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
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        builder.AddQuad(new Vector3(1f, 0, 0f), new Vector3(0f, 0, 0f), new Vector3(0f, 0, 1f), new Vector3(1f, 0, 1f));
    }
    
    protected override void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        float angle;
        rotation.ToAngleAxis(out angle, out _);
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        builder.SetTextureMatrix(new Vector3(0f, 0.5f, 0f), angle);
        builder.AddQuad(new Vector3(0f, 0, 0.3f), new Vector3(0f, 0, 0f), new Vector3(0.3f, 0, 0f), new Vector3(0.3f, 0, 0.3f));
        builder.AddQuad(new Vector3(0.3f, 0, 0.3f), new Vector3(0.3f, 0, 0f), new Vector3(0.7f, 0, 0f), new Vector3(0.7f, 0, 0.3f));
        builder.AddQuad(new Vector3(0.7f, 0, 0.3f), new Vector3(0.7f, 0, 0f), new Vector3(1f, 0, 0f), new Vector3(1f, 0, 0.3f));

        builder.SetTextureMatrix(new Vector3(0.25f, 0f, 0f), 180);
        builder.AddQuad(new Vector3(0f, -0.5f, 0.7f), new Vector3(0f, 0, 0.3f), new Vector3(0.3f, 0, 0.3f), new Vector3(0.3f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0, 0.98f), new Vector2(0, 0.3f), new Vector2(0.3f, 0.3f), new Vector2(0.3f, 0.98f)});
        builder.AddQuad(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.3f, 0, 0.3f), new Vector3(0.7f, 0, 0.3f), new Vector3(0.7f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0.3f, 0.98f), new Vector2(0.3f, 0.3f), new Vector2(0.7f, 0.3f), new Vector2(0.7f, 0.98f)});
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0.7f, 0, 0.3f), new Vector3(1f, 0, 0.3f), new Vector3(1f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0.7f, 0.98f), new Vector2(0.7f, 0.3f), new Vector2(1f, 0.3f), new Vector2(1f, 0.98f)});

        builder.SetTextureMatrix(new Vector3(0.5f, 0f, 0f), angle);
        builder.AddQuad(new Vector3(0f, -0.5f, 1f), new Vector3(0f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.3f, -0.5f, 1f), new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0.7f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.7f, -0.5f, 1f), new Vector3(0.7f, -0.5f, 0.7f), new Vector3(1f, -0.5f, 0.7f), new Vector3(1f, -0.5f, 1f));
        
        // Bridge
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), angle);
        builder.AddQuad(new Vector3(1f, 0.2f, 1f), new Vector3(0f, 0.2f, 1f), new Vector3(0f, 0.2f, 0.3f), new Vector3(1f, 0.2f, 0.3f));
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(1f, 0.5f, 0.3f), new Vector3(0f, 0.5f, 0.3f), new Vector3(0f, 0.5f, 0f), new Vector3(1f, 0.5f, 0f));
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 0f), new Vector3(1f, 0.5f, 0f), new Vector3(0f, 0.5f, 0f),
            new []{new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 0.5f), new Vector2(0, 0.5f)});
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(1f, 0f, 0.3f), new Vector3(0f, 0f, 0.3f), new Vector3(0f, 0.5f, 0.3f), new Vector3(1f, 0.5f, 0.3f),
            new []{ new Vector2(0, 0.5f), new Vector2(1, 0.5f), new Vector2(1, 0), new Vector2(0, 0)});
    }
    
    protected override void GenerateCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
    {
        float angle;
        rotation.ToAngleAxis(out angle, out _);
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        builder.SetTextureMatrix(new Vector3(0f, 0.5f, 0f), angle);
        builder.AddQuad(new Vector3(0.7f, 0, 0.3f), new Vector3(0.7f, 0, 0f), new Vector3(1f, 0, 0f), new Vector3(1f, 0, 0.3f));

        builder.SetTextureMatrix(new Vector3(0.25f, 0f, 0f), angle);
        builder.AddQuad(new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.3f, -0.5f, 0f), new Vector3(0.7f, 0, 0f), new Vector3(0.7f, 0, 0.3f),
            new Vector2[4]{ new Vector2(0.3f,  0.98f), new Vector2(0f, 0.98f), new Vector2(0f, 0.3f), new Vector2(0.3f, 0.3f)});
        
        builder.AddTriangle(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.7f, 0f, 0.3f),
            new Vector2[3]{new Vector2(0.7f,  0.98f), new Vector2(0.3f, 0.98f), new Vector2(0.3f, 0.3f)});
        builder.AddTriangle(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.7f, 0, 0.3f), new Vector3(0.7f, -0.5f, 0.7f),
            new Vector2[3]{new Vector2(0.3f, 0.98f), new Vector2(0.7f,  0.3f), new Vector2(0.7f, 0.98f)});

        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0.7f, 0, 0.3f), new Vector3(1f, 0, 0.3f), new Vector3(1f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0.7f, 0.98f), new Vector2(0.7f, 0.3f), new Vector2(1f,  0.3f), new Vector2(1f, 0.98f)});

        builder.SetTextureMatrix(new Vector3(0.5f, 0f, 0f), angle);
        builder.AddQuad(new Vector3(0f, -0.5f, 0.3f), new Vector3(0f, -0.5f, 0f), new Vector3(0.3f, -0.5f, 0f), new Vector3(0.3f, -0.5f, 0.3f));
        builder.AddQuad(new Vector3(0f, -0.5f, 0.7f), new Vector3(0f, -0.5f, 0.3f), new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.3f, -0.5f, 0.7f));
        builder.AddQuad(new Vector3(0f, -0.5f, 1f), new Vector3(0f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.3f, -0.5f, 1f), new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0.7f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.7f, -0.5f, 1f), new Vector3(0.7f, -0.5f, 0.7f), new Vector3(1f, -0.5f, 0.7f), new Vector3(1f, -0.5f, 1f));
    }
    protected override void GenerateInvertedCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale)
   {
       float angle;
       rotation.ToAngleAxis(out angle, out _);
        builder.VertexMatrix =
        Matrix4x4.Scale(scale) *
        Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
        Matrix4x4.Translate(translation) *
        Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
        Matrix4x4.Rotate(rotation) *
        Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        builder.SetTextureMatrix(new Vector3(0.25f, 0.5f, 0f), -angle);
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.3f), new Vector3(0.7f, -0.5f, 0f), new Vector3(1f, -0.5f, 0f), new Vector3(1f, -0.5f, 0.3f));

        builder.SetTextureMatrix(new Vector3(0.25f, 0f, 0f), 0);
        builder.AddQuad(new Vector3(0.3f, 0f, 0.3f), new Vector3(0.3f, 0f, 0f), new Vector3(0.7f, -0.5f, 0f), new Vector3(0.7f, -0.5f, 0.3f),
        new Vector2[4]{ new Vector2(0.3f,  0.7f), new Vector2(0f, 0.7f), new Vector2(0f, 0.02f), new Vector2(0.3f, 0.02f)});

        builder.SetTextureMatrix(new Vector3(0.25f, 0f, 0f), 0);
        builder.AddTriangle(new Vector3(0.3f, 0f, 0.7f), new Vector3(0.3f, 0f, 0.3f), new Vector3(0.7f, -0.5f, 0.3f),
        new Vector2[3]{new Vector2(0.7f,  0.7f), new Vector2(0.3f, 0.7f), new Vector2(0.3f, 0.02f)});
        builder.AddTriangle(new Vector3(0.3f, 0f, 0.7f), new Vector3(0.7f, -0.5f, 0.3f), new Vector3(0.7f, 0f, 0.7f),
        new Vector2[3]{new Vector2(0.3f, 0.7f), new Vector2(0.7f,  0.02f), new Vector2(0.7f, 0.7f)});

        builder.AddQuad(new Vector3(0.7f, 0f, 0.7f), new Vector3(0.7f, -0.5f, 0.3f), new Vector3(1f, -0.5f, 0.3f), new Vector3(1f, 0f, 0.7f),
        new Vector2[4]{new Vector2(0.7f, 0.7f), new Vector2(0.7f, 0.02f), new Vector2(1f,  0.02f), new Vector2(1f, 0.7f)});

        builder.SetTextureMatrix(new Vector3(0f, 0.5f, 0f), -angle);
        builder.AddQuad(new Vector3(0f, 0f, 0.3f), new Vector3(0f, 0f, 0f), new Vector3(0.3f, 0f, 0f), new Vector3(0.3f, 0f, 0.3f));
        builder.AddQuad(new Vector3(0f, 0f, 0.7f), new Vector3(0f, 0f, 0.3f), new Vector3(0.3f, 0f, 0.3f), new Vector3(0.3f, 0f, 0.7f));
        builder.AddQuad(new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0.7f), new Vector3(0.3f, 0f, 0.7f), new Vector3(0.3f, 0f, 1f));
        builder.AddQuad(new Vector3(0.3f, 0f, 1f), new Vector3(0.3f, 0f, 0.7f), new Vector3(0.7f, 0f, 0.7f), new Vector3(0.7f, 0f, 1f));
        builder.AddQuad(new Vector3(0.7f, 0f, 1f), new Vector3(0.7f, 0f, 0.7f), new Vector3(1f, 0f, 0.7f), new Vector3(1f, 0f, 1f));
        
        // Bridge
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(1f, 0.2f, 0.7f), new Vector3(0.3f, 0.2f, 0.7f), new Vector3(0.3f, 0.2f, 0f), new Vector3(1f, 0.2f, 0f));
        builder.AddQuad(new Vector3(1f, 0.5f, 0.7f), new Vector3(0.3f, 0.5f, 0.7f), new Vector3(0.3f, 0f, 0.7f), new Vector3(1f, 0f, 0.7f),
            new []{new Vector2(1, 0), new Vector2(0, 0), new Vector2(0, 0.5f), new Vector2(1, 0.5f)});
        builder.AddQuad(new Vector3(1f, 0.5f, 1f), new Vector3(0f, 0.5f, 1f), new Vector3(0f, 0.5f, 0.7f), new Vector3(1f, 0.5f, 0.7f));
        builder.AddQuad(new Vector3(0f, 0.5f, 1f), new Vector3(1f, 0.5f, 1f), new Vector3(1f, 0f, 1f), new Vector3(0f, 0f, 1f),
            new []{ new Vector2(0, 0.5f), new Vector2(1, 0.5f), new Vector2(1, 0), new Vector2(0, 0)});
        builder.AddQuad(new Vector3(0f, 0.5f, 1f), new Vector3(1f, 0.5f, 1f), new Vector3(1f, 0f, 1f), new Vector3(0f, 0f, 1f),
            new []{ new Vector2(0, 0.5f), new Vector2(1, 0.5f), new Vector2(1, 0), new Vector2(0, 0)});
        builder.AddQuad(new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0.5f, 0f), new Vector3(0f, 0.5f, 1f),
            new []{new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 0.5f), new Vector2(0, 0.5f)});

    }
}