using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAirshipMove : MonoBehaviour
{
    public GameObject thePlayer;

    public bool throttle => Input.GetKey(KeyCode.W);
    public bool reverse => Input.GetKey(KeyCode.S);

    public float enginePower, turnPower, risePower;
    private float activeEngine, activeTurn, activeRise;

    private void Update()
    {
        if (thePlayer.active == false)
        {
            if (throttle)
            {
                transform.position += transform.forward * enginePower * Time.deltaTime;

                activeTurn = Input.GetAxisRaw("Turn") * turnPower * Time.deltaTime;
                transform.Rotate(0, activeTurn * turnPower * Time.deltaTime, 0, Space.Self);
            }
           
            else if (reverse)
            {
                transform.position -= transform.forward * enginePower * Time.deltaTime;

                activeTurn = Input.GetAxisRaw("Turn") * turnPower * Time.deltaTime;
                transform.Rotate(0, activeTurn * turnPower * Time.deltaTime, 0, Space.Self);
            }

            else
            {
                activeTurn = Input.GetAxisRaw("Turn") * turnPower * Time.deltaTime;
                transform.Rotate(0, activeTurn * turnPower * Time.deltaTime, 0, Space.Self);
            }


            if (Input.GetKey(KeyCode.UpArrow))
                transform.Translate(Vector3.up * risePower * Time.deltaTime);

            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(-Vector3.up * risePower * Time.deltaTime);
        }
    }
}
