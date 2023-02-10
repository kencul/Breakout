using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] GameObject BrickParticle;


    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
        Instantiate(BrickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}
