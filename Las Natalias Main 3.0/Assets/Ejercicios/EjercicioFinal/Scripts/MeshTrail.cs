using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{
    public float activeTime = 2f;

    [Header("Mesh")]
    public float meshRefreshRate = 0.1f;
    public float meshDestroyDelay = 3f;
    public Transform positionToSpawn;

    [Header("Shader")]
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.01f;
    public float shaderVarRefreshRate = 0.05f;
    public GameObject prefabToSpawn;
    private GameObject spawnedPrefab;

    private bool isTrailActive;
    private SkinnedMeshRenderer[] skinnedMeshRenderers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isTrailActive)
        {
            isTrailActive = true;
            StartCoroutine(ActivateTrail(activeTime));
        }
    }

    IEnumerator ActivateTrail(float timeActive)
    {
        while (timeActive > 0)
        {
            timeActive -= meshRefreshRate;

            if (skinnedMeshRenderers == null)
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

            for (int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                SkinnedMeshRenderer originalRenderer = skinnedMeshRenderers[i];

                for (int submeshIndex = 0; submeshIndex < originalRenderer.sharedMesh.subMeshCount; submeshIndex++)
                {
                    GameObject gObj = new GameObject();
                    gObj.transform.SetPositionAndRotation(positionToSpawn.position, positionToSpawn.rotation);

                    MeshRenderer mr = gObj.AddComponent<MeshRenderer>();
                    MeshFilter mf = gObj.AddComponent<MeshFilter>();

                    spawnedPrefab = Instantiate(prefabToSpawn, positionToSpawn.position, Quaternion.identity);

                    Mesh mesh = new Mesh();
                    originalRenderer.BakeMesh(mesh);

                    int[] triangles = mesh.GetTriangles(submeshIndex);
                    mesh.SetTriangles(triangles, 0);

                    mf.mesh = mesh;
                    mr.material = mat;

                    StartCoroutine(AnimateMaterialFloat(mr.material, 0, shaderVarRate, shaderVarRefreshRate));

                    Destroy(gObj, meshDestroyDelay);
                    Destroy(spawnedPrefab, meshDestroyDelay);
                }
            }

            yield return new WaitForSeconds(meshRefreshRate);
        }
        isTrailActive = false;
    }

    IEnumerator AnimateMaterialFloat (Material mat, float goal, float rate, float refreshRate)
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        while (valueToAnimate > goal)
        {
            valueToAnimate -= rate;
            mat.SetFloat(shaderVarRef, valueToAnimate);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}