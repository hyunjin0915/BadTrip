using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConversationInput : MonoBehaviour
{
    [SerializeField] private DialogInput dialogInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogInput.gameObject.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Space)){
                dialogInput.SetDialogClickedFlag();
            }
        } 
    }
}
