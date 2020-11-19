using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeNeu : MonoBehaviour
{
    // Start is called before the first frame update
    FaseCountScript faseCount;
    NeuScript neu;
    IANeuScript neuI;
    public float lifeNeu = 1f;
    public float forceNeu = 15f;
    public SkinnedMeshRenderer[] hingeJoints;
    void Start()
    {
        neu = GetComponent<NeuScript>();
        neuI = GetComponent<IANeuScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        lifeNeu = lifeNeu + faseCount.AumlifeNeu;
        forceNeu = forceNeu + faseCount.AumforceNeu;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeNeu <= -275.63f)
        {
            neu.onOffAux = false;
            neu.val = false;
            neuI.onOffAux = false;
            neuI.sh = false;
            transform.gameObject.tag = "dead";
            hingeJoints = GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer joint in hingeJoints)
                joint.enabled = false;
        }
    }
}
