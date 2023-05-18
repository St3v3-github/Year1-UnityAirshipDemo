using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour
{
    public CameraShake cameraShake;

    void Update()
    {
        StartCoroutine(cameraShake.Shake(.5f, .25f));
    }
}
