using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractVFX : MonoBehaviour
{
    public ParticleSystem ps;

    public void StartVFX()
    {
        ps.Play();
        //s[0].gameObject.SetActive(true);
    }

    public void SetPos(float vec)
    {
        ps.transform.localPosition = new Vector3(0, vec, 0);
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
