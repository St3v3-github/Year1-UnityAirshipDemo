using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipController : MonoBehaviour
{
    public float forwardSpeed = 10f, turnSpeed = 5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeTurnSpeed, activeHoverSpeed;

    void update()
    {
        activeForwardSpeed = Input.GetAxis("Vertical") * forwardSpeed;
        activeTurnSpeed = Input.GetAxis("Turn") * turnSpeed;
        activeHoverSpeed = Input.GetAxis("Hover") * hoverSpeed;

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.right * activeTurnSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
    }
}