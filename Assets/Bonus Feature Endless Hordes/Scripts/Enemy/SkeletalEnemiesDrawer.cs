using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletalEnemiesDrawer : MonoBehaviour
{
    public GameObject referenceToInstance;
    // public Mesh mesh;
    public Material material;

    private List<Matrix4x4> matrices = new List<Matrix4x4>();

    Mesh meshToDeleteRef = null;

    void Start()
    {
        material = referenceToInstance.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().sharedMaterial;
    }
    void Update()
    {
        Destroy(meshToDeleteRef);
        matrices.Clear();
        Mesh mesh = new Mesh();
        referenceToInstance.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().BakeMesh(mesh);
        foreach(var trs in EnemysController.Instance.GetEnemyTroops){
            matrices.Add(trs.transform.localToWorldMatrix);
        }
        material.SetPass(0);
        Graphics.DrawMeshInstanced(mesh, 0, material, matrices.ToArray(), matrices.Count);
        meshToDeleteRef = mesh;
    }


}
