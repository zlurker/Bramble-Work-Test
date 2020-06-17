using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePopulators : MonoBehaviour {

    public float minSize;
    public float maxSize;

    public bool spawnsOnAnyColliderSide;
    public bool randomiseRotation;
    public float determinedSize;

    // Use this for initialization
    void Start() {
        determinedSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(determinedSize, determinedSize, determinedSize);
        if(randomiseRotation)
            transform.rotation = Random.rotation;
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
