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
    public Mesh Mesh => mesh;

    // Start is called before the first frame update
    protected TileMesh()
    {
        mesh = new Mesh();
        builder = new MeshBuilder();
    }
    public void GenerateMesh()
    {
        builder.Build(mesh);
    }

    protected void ClearMesh()
    {
        mesh.Clear();
        mesh.MarkModified();
    }

    public virtual void UpdateMesh(GridTileProperty[,] neighbours, GridTile tile)
    {
        GenerateMesh();
    }

    protected virtual void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateUpperPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateLowerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateInvertedCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateDiagonalPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}

}
