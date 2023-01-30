using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Grid;
using UnityEngine;

public abstract class TileMesh : MonoBehaviour
{
    protected MeshBuilder builder;
    protected Mesh mesh;
    private GridTile tile;
    public Mesh Mesh => mesh;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        mesh = new Mesh();
        builder = new MeshBuilder();
    }
    public virtual void GenerateMesh()
    {
        // TODO: Check against neighbours
        builder.Build(mesh);
    }

    private int i = 0;
    public void UpdateMesh()
    {
        if (i > 0) return;
        GenerateMesh();
        i++;
    }

    protected virtual void GenerateSidePiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateInnerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}
    protected virtual void GenerateInvertedCornerPiece(Vector3 translation, Quaternion rotation, Vector3 scale) {}

}
