using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBao : MonoBehaviour
{
    // Start is called before the first frame update
    FaseCountScript faseCount;
    BaoScript bao;
    IABaoScript baoS;
    public float lifeBao = 1f;
    public SkinnedMeshRenderer[] hingeJoints;
    void Start()
    {
        bao = GetComponent<BaoScript>();
        baoS = GetComponent<IABaoScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        lifeBao = lifeBao + faseCount.AumlifeBao;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeBao <= -281f)
        {
            bao.onOffAux = false;
            baoS.onOffAux = false;
            baoS.sh = false;
            transform.gameObject.tag = "dead";
            hingeJoints = GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer joint in hingeJoints)
                joint.enabled = false;
        }
    }
}
