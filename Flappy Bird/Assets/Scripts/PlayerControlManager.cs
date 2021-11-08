using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControlManager : MonoBehaviour
{
    public AudioSource coinsound, failsound;
    public GameObject finalPanel, column;
    public bool Death; // default is false.
    Rigidbody2D playerrigidbody; //We use because of accessing the feature.
    public float speed = 1.6f;
    int Score,highscore;
    public Text scoreText, highscoretext, finishscore;
    void Start()
    {
        Time.timeScale = 1; // We start this game.
        Death = false;
        Score = 0;
        scoreText.text = "00";
        playerrigidbody = GetComponent<Rigidbody2D>(); // We access the gameobject's feature rigidbody.
        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("HighScore")) // I want to keep high score.
        {
            finishscore.text = PlayerPrefs.GetInt("Score").ToString();
            highscoretext.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //We  only click the mause.
            playerrigidbody.velocity = Vector2.up * speed; //We access the rigidbody's feature velocity.Vector2.up is meaning axis y.
                                                           //We multiply speed so bird has a velocity direction y(up).
    }
    private void OnTriggerEnter2D(Collider2D collision) // We use Ontrigger because coin's feature "istrigger" is active.
    {
        if (collision.gameObject.name == "Coin") //If any game object name is coin
        {
            coinsound.Play(); // Play the win coin sound.
            Destroy(GameObject.Find("Coin"));
            Score++; // if we collect to coins, score increases.

            if (Score < 10) // If we wanna create clear designed we can use it. It's meaning 01-02-...-09
                scoreText.text = "0" + Score.ToString();

            else
                scoreText.text = Score.ToString();

            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.Save();

            if (Score > PlayerPrefs.GetInt("HighScore"))
            {
                highscore = Score;
                highscoretext.text = highscore.ToString();
                PlayerPrefs.SetInt("HighScore", highscore);
                PlayerPrefs.Save();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) /* We use OnCollision because bird has rigidbody and
                                                           other object feature "istrigger" is passive. */
    {
        if (collision.gameObject.tag == "barrier") // If any gameobject have a tag "barrier"
        {
            failsound.Play();
            Death = true;
            Time.timeScale = 0; // It's meaning stop the game. We can use for time.
            finalPanel.SetActive(true);
            finishscore.text = Score.ToString();
        }
    }
}
