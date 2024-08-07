using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConversationInput : MonoBehaviour
{
    [SerializeField] private DialogInput dialogInput;
    [SerializeField] private DialogInput dialogInputWhite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogInput.gameObject.activeSelf)
            {
                dialogInput.SetDialogClickedFlag();
                Debug.Log("스페이스바");
            } else if (dialogInputWhite.gameObject.activeSelf)
            {
                dialogInputWhite.SetDialogClickedFlag();
            }
        }
    }
}
