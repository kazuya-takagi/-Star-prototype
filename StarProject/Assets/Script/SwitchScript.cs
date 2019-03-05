using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    public Material[] mat;// = new Material[5]
    public GameObject[] matObject;
    private int matIndex = 0;

    public GameObject gimmikObject;
    public GameObject trigger;
    public bool gimState;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gimState) {
            gimmikObject.transform.Translate(0, 0.1f, 0);
        }
        if (gimmikObject.transform.position.y > -9.5f) {
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
