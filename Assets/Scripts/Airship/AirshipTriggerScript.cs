using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipTriggerScript : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject mainCam;

    public GameObject theAirship;
    public GameObject airshipCam;

    void OnTriggerEnter(Collider other)
    {
        airshipCam.SetActive(true);
        theAirship.SetActive(true);

        mainCam.SetActive(false);
        thePlayer.SetActive(false);
    
    }
}
