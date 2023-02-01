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
    protected GridTileProperty thisTileProperty;
    private GridTile tile;
    public Mesh Mesh => mesh;

    // Start is called before the first frame update
    protected TileMesh()
    {
        mesh = new Mesh();
        builder = new MeshBuilder();
    }

    public virtual void UpdateMesh(GridTileProperty[,] neighbours)
    {
        builder.Clear(mesh);
        
        // Upper Right
        if (neighbours[0,1] == thisTileProperty && 
            neighbours[1,1] == thisTileProperty &&
            neighbours[2,1] == thisTileProperty)
        {
            GenerateLowerPiece(new Vector3(0, 0, 0), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        }
        else if (neighbours[0,1] == thisTileProperty &&
                 neighbours[2,1] == thisTileProperty)
        {
            GenerateCornerPiece(new Vector3(0, 0, 0), Quaternion.AngleAxis(-90, Vector3.up), Vector3.one);
        }
        else if (neighbours[0,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(0, 0, 0), Quaternion.AngleAxis(180, Vector3.up), Vector3.one);
        }
        else if (neighbours[2,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(0, 0, 0), Quaternion.AngleAxis(270, Vector3.up), Vector3.one);
        }
        else if ((neighbours[6, 1] == thisTileProperty &&
                  neighbours[4, 1] == thisTileProperty)
                 ||
                 neighbours[4, 1] == thisTileProperty
                 ||
                 neighbours[6, 1] == thisTileProperty)
        {
            GenerateInvertedCornerPiece(new Vector3(0, 0, 0), Quaternion.AngleAxis(90, Vector3.up), Vector3.one);
        }
        else
        {
            GenerateInvertedCornerPiece(new Vector3(0, 0, 0), Quaternion.AngleAxis(90, Vector3.up), Vector3.one);
        }

        // Upper Left
        if (neighbours[2,1] == thisTileProperty && 
            neighbours[3,1] == thisTileProperty &&
            neighbours[4,1] == thisTileProperty)
        {
            GenerateLowerPiece(new Vector3(-1, 0, 0), Quaternion.AngleAxis(-90, Vector3.up), Vector3.one);
        }
        else if (neighbours[2,1] == thisTileProperty &&
                 neighbours[4,1] == thisTileProperty)
        {
            GenerateCornerPiece(new Vector3(-1, 0, 0), Quaternion.AngleAxis(-180, Vector3.up), Vector3.one);
        }
        else if (neighbours[2,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(-1, 0, 0), Quaternion.AngleAxis(90, Vector3.up), Vector3.one);
        }
        else if (neighbours[4,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(-1, 0, 0), Quaternion.AngleAxis(180, Vector3.up), Vector3.one);
        }
        else if ((neighbours[0, 1] == thisTileProperty &&
                  neighbours[6, 1] == thisTileProperty)
                 ||
                 neighbours[0, 1] == thisTileProperty
                 ||
                 neighbours[6, 1] == thisTileProperty)
        {
            GenerateInvertedCornerPiece(new Vector3(-1, 0, 0), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        }
        else
        {
            GenerateInvertedCornerPiece(new Vector3(-1, 0, 0), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        }
        
        // Lower Left
        if (neighbours[4,1] == thisTileProperty && 
            neighbours[5,1] == thisTileProperty &&
            neighbours[6,1] == thisTileProperty)
        {
            GenerateLowerPiece(new Vector3(-1, 0, -1), Quaternion.AngleAxis(-180, Vector3.up), Vector3.one);
        }
        else if (neighbours[4,1] == thisTileProperty &&
                 neighbours[6,1] == thisTileProperty)
        {
            GenerateCornerPiece(new Vector3(-1, 0, -1), Quaternion.AngleAxis(-270, Vector3.up), Vector3.one);
        }
        else if (neighbours[4,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(-1, 0, -1), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        }
        else if (neighbours[6,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(-1, 0, -1), Quaternion.AngleAxis(90, Vector3.up), Vector3.one);
        }
        else if ((neighbours[0, 1] == thisTileProperty &&
                  neighbours[2, 1] == thisTileProperty)
                 ||
                 neighbours[0, 1] == thisTileProperty
                 ||
                 neighbours[2, 1] == thisTileProperty)
        {
            GenerateInvertedCornerPiece(new Vector3(-1, 0, -1), Quaternion.AngleAxis(-90, Vector3.up), Vector3.one);
        }
        else
        {
            GenerateInvertedCornerPiece(new Vector3(-1, 0, -1), Quaternion.AngleAxis(-90, Vector3.up), Vector3.one);
        }
        
        // Lower Right
        if (neighbours[6,1] == thisTileProperty && 
            neighbours[7,1] == thisTileProperty &&
            neighbours[0,1] == thisTileProperty)
        {
            GenerateLowerPiece(new Vector3(0, 0, -1), Quaternion.AngleAxis(-270, Vector3.up), Vector3.one);
        }
        else if (neighbours[0,1] == thisTileProperty &&
                 neighbours[6,1] == thisTileProperty)
        {
            GenerateCornerPiece(new Vector3(0, 0, -1), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        }
        else if (neighbours[0,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(0, 0, -1), Quaternion.AngleAxis(0, Vector3.up), Vector3.one);
        }
        else if (neighbours[6,1] == thisTileProperty)
        {
            GenerateSidePiece(new Vector3(0, 0, -1), Quaternion.AngleAxis(-90, Vector3.up), Vector3.one);
        }
        else if ((neighbours[2, 1] == thisTileProperty &&
                  neighbours[4, 1] == thisTileProperty)
                 ||
                 neighbours[2, 1] == thisTileProperty
                 ||
                 neighbours[4, 1] == thisTileProperty)
        {
            GenerateInvertedCornerPiece(new Vector3(0, 0, -1), Quaternion.AngleAxis(-180, Vector3.up), Vector3.one);
        }
        else
        {
            GenerateInvertedCornerPiece(new Vector3(0, 0, -1), Quaternion.AngleAxis(-180, Vector3.up), Vector3.one);
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
