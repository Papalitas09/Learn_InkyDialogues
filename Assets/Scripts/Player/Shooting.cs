using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Animator animator;
    private bool isShooting;
    private bool hasShot = false; // Track if we've already processed a shot

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        ShootingHandler();
        RaycastHandler();
    }

    private void ShootingHandler()
    {
        if (Input.GetMouseButtonDown(0) && !hasShot)
        {
            animator.SetTrigger("Shooting");
            isShooting = true;
            hasShot = true; // Mark that we've processed this click
            Debug.Log("<color=blue> isShooting TRUE</color>");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            hasShot = false; // Reset so we can shoot again on next click
            Debug.Log("<color=red> isShooting FALSE</color>");
        }
    }

    private void RaycastHandler()
    {
        if (!isShooting) return; // Skip if not shooting

        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, 2f))
        {
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.yellow);
            IInteractable _testing = _hit.collider.GetComponent<IInteractable>();
            if (_testing != null)
            {
                _testing.Interaction();
                isShooting = false; // Immediately stop shooting after one interaction
            }
        }

        // Reset shooting state immediately after checking
        isShooting = false;
    }
}