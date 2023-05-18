using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnPScript : MonoBehaviour
{
    public GameObject pnpCam;

    void OnTriggerEnter(Collider other)
    {
        pnpCam.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        pnpCam.SetActive(false);
    }

}