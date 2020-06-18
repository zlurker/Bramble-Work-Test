using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {

    public TreePopulators[] clickedTreePopulators;
    public TreePopulators[] autoSpawnedPopulators;

    public float autoSpawnGrowthChance = 0.05f;
    public Collider branchCollider;
    public float growthLimitScaleFactorAuto = 20;

    private float autoSpawned;
    private float growthLimit;

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
        Vector3 genRandPoint = new Vector3(Random.Range(0, branchCollider.bounds.extents.x *2), Random.Range(0, branchCollider.bounds.extents.y * 2), Random.Range(0, branchCollider.bounds.extents.z * 2));
        Debug.Log(genRandPoint);
        TreePopulators pInst = Instantiate(populator, branchCollider.bounds.min + genRandPoint, Random.rotation);
        pInst.gameObject.SetActive(true);
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
