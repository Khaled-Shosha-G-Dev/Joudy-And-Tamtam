using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderInstanceObject {
    public GameObject singletonReferenceInScene;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Material material;

    public RenderInstanceObject(GameObject singleton, SkinnedMeshRenderer skinnedMesh, Material mat){
        singletonReferenceInScene = singleton;
        skinnedMeshRenderer = skinnedMesh;
        material = mat;
    }
}

public class TroopInstanceDrawer : MonoBehaviour
{
    public Dictionary<GameObject, List<Matrix4x4>> transformInstances = new Dictionary<GameObject, List<Matrix4x4>>();
    private Dictionary<GameObject, RenderInstanceObject> renderInstances = new Dictionary<GameObject, RenderInstanceObject>();

    private List<Mesh> meshesToClear = new List<Mesh>();
    void LateUpdate()
    {
        foreach(var mesh in meshesToClear){
            Destroy(mesh);
        }
        meshesToClear.Clear();
        //validate that all keys exist in the other dictionary, and if not create it
        foreach(var key in transformInstances.Keys){
            if(!renderInstances.ContainsKey(key)){
                GameObject singleton = Instantiate(key);
                singleton.transform.Translate(0f, 20f, 0f);
                SkinnedMeshRenderer skinnedMeshRenderer = singleton.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
                Material material = skinnedMeshRenderer.sharedMaterial;
                renderInstances.Add(key, new RenderInstanceObject(singleton, skinnedMeshRenderer, material));
            }
        }
        //Draw Instances
        foreach(GameObject key in transformInstances.Keys){
            Mesh mesh = new Mesh();
            // Debug.Log(renderInstances[key].singletonReferenceInScene.name);      

            renderInstances[key].skinnedMeshRenderer.BakeMesh(mesh);

            //issue the draw calls
            if(transformInstances[key].Count > 0){
                Graphics.DrawMeshInstanced(mesh, 0, renderInstances[key].material, transformInstances[key].ToArray(), transformInstances[key].Count);
            }
            //add the mesh to the meshes to clear to avoid memory leaks
            meshesToClear.Add(mesh);
        }

        foreach(var matrices in transformInstances.Values){
            matrices.Clear();
        }
    }
}
