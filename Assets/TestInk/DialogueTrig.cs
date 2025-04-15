using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrig : MonoBehaviour, IInteractable
{
    public TextAsset InkJson;

    public void Interaction()
    {
        DialogueManag.GetInstance().DisplayDialogue(InkJson);
    }

    public string Response()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
