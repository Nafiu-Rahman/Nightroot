// using StarterAssets;
// using UnityEngine;
// using UnityEngine.AI;
// using System.Collections.Generic;
// using UnityEngine.SceneManagement;
// using System.Collections;


// public class Robot : MonoBehaviour
// {
//     FirstPersonController player;
//     [SerializeField] float chaseRange = 5f;
//     [SerializeField] float turnSpeed = 5f;
//     NavMeshAgent agent;
//     float distanceToPlayer = Mathf.Infinity;

//     bool isProvoked = false;

//     void Awake()
//     {
//         agent = GetComponent<NavMeshAgent>();
//         agent.stoppingDistance = 2f;
//     }

//     void Start()
//     {

//         player = FindFirstObjectByType<FirstPersonController>();
//     }

//     void Update()
//     {
//         distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);//Distance(tareget position,our position)
//         if (isProvoked)
//         {
//             EngageTarget();
//         }
//         else if (distanceToPlayer <= chaseRange)
//         {
//             isProvoked = true;
//             ChasePlayer();
//         }
//     }

//     void ChasePlayer()
//     {

//         GetComponent<Animator>().SetBool("Attack", false);
//         GetComponent<Animator>().SetTrigger("Move");
//         agent.SetDestination(player.transform.position);
//     }

//     private void EngageTarget()
//     {
//         FaceTarget();
//         if (distanceToPlayer >= agent.stoppingDistance)
//         {
//             Debug.Log(distanceToPlayer+ " is greater than " + agent.stoppingDistance + ", chasing player.");
//             ChasePlayer();
//         }
//         else
//         {
//             AttackPlayer();
//         }
//     }

//     private void AttackPlayer()
//     {
//         // Implement attack logic here, e.g., play attack animation, deal damage, etc.
//         Debug.Log("Attacking Player!");
//         GetComponent<Animator>().SetBool("Attack", true);

//         float distance = Vector3.Distance(transform.position, player.transform.position);
//         if (distance <= 5f) // 0.5f means "almost touching"
//         {
//             GetComponent<DeathHandler>()?.HandleDeath();
//         }
//     }

//     private void FaceTarget()
//     {
//         //transform.rotation = where the target is, we need to rotate at a certain speed
//         //our rotation, target rotation, speed

//         Vector3 direction = (player.transform.position - transform.position).normalized;
//         Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//         transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);//Slerp = spherical linear interpolation
//     }
//     public void OnDamageTaken()
//     {
//         isProvoked = true;
//         // Handle damage taken by the robot, e.g., play a hit animation, reduce health, etc.
//         Debug.Log("Robot took damage!");
//         // You can also add logic to check if the robot should be destroyed or disabled.
//     }
// }

using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] AudioClip screamClip; // Assign "Scary Demon Scream Sound!.mp3" here
    NavMeshAgent agent;
    AudioSource audioSource;
    float distanceToPlayer = Mathf.Infinity;

    bool isProvoked = false;
    bool hasScreamed = false; // ensures scream happens only once

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2f;

        // Prepare audio
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; // 0 = 2D sound, 1 = fully 3D
    }

    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            isProvoked = true;

            // Scream when engaging player for the first time
            if (!hasScreamed && screamClip != null)
            {
                audioSource.clip = screamClip;
                audioSource.Play();
                hasScreamed = true;
            }

            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        agent.SetDestination(player.transform.position);
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToPlayer >= agent.stoppingDistance)
        {
            Debug.Log(distanceToPlayer + " is greater than " + agent.stoppingDistance + ", chasing player.");
            ChasePlayer();
        }
        else
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Attacking Player!");
        GetComponent<Animator>().SetBool("Attack", true);

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 5f)
        {
            GetComponent<DeathHandler>()?.HandleDeath();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
        Debug.Log("Robot took damage!");
    }
}
