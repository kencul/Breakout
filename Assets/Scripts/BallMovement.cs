using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float initVel = 600f;
    Rigidbody rb;
    bool inPlay = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && inPlay == false)
        {
            SoundManager.instance.PlaySound("Start");
            transform.parent = null;
            inPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initVel, initVel, 0f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
            case "Paddle":
            case "Brick":
                SoundManager.instance.PlaySound(collision.gameObject.tag);
                break;
            default:
                break;
        }
    }
}
