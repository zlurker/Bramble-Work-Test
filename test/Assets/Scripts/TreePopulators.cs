using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePopulators : MonoBehaviour {

    public float minSize;
    public float maxSize;

    private float determinedSize;

    // Use this for initialization
    void Start() {
        determinedSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(minSize, minSize, minSize);
    }

    // Update is called once per frame
    void Update() {
        if(transform.localScale.x < determinedSize)
            GrowPopulator();
    }

    void GrowPopulator() {
        Vector3 currentScale = transform.localScale + (Vector3.one * (Random.value / 100));
        transform.localScale = currentScale;
    }
}
