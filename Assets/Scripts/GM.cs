using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 20;
    [SerializeField] float resetDelay = 1f;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject YouWon;
    [SerializeField] GameObject BricksPrefab;
    [SerializeField] GameObject Paddle;
    [SerializeField] GameObject DeathParticles;
    public static GM instance = null;


    GameObject ClonePaddle;


    // Start is called before the first frame update
    void Start()
    {
        //singleton instance
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        Setup();
    }

    public void Setup()
    {
        ClonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(BricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            YouWon.SetActive(true);
            SoundManager.instance.PlaySound("Win");
            SoundManager.instance.isPlaying = false;
            Time.timeScale = 0.25f;
            Invoke(nameof(Reset), resetDelay);
        }

        if (lives < 1)
        {
            GameOver.SetActive(true);
            SoundManager.instance.PlaySound("GameOver");
            SoundManager.instance.isPlaying = false;
            Time.timeScale = 0.25f;
            Invoke(nameof(Reset), resetDelay);
        }
    }

    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void LoseLife()
    {
        SoundManager.instance.PlaySound("LoseLife");
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(DeathParticles, ClonePaddle.transform.position, Quaternion.identity);
        Destroy(ClonePaddle);
        Invoke(nameof(SetupPaddle), resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        ClonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
