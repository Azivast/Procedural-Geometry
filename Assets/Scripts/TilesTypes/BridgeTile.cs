using System.Collections;
using System.Collections.Generic;
using Grid;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BridgeTile : WaterTile
{
    protected override bool[] type
    {
        get { return new bool[] {true, true}; }
    }


    public void UpdateBridge(bool[,] neighbours, Mesh mesh)
    {
        int e = 0, ne = 1, n = 2, nw = 3, w = 4, s = 6;
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            // TODO: Better implementation than switch statements
            switch (i)
            {
                case 0:
                    // already correct
                    break;
                case 1:
                    e = 2;
                    ne = 3;
                    n = 4;
                    nw = 5;
                    w = 6;
                    s = 0;
                    break;
                case 2:
                    e = 4;
                    ne = 5;
                    n = 6;
                    nw = 7;
                    w = 0;
                    s = 2;
                    break;
                case 3:
                    e = 6;
                    ne = 7;
                    n = 0;
                    nw = 1;
                    w = 2;
                    s = 4;
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
                GenerateLowerBridgePiece(pos, Quaternion.AngleAxis(-90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeExact(neighbours, e) &&
                CheckSameTypeSpecific(neighbours, ne, new []{true, false}) &&
                CheckSameTypeExact(neighbours, n))
            {
                GenerateSlopeBridgePiece(pos, Quaternion.AngleAxis(270 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
                GenerateLowerBridgePiece(pos, Quaternion.AngleAxis(-90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeExact(neighbours, e) &&
                     CheckSameTypeExact(neighbours, ne) &&
                     CheckSameTypeSpecific(neighbours, n, new []{true, false}))
            {
                GenerateSlopeBridgePiece(pos, Quaternion.AngleAxis(270 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
                GenerateLowerBridgePiece(pos, Quaternion.AngleAxis(-90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeExact(neighbours, e) &&
                     CheckSameTypeSpecific(neighbours, ne, new []{true, false}) &&
                     CheckSameTypeSpecific(neighbours, n, new []{true, false}))
            {
                GenerateSlopeBridgePiece(pos, Quaternion.AngleAxis(270 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
                GenerateLowerBridgePiece(pos, Quaternion.AngleAxis(-90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeExact(neighbours, e) &&
                     CheckSameTypeExact(neighbours, n))
            {
                GenerateCornerBridgePiece(pos, Quaternion.AngleAxis(-90 + -90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeExact(neighbours, e) &&
                     CheckSameTypeExact(neighbours, n))
            {
                GenerateCornerBridgePiece(pos, Quaternion.AngleAxis(-90 + -90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeSpecific(neighbours, e, new []{true, false}))
            {
                GenerateSideBridgePiece(pos, Quaternion.AngleAxis(180 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
                GenerateSlopeBridgePiece(pos, Quaternion.AngleAxis(+ -90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeSpecific(neighbours, n, new []{true, false}))
            {
                GenerateSlopeBridgePiece(pos, Quaternion.AngleAxis(270 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
                GenerateSideBridgePiece(pos, Quaternion.AngleAxis(270 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
            }
            else if (CheckSameTypeExact(neighbours, e))
            {
                GenerateSideBridgePiece(pos, Quaternion.AngleAxis(180 + -90 * i, Vector3.up), Vector3.one, -90 * i);
            }
            else if (CheckSameTypeExact(neighbours, n))
            {
                GenerateSideBridgePiece(pos, Quaternion.AngleAxis(270 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
            }
            else
            {
                GenerateInvertedCornerBridgePiece(pos, Quaternion.AngleAxis(90 + -90 * i, Vector3.up), Vector3.one,
                    90 - 90 * i);
            }
        }

        builder.Build(mesh);
    }
    
    public override void UpdateMesh(bool[,] neighbours, Mesh mesh)
    {
        base.UpdateMesh(neighbours, mesh);
        UpdateBridge(neighbours, mesh);
    }

    protected void GenerateLowerBridgePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), -textureAngle);
        builder.AddQuad(new Vector3(1f, 0.2f, 1f), new Vector3(0f, 0.2f, 1f), new Vector3(0f, 0.2f, 0f), new Vector3(1f, 0.2f, 0f));

        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), -textureAngle);
        builder.AddQuad(new Vector3(0f, 0.2f, 1f), new Vector3(1f, 0.2f, 1f), new Vector3(1f, 0.2f, 0f), new Vector3(0f, 0.2f, 0f));
    }
    
    protected void GenerateSlopeBridgePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
        builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        // Bridge
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle);
        builder.AddQuad(new Vector3(1.3f, 0f, 1f), new Vector3(1f, 0.2f, 1f), new Vector3(1f, 0.2f, 0f), new Vector3(1.3f, 0f, 0f));
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle);
        // builder.AddQuad(new Vector3(0f, 0.5f, 0.3f), new Vector3(0f, 0.5f, 0f), new Vector3(0.3f, 0.5f, 0f), new Vector3(0.3f, 0.5f, 0.3f));
        // builder.AddQuad(new Vector3(0f, 0f, 0.3f), new Vector3(0f, 0.5f, 0.3f), new Vector3(0.3f, 0.5f, 0.3f), new Vector3(0.3f, 0f, 0.3f));
        // builder.AddQuad(new Vector3(0.3f, 0f, 0.3f), new Vector3(0.3f, 0.5f, 0.3f), new Vector3(0.3f, 0.5f, 0f), new Vector3(0.3f, 0f, 0f));
        // builder.AddQuad(new Vector3(0f, 0.5f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.3f, 0f, 0f),new Vector3(0.3f, 0.5f, 0f));

    }

    protected void GenerateSideBridgePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle)
    {
         builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        // Bridge
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle);
        builder.AddQuad(new Vector3(1f, 0.2f, 1f), new Vector3(0f, 0.2f, 1f), new Vector3(0f, 0.2f, 0.3f), new Vector3(1f, 0.2f, 0.3f));
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(1f, 0.5f, 0.3f), new Vector3(0f, 0.5f, 0.3f), new Vector3(0f, 0.5f, 0f), new Vector3(1f, 0.5f, 0f));
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 0f), new Vector3(1f, 0.5f, 0f), new Vector3(0f, 0.5f, 0f),
            new []{new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 0.5f), new Vector2(0, 0.5f)});
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(1f, 0f, 0.3f), new Vector3(0f, 0f, 0.3f), new Vector3(0f, 0.5f, 0.3f), new Vector3(1f, 0.5f, 0.3f),
            new []{new Vector2(0, 0.5f), new Vector2(1, 0.5f), new Vector2(1, 1f), new Vector2(0, 1f)});
        
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), -textureAngle);
        builder.AddQuad(new Vector3(0f, 0.2f, 1f), new Vector3(1f, 0.2f, 1f), new Vector3(1f, 0.2f, 0f), new Vector3(0f, 0.2f, 0f));

    }
    
    protected void GenerateCornerBridgePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    {
         builder.VertexMatrix =
            Matrix4x4.Scale(scale) *
            Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
            Matrix4x4.Translate(translation) *
            Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
            Matrix4x4.Rotate(rotation) *
            Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));

        // Bridge
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle);
        builder.AddQuad(new Vector3(1f, 0.2f, 1f), new Vector3(0f, 0.2f, 1f), new Vector3(0f, 0.2f, 0f), new Vector3(1f, 0.2f, 0f));

        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(0.7f, 0.5f, 0.3f), new Vector3(1f, 0.5f, 0.3f), new Vector3(1f, 0f, 0.3f), new Vector3(.70f, 0f, 0.3f),
            new []{ new Vector2(1, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0) , new Vector2(1, 0)});
        builder.AddQuad(new Vector3(0.7f, 0f, 0.3f), new Vector3(0.7f, 0f, 0f), new Vector3(0.7f, 0.5f, 0f), new Vector3(0.7f, 0.5f, 0.3f),
            new []{new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 0.5f), new Vector2(0, 0.5f)});

        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle-90);
        builder.AddQuad(new Vector3(1f, 0.5f, 0.3f), new Vector3(0.7f, 0.5f, 0.3f), new Vector3(0.7f, 0.5f, 0f), new Vector3(1f, 0.5f, 0f));
        
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), -textureAngle);
        builder.AddQuad(new Vector3(0f, 0.2f, 1f), new Vector3(1f, 0.2f, 1f), new Vector3(1f, 0.2f, 0f), new Vector3(0f, 0.2f, 0f));

    }
    protected void GenerateInvertedCornerBridgePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
   {
       builder.VertexMatrix =
        Matrix4x4.Scale(scale) *
        Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
        Matrix4x4.Translate(translation) *
        Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
        Matrix4x4.Rotate(rotation) *
        Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
       
        // Bridge
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle);
        builder.AddQuad(new Vector3(1f, 0.2f, 0.7f), new Vector3(0.3f, 0.2f, 0.7f), new Vector3(0.3f, 0.2f, 0f), new Vector3(1f, 0.2f, 0f));
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(1f, 0.5f, 0.7f), new Vector3(0.3f, 0.5f, 0.7f), new Vector3(0.3f, 0f, 0.7f), new Vector3(1f, 0f, 0.7f),
            new []{new Vector2(1f, 1f), new Vector2(0.3f, 1f), new Vector2(0.3f, 0.5f), new Vector2(1f, 0.5f)});
        builder.AddQuad(new Vector3(0f, 0.5f, 1f), new Vector3(1f, 0.5f, 1f), new Vector3(1f, 0f, 1f), new Vector3(0f, 0f, 1f),
            new []{ new Vector2(1, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0) , new Vector2(1, 0)});
        builder.AddQuad(new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0.5f, 0f), new Vector3(0f, 0.5f, 1f),
            new []{new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 0.5f), new Vector2(0, 0.5f)});
        builder.AddQuad(new Vector3(0.3f, 0f, 0f), new Vector3(0.3f, 0f, 1f), new Vector3(0.3f, 0.5f, 1f),new Vector3(0.3f, 0.5f, 0f), 
            new []{new Vector2(0, 0.5f), new Vector2(1, 0.5f), new Vector2(1, 1f), new Vector2(0, 1f)});
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle-90);
        builder.AddQuad(new Vector3(1f, 0.5f, 1f), new Vector3(0f, 0.5f, 1f), new Vector3(0f, 0.5f, 0.7f), new Vector3(1f, 0.5f, 0.7f),
            new []{ new Vector2(0, 1f), new Vector2(0, 0f), new Vector2(0.3f, 0f), new Vector2(0.3f, 1f)});
        builder.AddQuad(new Vector3(0.3f, 0.5f, 0.7f), new Vector3(0f, 0.5f, 0.7f), new Vector3(0f, 0.5f, 0f),new Vector3(0.3f, 0.5f, 0f), 
            new []{  new Vector2(0, 0.3f), new Vector2(0f, 0f), new Vector2(0.7f, 0f), new Vector2(0.7f, 0.3f)});
        
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), -textureAngle);
        builder.AddQuad(new Vector3(0f, 0.2f, 1f), new Vector3(1f, 0.2f, 1f), new Vector3(1f, 0.2f, 0f), new Vector3(0f, 0.2f, 0f));

   }
}