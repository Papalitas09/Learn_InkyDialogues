using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float maxDistanceRaycast = 2f;

    void Update()
    {
        InteractionPlayerHandler();
    }

    private void InteractionPlayerHandler()
    {
        RaycastHit _hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, maxDistanceRaycast))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.red);
            IInteractable IInteractableScript = _hit.collider.GetComponent<IInteractable>();
            if(IInteractableScript != null)
            {
                if(Input.GetKeyDown(KeyCode.E)) IInteractableScript.Interaction();
            }
        }
    }
}
