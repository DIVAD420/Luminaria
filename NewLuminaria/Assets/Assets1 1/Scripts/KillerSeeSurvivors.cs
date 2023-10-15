using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerSeeSurvivors : MonoBehaviour
{
    public float rangeRadius;
    public LayerMask whatIsSurvivor;

    public Collider[] SurvivorsInRange;

    public GameObject[] allSurvivors;

    // Start is called before the first frame update
    void Start()
    {
        allSurvivors = GameObject.FindGameObjectsWithTag("Survivor");
    }

    // Update is called once per frame
    void Update()
    {
        SurvivorsInRange = Physics.OverlapSphere(transform.position, rangeRadius, whatIsSurvivor);
        for (int i = 0; i < SurvivorsInRange.Length; i++)
        {
            SurvivorsInRange[i].enabled = true;
        }

    }
    private void OnPreCull()
    {
        if(allSurvivors != null) 
        {
            for (int i = 0; i < allSurvivors.Length; i++)
            {
                allSurvivors[i].SetActive(false);
            }
        }
    }
    private void OnPreRender()
    {
        if (allSurvivors != null)
        {
            for (int i = 0; i < allSurvivors.Length; i++)
            {
                allSurvivors[i].SetActive(false);
            }
        }
    }
    private void OnPostRender()
    {
        if (allSurvivors != null)
        {
            for (int i = 0; i < allSurvivors.Length; i++)
            {
                allSurvivors[i].SetActive(true);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }
}
