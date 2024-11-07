using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain_Stupid : MonoBehaviour
{
    public Transform target;
    private EnemyReferences references;
    private float pathUpdateDeadline;
    private float buyDistance;

    private void Awake()
    {
        references = GetComponent<EnemyReferences>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        buyDistance = references.agent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= buyDistance;

            if (inRange)
            {
                LookAtTarget();
            } else
            {
                UpdatePath();
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath()
    {
       if (Time.time >= pathUpdateDeadline)
       {
           Debug.Log("Updating path");
           pathUpdateDeadline = Time.time + references.pathUpdateDelay;
           references.agent.SetDestination(target.position);
        }
    }
}
