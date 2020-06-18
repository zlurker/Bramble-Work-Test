using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTest : MonoBehaviour {

    public LineRendererTest clone;
    public Vector3[] pos;
    public float minRateOfGrowth = 0.01f;
    public float maxRateOfGrowth = 0.1f;
    public float minGrowth = 10;
    public float maxGrowth = 40;
    public float currGrowth;
    public int minBranching =2;
    public int maxBranching =4;

    public float growthLen = 5;
    private Vector3 normalised;
    private LineRenderer l;

    void Start() {

        growthLen = Random.Range(minGrowth, maxGrowth);
        SetPos(pos);
        l = GetComponent<LineRenderer>();
        l.startWidth = 1f;
        l.useWorldSpace = true;
    }

    void SetPos(Vector3[] p) {
        currGrowth = 0;
        pos = p;
        normalised = pos[1] - pos[0];
        normalised = normalised.normalized;
    }

    void SetLRPos() {
        l.SetPositions(pos);
    }

    void Update() {
        if (currGrowth > growthLen) {
            int randomBranches = Random.Range(minBranching, maxBranching);

            for (int i=0; i < randomBranches; i++) {
                LineRendererTest lInst = Instantiate(clone);
                Vector3 nextRandomPt = new Vector3(Random.Range(-0.75f, 0.75f), Random.Range(0f,1f),0);
                lInst.SetPos(new Vector3[] { pos[1], pos[1] + nextRandomPt });
                lInst.gameObject.SetActive(true);
            }

            enabled = false;
            return;
        }

        currGrowth += Random.Range(minRateOfGrowth, maxRateOfGrowth);// rateOfGrowth;
        Debug.Log(currGrowth);
        pos[1] = pos[0] + (normalised * currGrowth);
        SetLRPos();     
    }
}
