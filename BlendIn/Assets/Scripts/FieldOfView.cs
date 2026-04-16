using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour

// followed tutorial from Comp-3 Interactive [https://www.youtube.com/watch?v=j1-OyLo77ss]
{
   
    // radius and angle for bear FOV
    public float viewRadius;
    public float viewAngle;

    // player object that bear is chasing
    public GameObject playerReference;

    // is the target on the mask?
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    // is the player in sight?
    public bool playerInSight;

    private void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        // decrease frequency of the FOV check to increase performance
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                // if the bear can see the player
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                
                    playerInSight = true;

                else
                    playerInSight = false;

            }
          
            else
            // player is not in sight
                playerInSight = false;
            
            
        }
        else if (playerInSight) // no longer in enemy's FOV
            playerInSight = false;
        

    }

}
