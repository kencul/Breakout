using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermittenSounds : MonoBehaviour
{
    [SerializeField] float minTime, maxTime;
    [SerializeField] AudioClip[] Clips;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForRandom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForRandom()
    {
        yield return new WaitForSeconds(Random.Range(minTime,maxTime));
        SoundManager.instance.PlaySound("Wall");
        StartCoroutine(WaitForRandom());
    }
}
