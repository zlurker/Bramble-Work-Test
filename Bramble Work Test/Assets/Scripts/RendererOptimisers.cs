using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererOptimisers : MonoBehaviour {

    public int maximumRenders = 25;
    public static RendererOptimisers inst;

    public int currentRenders;
    public List<LineRendererTest> toBeRendered = new List<LineRendererTest>();


    // Use this for initialization
    void Start() {
        inst = this;
    }

    public void AddRenderer(LineRendererTest inst) {
        toBeRendered.Add(inst);
        ActivateRender();
    }

    public void EndRender() {
        currentRenders--;
        ActivateRender();
    }

    public void ActivateRender() {
        if(currentRenders < maximumRenders)
            if(toBeRendered.Count > 0) {
                int randomIndex = Random.Range(0, toBeRendered.Count);
                toBeRendered[randomIndex].gameObject.SetActive(true);
                toBeRendered.RemoveAt(randomIndex);
                currentRenders++;
            }
    }

    // Update is called once per frame
    void Update() {

    }
}
