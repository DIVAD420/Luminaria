using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorDetectionScript : MonoBehaviour
{
    public float detectionRadius;

    public LayerMask whatIsKiller;

    public bool isThereKiller = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isThereKiller = Physics.CheckSphere(transform.position, detectionRadius, whatIsKiller);

        if (isThereKiller)
        {
            gameObject.layer = LayerMask.NameToLayer("IsDetected");
            foreach (Transform child in transform)
            {
                child.gameObject.layer = LayerMask.NameToLayer("IsDetected");
            }
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("IsNotDetected");
            foreach (Transform child in transform)
            {
                child.gameObject.layer = LayerMask.NameToLayer("IsNotDetected");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
