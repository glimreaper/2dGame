using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    public static GameControl instance;
    public GameObject gameOverText;
    public GameObject youWinText;
    public bool gameOver = false;
    public bool gameWon = false;
    public GameObject black;
    public GameObject megumin;
    private AudioSource audio;
    // Use this for initialization

    void Awake () {
        audio = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}

    void Start()
    {
        if (black.activeInHierarchy)
        { 
            black.SetActive(false);
        }
        if (megumin.activeInHierarchy)
        {
            megumin.SetActive(false);
        }
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(2);
        black.SetActive(true);
        megumin.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if (gameOver == true)
        {
            black.SetActive(false);
            audio.Stop();
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (Input.GetKeyDown("m"))
            {
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown("p"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            }
        }
        else if (gameWon == true)
        {
            black.SetActive(false);
            audio.Stop();
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (Input.GetKeyDown("m"))
            {
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown("n"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            else if (Input.GetKeyDown("p"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
	}


    public void characterFell()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void characterWon()
    {
        youWinText.SetActive(true);
        gameWon = true;
    }
}
