using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEos : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 1f;
    public float force = 19.5f;
    EosScript eos;
    IAEosScript eosI;
    FaseCountScript faseCount;
    public SkinnedMeshRenderer[] hingeJoints;
    void Start()
    {
        eos = GetComponent<EosScript>();
        eosI = GetComponent<IAEosScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        life = life + faseCount.AumlifeEos;
        force = force + faseCount.AumforceEos;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= -281f)
        {
            eos.onOffAux = false;
            eos.val = false;
            eosI.onOffAux = false;
            eosI.sh = false;
            transform.gameObject.tag = "dead";
            hingeJoints = GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer joint in hingeJoints)
                joint.enabled = false;
        }
    }
}
