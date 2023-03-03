using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [SerializeField] float minPitch, maxPitch, minVol, maxVol;
    AudioSource BallSounds;
    [SerializeField] AudioClip paddleClip, GameOverClip, StartClip, LoseLifeClip, WinClip;
    [SerializeField] AudioClip[] wallClips, brickClips;

    [SerializeField] int LastIndex, CurrentIndex = 0;
    [SerializeField] int LastIndexWall, CurrentIndexWall = 0;

    public bool isPlaying = true;

    private void Awake()
    {
        //singleton instance
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        //caching components
        BallSounds = GetComponent<AudioSource>();
    }

    public void PlaySound (string sound)
    {
        if (isPlaying)
        {
            Debug.Log("PlayingSound");
            AudioClip Clip = null;

            //BallSounds.pitch = Random.Range(minPitch, maxPitch);

            switch (sound)
            {
                case "Wall":
                    Clip = wallClips[Random.Range(0, wallClips.Length)];
                    break;
                case "Paddle":
                    Clip = paddleClip;
                    break;
                case "Brick":
                    //randomize sound without repeating last sound
                    do
                        CurrentIndex = Random.Range(0, brickClips.Length);
                    while (LastIndex == CurrentIndex);
                    LastIndex = CurrentIndex;

                    Clip = brickClips[CurrentIndex];
                    break;
                case "GameOver":
                    Clip = GameOverClip;
                    break;
                case "Start":
                    Clip = StartClip;
                    break;
                case "LoseLife":
                    Clip = LoseLifeClip;
                    break;
                case "Win":
                    Clip = WinClip;
                    break;
                default:
                    break;
            }

            BallSounds.PlayOneShot(Clip, Random.Range(minVol, maxVol));
        }
    }

    //overload w/ pitch randomization
    public void PlaySound(string sound, float min, float max)
    {
        if (isPlaying)
        {
            Debug.Log("PlayingSound w/ random pitch");
            AudioClip Clip = null;

            BallSounds.pitch = Random.Range(min, max);

            switch (sound)
            {
                case "Wall":
                    Clip = wallClips[Random.Range(0, wallClips.Length)];
                    break;
                case "Paddle":
                    Clip = paddleClip;
                    break;
                case "Brick":
                    //randomize sound without repeating last sound
                    do
                        CurrentIndex = Random.Range(0, brickClips.Length);
                    while (LastIndex == CurrentIndex);
                    LastIndex = CurrentIndex;

                    Clip = brickClips[CurrentIndex];
                    break;
                case "GameOver":
                    Clip = GameOverClip;
                    break;
                case "Start":
                    Clip = StartClip;
                    break;
                case "LoseLife":
                    Clip = LoseLifeClip;
                    break;
                case "Win":
                    Clip = WinClip;
                    break;
                default:
                    break;
            }

            BallSounds.PlayOneShot(Clip, Random.Range(minVol, maxVol));
        }
    }
}
