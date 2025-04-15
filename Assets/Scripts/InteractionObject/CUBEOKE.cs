using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUBEOKE : MonoBehaviour, IInteractable
{
    private int shootCount = 0;

    void IInteractable.Interaction()
    {
        shootCount++;
        Debug.Log(" <Color=yellow>Shoot : </color> " + shootCount);
        if (shootCount == 200) Destroy(gameObject);
    }

    string IInteractable.Response()
    {
        return "mantap";
    }
}
