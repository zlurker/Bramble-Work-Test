﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTree : MonoBehaviour {

    const float gameplayTime = 180;

    public Branch branch;
    public float branchGrowChance = 0.009f;
    public float minStumpLenBeforeGrowth = 10;
    public Transform camera;
    private List<Branch> branchCreated;
    // Use this for initialization

    void Start() {
        branchCreated = new List<Branch>();
    }

    // Update is called once per frame
    void Update() {

        // Stops any growth the moment its after 3 mins.
        if(gameplayTime < Time.time) {
            return;
        }

        GrowStump();

        if(transform.localScale.y >= minStumpLenBeforeGrowth)
            GrowBranches();
    }

    void GrowStump() {
        // Creates abit of randomness for stump growth.
        Vector3 currentScale = transform.localScale;
        currentScale.y += Random.value / 100;
        transform.localScale = currentScale;

        Vector3 camPos = camera.transform.position;
        camPos.y = currentScale.y;
        camera.position = camPos;
    }

    void GrowBranches() {
        // Random chance to grow new branches.
        if(Random.value < branchGrowChance) {
            // Get random placement within top 50% of branch
            float branchY = Random.Range(transform.localScale.y / 2, transform.localScale.y);
            Vector3 randomBranchPlacement = new Vector3(0, branchY, 0);
            Branch bInst = Instantiate(branch, randomBranchPlacement, Random.rotation);         
            bInst.transform.Translate(new Vector3(0, 0, 0));
            bInst.SetGrowthLimit(Random.Range(0, branchY));
            bInst.gameObject.SetActive(true);            
            branchCreated.Add(bInst);
        }
    }

    public void GrowPopulator(int item) {
        // Gets a random branch
        if(branchCreated.Count == 0)
            return;

        int index = Random.Range(0, branchCreated.Count);
        branchCreated[index].PopulateButtonClicked(item);

    }
}
