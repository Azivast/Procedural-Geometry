using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : TileMesh
{
    protected override bool[] type
    {
        get { return new bool[] {false, true}; }
    }

    protected override void GenerateInnerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
        builder.SetTextureMatrix(new Vector3(0.25f, 0.5f, 0f), -textureAngle);

        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        builder.AddQuad(new Vector3(1f, -0.5f, 1f), new Vector3(0f, -0.5f, 1f), new Vector3(0f, -0.5f, 0f), new Vector3(1f, -0.5f, 0f));
    }

    protected override void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
        
        builder.SetTextureMatrix(new Vector3(0f, 0.5f, 0f), -textureAngle-180);
        builder.AddQuad(new Vector3(0f, 0, 0.3f), new Vector3(0f, 0, 0f), new Vector3(0.3f, 0, 0f), new Vector3(0.3f, 0, 0.35f));
        builder.AddQuad(new Vector3(0.3f, 0, 0.35f), new Vector3(0.3f, 0, 0f), new Vector3(0.7f, 0, 0f), new Vector3(0.7f, 0, 0.25f));
        builder.AddQuad(new Vector3(0.7f, 0, 0.25f), new Vector3(0.7f, 0, 0f), new Vector3(1f, 0, 0f), new Vector3(1f, 0, 0.3f));

        builder.SetTextureMatrix(new Vector3(0.25f, 0f, 0f), 180);
        builder.AddQuad(new Vector3(0f, -0.5f, 0.7f), new Vector3(0f, 0, 0.3f), new Vector3(0.3f, 0, 0.35f), new Vector3(0.3f, -0.5f, 0.75f),
            new Vector2[4]{new Vector2(0, 0.98f), new Vector2(0, 0.3f), new Vector2(0.3f, 0.3f), new Vector2(0.3f, 0.98f)});
        builder.AddQuad(new Vector3(0.3f, -0.5f, 0.75f), new Vector3(0.3f, 0, 0.35f), new Vector3(0.7f, 0, 0.25f), new Vector3(0.7f, -0.5f, 0.65f),
            new Vector2[4]{new Vector2(0.3f, 0.98f), new Vector2(0.3f, 0.3f), new Vector2(0.7f, 0.3f), new Vector2(0.7f, 0.98f)});
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.65f), new Vector3(0.7f, 0, 0.25f), new Vector3(1f, 0, 0.3f), new Vector3(1f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0.7f, 0.98f), new Vector2(0.7f, 0.3f), new Vector2(1f, 0.3f), new Vector2(1f, 0.98f)});

        builder.SetTextureMatrix(new Vector3(0.25f, 0.5f, 0f), 180-textureAngle);
        builder.AddQuad(new Vector3(0f, -0.5f, 1f), new Vector3(0f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 0.75f), new Vector3(0.3f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.3f, -0.5f, 1f), new Vector3(0.3f, -0.5f, 0.75f), new Vector3(0.7f, -0.5f, 0.65f), new Vector3(0.7f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.7f, -0.5f, 1f), new Vector3(0.7f, -0.5f, 0.65f), new Vector3(1f, -0.5f, 0.7f), new Vector3(1f, -0.5f, 1f));
    }
    
    protected override void GenerateCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        builder.SetTextureMatrix(new Vector3(0f, 0.5f, 0f), 90-textureAngle);
        builder.AddQuad(new Vector3(0.7f, 0, 0.3f), new Vector3(0.7f, 0, 0f), new Vector3(1f, 0, 0f), new Vector3(1f, 0, 0.3f));

        builder.SetTextureMatrix(new Vector3(0.25f, 0f, 0f), 180);
        builder.AddQuad(new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.3f, -0.5f, 0f), new Vector3(0.7f, 0, 0f), new Vector3(0.7f, 0, 0.3f),
            new Vector2[4]{ new Vector2(0.3f,  0.98f), new Vector2(0f, 0.98f), new Vector2(0f, 0.3f), new Vector2(0.3f, 0.3f)});
        builder.AddTriangle(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.7f, 0f, 0.3f),
            new Vector2[3]{new Vector2(0.7f,  0.98f), new Vector2(0.3f, 0.98f), new Vector2(0.3f, 0.3f)});
        builder.AddTriangle(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.7f, 0, 0.3f), new Vector3(0.7f, -0.5f, 0.7f),
            new Vector2[3]{new Vector2(0.3f, 0.98f), new Vector2(0.7f,  0.3f), new Vector2(0.7f, 0.98f)});
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0.7f, 0, 0.3f), new Vector3(1f, 0, 0.3f), new Vector3(1f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0.7f, 0.98f), new Vector2(0.7f, 0.3f), new Vector2(1f,  0.3f), new Vector2(1f, 0.98f)});

        builder.SetTextureMatrix(new Vector3(0.25f, 0.5f, 0f), 90-textureAngle);
        builder.AddQuad(new Vector3(0f, -0.5f, 0.3f), new Vector3(0f, -0.5f, 0f), new Vector3(0.3f, -0.5f, 0f), new Vector3(0.3f, -0.5f, 0.3f));
        builder.AddQuad(new Vector3(0f, -0.5f, 0.7f), new Vector3(0f, -0.5f, 0.3f), new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.3f, -0.5f, 0.7f));
        builder.AddQuad(new Vector3(0f, -0.5f, 1f), new Vector3(0f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.3f, -0.5f, 1f), new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0.7f, -0.5f, 1f));
        builder.AddQuad(new Vector3(0.7f, -0.5f, 1f), new Vector3(0.7f, -0.5f, 0.7f), new Vector3(1f, -0.5f, 0.7f), new Vector3(1f, -0.5f, 1f));
    }
    protected override void GenerateInvertedCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
   {
       builder.VertexMatrix =
        Matrix4x4.Scale(scale) *
        Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
        Matrix4x4.Translate(translation) *
        Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
        Matrix4x4.Rotate(rotation) *
        Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        builder.SetTextureMatrix(new Vector3(0.25f, 0.5f, 0f), -textureAngle);
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

        builder.SetTextureMatrix(new Vector3(0f, 0.5f, 0f), -textureAngle);
        builder.AddQuad(new Vector3(0f, 0f, 0.3f), new Vector3(0f, 0f, 0f), new Vector3(0.3f, 0f, 0f), new Vector3(0.3f, 0f, 0.3f));
        builder.AddQuad(new Vector3(0f, 0f, 0.7f), new Vector3(0f, 0f, 0.3f), new Vector3(0.3f, 0f, 0.3f), new Vector3(0.3f, 0f, 0.7f));
        builder.AddQuad(new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0.7f), new Vector3(0.3f, 0f, 0.7f), new Vector3(0.3f, 0f, 1f));
        builder.AddQuad(new Vector3(0.3f, 0f, 1f), new Vector3(0.3f, 0f, 0.7f), new Vector3(0.7f, 0f, 0.7f), new Vector3(0.7f, 0f, 1f));
        builder.AddQuad(new Vector3(0.7f, 0f, 1f), new Vector3(0.7f, 0f, 0.7f), new Vector3(1f, 0f, 0.7f), new Vector3(1f, 0f, 1f));
    }
}
