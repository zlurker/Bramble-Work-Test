using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {

    public TreePopulators[] clickedTreePopulators;
    public TreePopulators[] autoSpawnedPopulators;

    public float autoSpawnGrowthChance = 0.05f;
    public Collider branchCollider;
    public float growthLimitScaleFactorAuto = 20;
    public float growthLimit;

    private float autoSpawned;


    public void SetGrowthLimit(float gL) {
        growthLimit = gL;
    }

    public void PopulateButtonClicked(int id) {
        GeneratePopulator(clickedTreePopulators[id]);
    }

    // Update is called once per frame
    void Update() {
        if(transform.localScale.z < growthLimit)
            GrowBranch();

        GenerateAutospawn();
    }

    void GrowBranch() {
        Vector3 currentScale = transform.localScale;
        currentScale.z += Random.value / 100;
        transform.localScale = currentScale;
    }

    void GeneratePopulator(TreePopulators populator) {
        //Vector3 randPoint = GetRandomPositionOnBranch();

        //Gets a random point within collider
        float randomZ = Random.Range(0, transform.localScale.z);

        Vector3 forwardDir = transform.position + transform.TransformDirection(0, 0, randomZ);

        //Vector3 genRandPoint = new Vector3(Random.Range(0, branchCollider.bounds.extents.x *2), Random.Range(0, branchCollider.bounds.extents.y * 2), Random.Range(0, branchCollider.bounds.extents.z * 2));
        //genRandPoint = TransformPointUnscaled(transform, genRandPoint);

        TreePopulators pInst = Instantiate(populator, forwardDir, Random.rotation);
        pInst.gameObject.SetActive(true);
    }

    public static Vector3 TransformPointUnscaled(Transform transform, Vector3 position) {
        var localToWorldMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        return localToWorldMatrix.MultiplyPoint3x4(position);
    }

    public static Vector3 InverseTransformPointUnscaled( Transform transform, Vector3 position) {
        var worldToLocalMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one).inverse;
        return worldToLocalMatrix.MultiplyPoint3x4(position);
    }

    void GenerateAutospawn() {
        for(int i = 0; i < autoSpawnedPopulators.Length; i++)
            if(Random.value < autoSpawnGrowthChance) {
                if(autoSpawned < (growthLimitScaleFactorAuto * growthLimit)) {
                    GeneratePopulator(autoSpawnedPopulators[i]);
                    autoSpawned++;
                }
            }
    }
}
