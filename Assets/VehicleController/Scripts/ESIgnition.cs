using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESIgnition : MonoBehaviour
{
    public enum Type
    {
        UserControl
    }
    public Type type = Type.UserControl;
    public bool On = true;
    public bool isplay = false;
    public KeyCode IngnitionKey = KeyCode.I;
    [HideInInspector]
    public ESVehicleController vehcilecontroller;
    public AudioSource StartSound, StopSound;

    private void Awake()
    {
        if (this.GetComponent<ESVehicleController>() != null)
        {
            vehcilecontroller = GetComponent<ESVehicleController>();
        }
       

    }

    private void Update()
    {
        IgnitionControl();
    }

    private void IgnitionControl()
    {
        switch (type)
        {
            case Type.UserControl:
                {
                    if (Input.GetKeyDown(IngnitionKey))
                    {
                        On = !On;
                    }
                    if (On)
                    {
                        if (!StartSound.isPlaying && !isplay)
                        {
                            StopSound.Stop();
                            //vehcilecontroller.GetComponent<ESGearShift>().isneutral = true;
                            vehcilecontroller.GetComponent<ESGearShift>().EngineRpm = 0;
                            StartSound.Play();
                            isplay = true;
                        }
                    }
                    if (!On)
                    {
                        StartSound.Stop();
                        if (isplay)
                        {
                            StopSound.Play();
                            isplay = false;
                        }
                    }
                    //svehcilecontroller.GetComponent<ESGearShift>().enabled = On;
                    if (vehcilecontroller.GetComponent<ESFuelManager>() != null)
                    {
                        vehcilecontroller.GetComponent<ESFuelManager>().enabled = On;
                    }
                    vehcilecontroller.GetComponent<AudioSource>().enabled = On;
                }
                break;
           
        }

    }
}
