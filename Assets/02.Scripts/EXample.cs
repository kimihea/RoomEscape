using OVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXample : MonoBehaviour
{
    // Start is called before the first frame update
    public Object locker;
    void Start()
    {
        locker = GetComponent<Object>();
        SoundFX fx = new SoundFX();
        AudioClip adb = fx.GetClip(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
