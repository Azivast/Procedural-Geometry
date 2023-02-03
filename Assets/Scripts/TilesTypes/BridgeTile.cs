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
        int e = 0, n = 2;
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
                    n = 4;
                    break;
                case 2:
                    e = 4;
                    n = 6;
                    break;
                case 3:
                    e = 6;
                    n = 0;
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
            
            GenerateCornerBridgePiece(pos, Quaternion.AngleAxis(-90 + -90 * i, Vector3.up), Vector3.one, -90 * i);
            
            // if (CheckSameTypeSpecific(neighbours, e, new []{true, false}))
            // {
            //     GenerateSlopeBridgePiece(pos, Quaternion.AngleAxis(+ -90 * i, Vector3.up), Vector3.one, -90 * i);
            // }
            // else if (CheckSameTypeSpecific(neighbours, n, new []{true, false}))
            // {
            //     GenerateSlopeBridgePiece(pos, Quaternion.AngleAxis(270 + -90 * i, Vector3.up), Vector3.one, 90 - 90 * i);
            // }

        }

        builder.Build(mesh);
    }
    
    public override void UpdateMesh(bool[,] neighbours, Mesh mesh)
    {
        base.UpdateMesh(neighbours, mesh);
        UpdateBridge(neighbours, mesh);
    }

    // protected void GenerateSlopeBridgePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f)
    // {
    //     builder.VertexMatrix =
    //         Matrix4x4.Scale(scale) *
    //         Matrix4x4.Scale(new Vector3(0.5f, 0.5f, 0.5f)) *
    //         Matrix4x4.Translate(translation) *
    //         Matrix4x4.Translate(new Vector3(0.5f, 0, 0.5f)) *
    //         Matrix4x4.Rotate(rotation) *
    //         Matrix4x4.Translate(new Vector3(-0.5f, 0, -0.5f));
    //
    //     // Bridge
    //     builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle);
    //     builder.AddQuad(new Vector3(1.3f, 0f, 1f), new Vector3(1f, 0.2f, 1f), new Vector3(1f, 0.2f, 0f), new Vector3(1.3f, 0f, 0f));
    //     builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), textureAngle);
    // }

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
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 90-textureAngle);
        builder.AddQuad(new Vector3(1f, 0.2f, 1f), new Vector3(0f, 0.2f, 1f), new Vector3(0f, 0.2f, 0f), new Vector3(1f, 0.2f, 0f));

        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 0);
        builder.AddQuad(new Vector3(0.7f, 0.5f, 0.3f), new Vector3(1f, 0.5f, 0.3f), new Vector3(1f, 0f, 0.3f), new Vector3(.70f, 0f, 0.3f),
            new []{ new Vector2(0.3f, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0f) , new Vector2(0.3f, 0f)});
        builder.AddQuad(new Vector3(0.7f, 0f, 0.3f), new Vector3(0.7f, 0f, 0f), new Vector3(0.7f, 0.5f, 0f), new Vector3(0.7f, 0.5f, 0.3f),
            new []{new Vector2(0, 0), new Vector2(0.3f, 0), new Vector2(0.3f, 0.5f), new Vector2(0, 0.5f)});
        builder.AddQuad(new Vector3(1f, 0f, 0f), new Vector3(1f, 0f, 0.3f), new Vector3(1f, 0.5f, 0.3f), new Vector3(1f, 0.5f, 0f),
            new []{new Vector2(0, 0), new Vector2(0.3f, 0), new Vector2(0.3f, 0.5f), new Vector2(0, 0.5f)});
        builder.AddQuad(new Vector3(0.7f, 0f, 0f),new Vector3(1f, 0f, 0f), new Vector3(1f, 0.5f, 0f),new Vector3(0.7f, 0.5f, 0f),
            new []{new Vector2(0, 0), new Vector2(0.3f, 0), new Vector2(0.3f, 0.5f), new Vector2(0, 0.5f)});
        
        builder.AddQuad(new Vector3(0.7f, 0f, 0.3f), new Vector3(1f, 0f, 0.3f), new Vector3(1f, -0.5f, 0.3f), new Vector3(.70f, -0.5f, 0.3f),
            new []{ new Vector2(0.3f, 1f), new Vector2(0, 1f), new Vector2(0, 0.5f) , new Vector2(0.3f, 0.5f)});
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0.3f), new Vector3(0.7f, -0.5f, 0f), new Vector3(0.7f, 0f, 0f), new Vector3(0.7f, 0f, 0.3f),
            new []{new Vector2(0, 0.5f), new Vector2(0.3f, 0.5f), new Vector2(0.3f, 1f), new Vector2(0, 1f)});
        builder.AddQuad(new Vector3(1f, -0.5f, 0f), new Vector3(1f, -0.5f, 0.3f), new Vector3(1f, 0f, 0.3f), new Vector3(1f, 0f, 0f),
            new []{new Vector2(0, 0.5f), new Vector2(0.3f, 0.5f), new Vector2(0.3f, 1f), new Vector2(0, 1f)});
        builder.AddQuad(new Vector3(0.7f, -0.5f, 0f),new Vector3(1f, -0.5f, 0f), new Vector3(1f, 0f, 0f),new Vector3(0.7f, 0f, 0f),
            new []{new Vector2(0, 0.5f), new Vector2(0.3f, 0.5f), new Vector2(0.3f, 1), new Vector2(0, 1)});

        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 90-textureAngle);
        builder.AddQuad(new Vector3(1f, 0.5f, 0.3f), new Vector3(0.7f, 0.5f, 0.3f), new Vector3(0.7f, 0.5f, 0f), new Vector3(1f, 0.5f, 0f));
        
        builder.SetTextureMatrix(new Vector3(0.5f, 0.5f, 0f), 90-textureAngle);
        builder.AddQuad(new Vector3(0f, 0.2f, 1f), new Vector3(1f, 0.2f, 1f), new Vector3(1f, 0.2f, 0f), new Vector3(0f, 0.2f, 0f));

    }
}