using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMon : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 1f;
    MonScript mon;
    IAMonScript monI;
    public SkinnedMeshRenderer[] hingeJoints;
    FaseCountScript faseCount;
    void Start()
    {
        mon = GetComponent<MonScript>();
        monI = GetComponent<IAMonScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        life = life + faseCount.AumlifeMon;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= -283f)
        {
            mon.onOffAux = false;
            mon.val = false;
            monI.onOffAux = false;
            monI.sh = false;
            transform.gameObject.tag = "dead";
            hingeJoints = GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer joint in hingeJoints)
                joint.enabled = false;
        }
    }
}
