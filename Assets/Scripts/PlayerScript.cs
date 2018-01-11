using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public float playerVelocity;
    private Vector3 playerPosition;
    public float boundary;
    private int playerLives;
    private int playerPoints;
    public AudioClip pointSound;
    public AudioClip lifeSound;

    // Use this for initialization
    void Start () {

        playerPosition = gameObject.transform.position;

        playerLives = 3;
        playerPoints = 0;

    }

    // Update is called once per frame
    void Update () {

        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
          //  Application.Quit();
        //}

        // update the game object transform
        transform.position = playerPosition;

        // boundaries
        if (playerPosition.x < -boundary)
        {
            transform.position = new Vector3(-boundary, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > boundary)
        {
            transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);
        }

        WinLose();

    }

    void addPoints(int points)
    {
        var audio = GetComponent<AudioSource>();
        playerPoints += points;
        audio.PlayOneShot(pointSound);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 3.0f, 200.0f, 200.0f), "Live's: " + playerLives + "  Score: " + playerPoints);
    }

    void TakeLife()
    {
        var audio = GetComponent<AudioSource>();
        playerLives--;
        audio.PlayOneShot(lifeSound);
    }

    void WinLose()
    {
        //SceneManager.LoadScene("Level1");
        
            // restart level
            if (playerLives == 0)
            {

                SceneManager.LoadScene("Two");
            }

            // all block destroyed
            if ((GameObject.FindGameObjectsWithTag("Block")).Length == 0)
            {
                SceneManager.LoadScene("Level2");
            }
            else
            {
                Application.Quit();
            }
        
    }
}
