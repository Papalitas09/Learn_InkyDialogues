using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject player_object;

    private void Start()
    {
        player = player_object.GetComponent<Transform>();
    }
    public virtual void DetectPlayer()
    {
        RaycastHit _hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, 2f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _hit.distance, Color.red);
            if (player != null) Debug.Log("mantap");
        }
    }
}
