using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : TileMesh
{
    protected override bool[] type
    {
        get { return new bool[] {true, false}; }
    }
    
        public override void UpdateMesh(bool[,] neighbours, Mesh mesh)
    {
        builder.Clear(mesh);

        int e = 0, ne = 1, n = 2, w = 4, s = 6;
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    // already correct
                    break;
                case 1:
                    e = 2; ne = 3; n = 4; w = 6; s = 0;
                    break;
                case 2:
                    e = 4; ne = 5; n = 6; w = 0; s = 2;
                    break;
                case 3:
                    e = 6; ne = 7; n = 0; w = 2; s = 4;
                    break;
            }
            switch (i)
            {
                case 0:
                    // already correct
                    break;
                case 1:
                    pos = new Vector3(-1, 0, 0);
                    break;
                case 2:
                    pos = new Vector3(-1, 0, -1);
                    break;
                case 3:
                    pos = new Vector3(0, 0, -1);
                    break;
            }
            
            if (CheckSameTypeExact(neighbours, e) &&
                CheckSameTypeExact(neighbours, ne) &&
                CheckSameTypeExact(neighbours, n))
            {
                GenerateInnerPiece(pos, Quaternion.AngleAxis(-90*i, Vector3.up), Vector3.one,- 90*i);
            }
            else if (CheckSameTypeExact(neighbours, e) &&
                     CheckSameTypeExact(neighbours, n))
            {
                GenerateCornerPiece(pos, Quaternion.AngleAxis(-90 + -90*i, Vector3.up), Vector3.one, - 90*i);
            }
            else if (CheckSameTypeExact(neighbours, e))
            {
                GenerateSidePiece(pos, Quaternion.AngleAxis(180 + -90*i, Vector3.up), Vector3.one,  - 90*i);
            }
            else if (CheckSameTypeExact(neighbours, n))
            {
                GenerateSidePiece(pos, Quaternion.AngleAxis(270 + -90*i, Vector3.up), Vector3.one, 90-90*i);
            }
            else
            {
                GenerateInvertedCornerPiece(pos, Quaternion.AngleAxis(90 + -90*i, Vector3.up), Vector3.one, 90-90*i);
            }
        }
        builder.Build(mesh);
    }

    protected override void GenerateInnerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
        builder.SetTextureMatrix(new Vector3(0.5f, 0f, 0f), -textureAngle);

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

        builder.SetTextureMatrix(new Vector3(0f, 0f, 0f), 180);
        builder.AddQuad(new Vector3(0f, -0.5f, 0.7f), new Vector3(0f, 0, 0.3f), new Vector3(0.3f, 0, 0.35f), new Vector3(0.3f, -0.5f, 0.75f),
            new Vector2[4]{new Vector2(0, 0.98f), new Vector2(0, 0.3f), new Vector2(0.3f, 0.3f), new Vector2(0.3f, 0.98f)});
        builder.AddQuad(new Vector3(0.3f, -0.5f, 0.75f), new Vector3(0.3f, 0, 0.35f), new Vector3(0.7f, 0, 0.25f), new Vector3(0.7f, -0.5f, 0.65f),
            new Vector2[4]{new Vector2(0.3f, 0.98f), new Vector2(0.3f, 0.3f), new Vector2(0.7f, 0.3f), new Vector2(0.7f, 0.98f)});
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.65f), new Vector3(0.7f, 0, 0.25f), new Vector3(1f, 0, 0.3f), new Vector3(1f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0.7f, 0.98f), new Vector2(0.7f, 0.3f), new Vector2(1f, 0.3f), new Vector2(1f, 0.98f)});

        builder.SetTextureMatrix(new Vector3(0.5f, 0f, 0f), 180-textureAngle);
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

        builder.SetTextureMatrix(new Vector3(0f, 0f, 0f), 180);
        builder.AddQuad(new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.3f, -0.5f, 0f), new Vector3(0.7f, 0, 0f), new Vector3(0.7f, 0, 0.3f),
            new Vector2[4]{ new Vector2(0.3f,  0.98f), new Vector2(0f, 0.98f), new Vector2(0f, 0.3f), new Vector2(0.3f, 0.3f)});
        builder.AddTriangle(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.3f, -0.5f, 0.3f), new Vector3(0.7f, 0f, 0.3f),
            new Vector2[3]{new Vector2(0.7f,  0.98f), new Vector2(0.3f, 0.98f), new Vector2(0.3f, 0.3f)});
        builder.AddTriangle(new Vector3(0.3f, -0.5f, 0.7f), new Vector3(0.7f, 0, 0.3f), new Vector3(0.7f, -0.5f, 0.7f),
            new Vector2[3]{new Vector2(0.3f, 0.98f), new Vector2(0.7f,  0.3f), new Vector2(0.7f, 0.98f)});
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.7f), new Vector3(0.7f, 0, 0.3f), new Vector3(1f, 0, 0.3f), new Vector3(1f, -0.5f, 0.7f),
            new Vector2[4]{new Vector2(0.7f, 0.98f), new Vector2(0.7f, 0.3f), new Vector2(1f,  0.3f), new Vector2(1f, 0.98f)});

        builder.SetTextureMatrix(new Vector3(0.5f, 0f, 0f), 90-textureAngle);
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

        builder.SetTextureMatrix(new Vector3(0.5f, 0f, 0f), -textureAngle);
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.3f), new Vector3(0.7f, -0.5f, 0f), new Vector3(1f, -0.5f, 0f), new Vector3(1f, -0.5f, 0.3f));

        builder.SetTextureMatrix(new Vector3(0f, 0f, 0f), 0);
        builder.AddQuad(new Vector3(0.3f, 0f, 0.3f), new Vector3(0.3f, 0f, 0f), new Vector3(0.7f, -0.5f, 0f), new Vector3(0.7f, -0.5f, 0.3f),
        new Vector2[4]{ new Vector2(0.3f,  0.7f), new Vector2(0f, 0.7f), new Vector2(0f, 0.02f), new Vector2(0.3f, 0.02f)});

        builder.SetTextureMatrix(new Vector3(0f, 0f, 0f), 0);
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
