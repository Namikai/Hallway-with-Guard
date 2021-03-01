using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    [SerializeField]
    public Transform[] points;

    public GameObject player;

    public float MobDistanceRun = 4.0f;
    
    private NavMeshAgent Mob;

    private int destPoint = 0;

    [SerializeField]
    private float minRemainingDistance = 0.5f;
    private AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        audioData.Pause();
        Mob = GetComponent<NavMeshAgent>();
        Mob.autoBraking = false;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            Debug.LogError("You must setup at least one destination point");
            enabled = false;
            return;
        }

        Mob.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < MobDistanceRun)
        {
            audioData.UnPause();
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            Mob.SetDestination(newPos);
        }

        if (!Mob.pathPending && Mob.remainingDistance < minRemainingDistance)
        {
            
            audioData.Pause();
            GotoNextPoint();
        }
    }
}
