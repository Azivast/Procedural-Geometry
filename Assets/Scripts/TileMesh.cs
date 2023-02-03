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

    protected virtual bool[] type
    {
        get { return new bool[] {false, false}; }
    }

    // Start is called before the first frame update
    protected TileMesh()
    {
        builder = new MeshBuilder();
    }

    protected bool CheckSameType(bool[,] neighbours, int selectedNeighbour)
    {
        if (type[1])
            return neighbours[selectedNeighbour, 1] == type[1];
        else if (type[0])
            return neighbours[selectedNeighbour, 0] == type[0];
        else return false;
    }

    protected bool CheckSameTypeExact(bool[,] neighbours, int selectedNeighbour) // Will only match if both bools match
    {
        return neighbours[selectedNeighbour, 0] == type[0] &&
               neighbours[selectedNeighbour, 1] == type[1];
    }
    
    protected bool CheckSameTypeSpecific(bool[,] neighbours, int selectedNeighbour, bool[] type)
    {
        return neighbours[selectedNeighbour, 0] == type[0] &&
               neighbours[selectedNeighbour, 1] == type[1];
    }
    
    public virtual void UpdateMesh(bool[,] neighbours, Mesh mesh)
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
            
            if (CheckSameType(neighbours, e) &&
                CheckSameType(neighbours, ne) &&
                CheckSameType(neighbours, n))
            {
                GenerateInnerPiece(pos, Quaternion.AngleAxis(-90*i, Vector3.up), Vector3.one,- 90*i);
            }
            else if (CheckSameType(neighbours, e) &&
                     CheckSameType(neighbours, n))
            {
                GenerateCornerPiece(pos, Quaternion.AngleAxis(-90 + -90*i, Vector3.up), Vector3.one, - 90*i);
            }
            else if (CheckSameType(neighbours, e))
            {
                GenerateSidePiece(pos, Quaternion.AngleAxis(180 + -90*i, Vector3.up), Vector3.one,  - 90*i);
            }
            else if (CheckSameType(neighbours, n))
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

    protected virtual void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f) {}
    protected virtual void GenerateInnerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f) {}
    protected virtual void GenerateCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f) {}
    protected virtual void GenerateInvertedCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale, float textureAngle = 0f) {}
}
