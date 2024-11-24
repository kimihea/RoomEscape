using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSKy : MonoBehaviour
{
    public Material dayMat;
    public Material nightMat;
    public GameObject dayLight;
    public GameObject nightLight;

    public Color dayFog;
    public Color nightFog;


    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }
    private void OnGUI()
    {
        if(GUI.Button(new Rect(5, 5, 80, 20), "Day"))
        {
            RenderSettings.skybox = dayMat;
            RenderSettings.fogColor = dayFog;
            dayLight.SetActive(true);
            nightLight.SetActive(false);

        }
        if (GUI.Button(new Rect(5, 30, 80, 20), "Kngiht"))
        {
            RenderSettings.skybox = nightMat;
            RenderSettings.fogColor = nightFog;
            dayLight.SetActive(false);
            nightLight.SetActive(true);

        }
    }
}
