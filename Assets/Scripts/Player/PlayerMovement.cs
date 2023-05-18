using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip shoutingClip;
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;

    private Animator anim;
    private HashIDs hash;

    private float elapsedTime = 0;
    private bool noBackMov = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        anim.SetLayerWeight(1, 1f);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");
        float turn = Input.GetAxis("Turn");
        Rotating(turn);
        MovementManagement(v, sneak);

        elapsedTime += Time.deltaTime;
    }

    void Update()
    {
        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingBool, shout);
        AudioManager(shout);
    }

    void MovementManagement(float vertical, bool sneaking)
    {
        anim.SetBool(hash.sneakingBool, sneaking);

        if (vertical > 0)
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", false);
            noBackMov = true;
        }

        if (vertical < 0)
        {
            if (noBackMov == true)
            {
                elapsedTime = 0;
                noBackMov = false;
            }

            anim.SetFloat(hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", true);

            Rigidbody ourBody = this.GetComponent<Rigidbody>();

            float movement = Mathf.Lerp(0f, -0.025f, elapsedTime);
            Vector3 moveBack = new Vector3(0.0f, 0.0f, movement);
            moveBack = ourBody.transform.TransformDirection(moveBack);
            ourBody.transform.position += moveBack;

        }

        if (vertical == 0)
        {
            anim.SetFloat(hash.speedFloat, 0.01f);
            anim.SetBool(hash.backwardsBool, false);
            noBackMov = true;
        }
    }

    void Rotating(float mouseXInput)
    {
        Rigidbody ourBody = this.GetComponent<Rigidbody>();
        if (mouseXInput != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);
        }
        ourBody.MoveRotation(ourBody.rotation * Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f));

    }

    void AudioManager(bool shout)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().pitch = 1;
                GetComponent<AudioSource>().Play();
            }
        }

        else
        {
            GetComponent<AudioSource>().Stop();
        }

        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        }
    }
}