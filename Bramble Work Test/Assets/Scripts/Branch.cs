using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {

    public TreePopulators[] clickedTreePopulators;
    public TreePopulators[] autoSpawnedPopulators;

    public float autoSpawnGrowthChance = 0.05f;
    public Collider branchCollider;
    private float growthLimit;

    public void SetGrowthLimit(float gL) {
        growthLimit = gL;
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

    void GenerateAutospawn() {
        for(int i = 0; i < autoSpawnedPopulators.Length; i++) {
            Debug.Log("Autospawn working");
            if(Random.value < autoSpawnGrowthChance) {
                Vector3 randPoint = GetRandomPositionOnBranch();
                TreePopulators pInst = Instantiate(autoSpawnedPopulators[i], randPoint, Quaternion.identity);
                pInst.gameObject.SetActive(true);
            }
        }
    }

    Vector3 GetRandomPositionOnBranch() {
        Vector3 maxMinDiff = branchCollider.bounds.max - branchCollider.bounds.min;
        Vector3 genRandPoint = new Vector3(Random.Range(0,maxMinDiff.x),Random.Range(0, maxMinDiff.y), Random.Range(0, maxMinDiff.z));
        return branchCollider.bounds.min + genRandPoint;
    }


}
