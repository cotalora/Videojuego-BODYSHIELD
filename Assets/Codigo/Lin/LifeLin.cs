using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeLin : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeLin = 1f;
    public float forceLin = 10f;
    FaseCountScript countScript;
    LinScript lin;
    IALinScript linI;
    public SkinnedMeshRenderer[] hingeJoints;
    void Start()
    {
        lin = GetComponent<LinScript>();
        linI = GetComponent<IALinScript>();
        countScript = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        lifeLin = lifeLin + countScript.AumlifeLin;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeLin <= -281.5f)
        {
            lin.onOffAux = false;
            lin.val = false;
            linI.onOffAux = false;
            linI.sh = false;
            transform.gameObject.tag = "dead";
            hingeJoints = GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer joint in hingeJoints)
                joint.enabled = false;
        }
    }
}
