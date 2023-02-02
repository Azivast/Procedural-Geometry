using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Grid;
using UnityEngine;
using UnityEngine.WSA;

public abstract class TileMesh
{
    protected MeshBuilder builder;
    protected Mesh mesh;
    private GridTile tile;
    protected GridTileProperty[] type = {default, default};

    public Mesh Mesh => mesh;

    // Start is called before the first frame update
    protected TileMesh()
    {
        mesh = new Mesh();
        builder = new MeshBuilder();
    }

    private bool CheckSameType(GridTileProperty[,] neighbours, int selectedNeighbour)
    {
        if (type is null) return false; // TODO: This doesn't work
        return neighbours[selectedNeighbour, 0] == type[0] &&
               neighbours[selectedNeighbour, 1] == type[1];
    }

    public virtual void UpdateMesh(GridTileProperty[,] neighbours)
    {
        builder.Clear(mesh);

        int E = 0, NE = 1, N = 2, NW = 3, W = 4, SW = 5, S = 6, SE = 7;
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
                    E = 2; NE = 3; N = 4; NW = 5; W = 6; SW = 7; S = 0; SE = 1;
                    break;
                case 2:
                    E = 4; NE = 5; N = 6; NW = 7; W = 0; SW = 1; S = 2; SE = 3;
                    break;
                case 3:
                    E = 6; NE = 7; N = 0; NW = 1; W = 2; SW = 3; S = 4; SE = 5;
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
            
            if (CheckSameType(neighbours, E) &&
                CheckSameType(neighbours, NE) &&
                CheckSameType(neighbours, N))
            {
                GenerateLowerPiece(pos, Quaternion.AngleAxis(-90*i, Vector3.up), Vector3.one);
            }
            else if (CheckSameType(neighbours, E) &&
                     CheckSameType(neighbours, N))
            {
                GenerateCornerPiece(pos, Quaternion.AngleAxis(-90 + -90*i, Vector3.up), Vector3.one);
            }
            else if (CheckSameType(neighbours, E))
            {
                GenerateSidePiece(pos, Quaternion.AngleAxis(180 + -90*i, Vector3.up), Vector3.one);
            }
            else if (CheckSameType(neighbours, N))
            {
                GenerateSidePiece(pos, Quaternion.AngleAxis(270 + -90*i, Vector3.up), Vector3.one);
            }
            else if ((CheckSameType(neighbours, S) &&
                      CheckSameType(neighbours, W))
                     ||
                     CheckSameType(neighbours, W)
                     ||
                     CheckSameType(neighbours, S))
            {
                GenerateInvertedCornerPiece(pos, Quaternion.AngleAxis(90 + -90*i, Vector3.up), Vector3.one);
            }
            else
            {
                GenerateInvertedCornerPiece(pos, Quaternion.AngleAxis(90 + -90*i, Vector3.up), Vector3.one);
            }
        }
        builder.Build(mesh);
    }

    protected virtual void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateUpperPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateLowerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateInvertedCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateDiagonalPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}

}
