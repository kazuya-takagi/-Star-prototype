using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2Script : MonoBehaviour
{

    public Material[] mat;// = new Material[5]
    public GameObject[] matObject;
    private int matIndex = 0;

    Rigidbody rigit;
    public Rigidbody gimmikObject;
   
    public bool gimState;

    void Start()
    {
        //gimmikObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gimState) {
            gimmikObject.isKinematic = false;
        }
        else if (!gimState) {
            gimmikObject.isKinematic = true;
        }

        if (gimmikObject.transform.position.y < -6f) {
            gimState = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        matIndex++;
        if (matIndex > 1) {
            matIndex = 0;
        }

        for (int i = 0; i < matObject.Length; i++) {
            matObject[i].GetComponent<Renderer>().material = mat[matIndex];
        }

        gimState = true;
    }
}
