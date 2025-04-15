using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnomaliCase : Enemy
{
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    public override void DetectPlayer()
    {
        base.DetectPlayer();
        Agent.SetDestination(Player.position);
    }


}
