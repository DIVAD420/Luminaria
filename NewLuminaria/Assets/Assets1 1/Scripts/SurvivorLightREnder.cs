using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorLightREnder : MonoBehaviour
{
    public GameObject killerLightGO;
    public GameObject EnvironmentLightsGO;

    public Light killerLight;

    public float SlightIntensity;
    public float SlightRange;

    public Light[] EnvironmentLights;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killerLightGO = GameObject.Find("KillerLight");
        killerLight = killerLightGO.GetComponent<Light>();

        EnvironmentLightsGO = GameObject.Find("Lamps");
        EnvironmentLights = EnvironmentLightsGO.GetComponentsInChildren<Light>();
    }
    private void OnPreCull()
    {
        if (killerLight != null)
        {
            killerLight.enabled = false;
            for(int i = 0; i < EnvironmentLights.Length; i++)
            {
                EnvironmentLights[i].intensity = SlightIntensity;
                EnvironmentLights[i].range = SlightRange;
            }
        }  
    }
    private void OnPreRender()
    {
        if (killerLight != null)
        {
            killerLight.enabled = false;
            for (int i = 0; i < EnvironmentLights.Length; i++)
            {
                EnvironmentLights[i].intensity = SlightIntensity;
                EnvironmentLights[i].range = SlightRange;
            }
        }
    }
    private void OnPostRender()
    {
        if (killerLight != null)
        {
            killerLight.enabled = true;
            for (int i = 0; i < EnvironmentLights.Length; i++)
            {
                EnvironmentLights[i].intensity = 10;
                EnvironmentLights[i].range = 15;
            }
        }
    }
}
