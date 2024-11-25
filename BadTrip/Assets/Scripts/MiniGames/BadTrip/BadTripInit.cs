using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTripInit : MonoBehaviour
{
    [SerializeField]
    private MonsterHPSO Monster_healthManager;

    // Start is called before the first frame update
    void Start()
    {
        Monster_healthManager.MonsterHPInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
