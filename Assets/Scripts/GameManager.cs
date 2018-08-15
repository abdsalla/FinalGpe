using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;  // GameManager creation


    public PlayerState playerState;
    public GameObject player;
    public bool playerIsAlive; 
    public int lives;
    public float score;
    public Text scoreText;
    public List<Trampolines> trampolines;
    public List<Hazards> hazards;
    public List<PowerUp> powerUps;
    public List<Goal> goal;
    public List<Vector3> hSpawnPoints;
    public List<Vector3> tSpawnPoints;
    public List<Vector3> pUSpawnPoints;
    public List<Vector3> gSpawnPoints;
    public GameObject hPrefab;
    public GameObject tPrefab;
    public GameObject pPrefab;
    public GameObject pUPrefab;
    public GameObject gPrefab;


    [HideInInspector]
    public Vector3 checkPoint;
    


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } 
    
   

	// Use this for initialization
	void Start () {
        //{

            score = 0;
            UpdateScore();
           // checkPoint.Set(4, -3, 0);
            checkPoint.Set(-9, -3, 0);  // first checkpoint
            Instantiate(pPrefab, checkPoint, Quaternion.identity);   // Instantiatng the player
            playerIsAlive = true;
            //player = GameObject.FindGameObjectWithTag("Player");
            this.player = GameObject.FindWithTag("Player");
       // }
        
        // spawning traps and tramps
       foreach (Vector3 pos in hSpawnPoints)
        {
            Instantiate(hPrefab, pos, Quaternion.identity);
        }
        foreach (Vector3 pos in tSpawnPoints)
        {
            Instantiate(tPrefab, pos, Quaternion.identity);
        }
        foreach (Vector3 pos in pUSpawnPoints)
        {
            Instantiate(pUPrefab, pos, Quaternion.identity);
        }
        foreach (Vector3 pos in gSpawnPoints)
        {
            Instantiate(gPrefab, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {

        this.scoreText = GameObject.Find("Score").GetComponent<Text>();


        if (lives == 0)
        {
            OnGameOver(); // points to the gameover scene
        }

        if (player == null) //playerIsAlive == null;
        {
            Instantiate(pPrefab, checkPoint, Quaternion.identity);
            this.player = GameObject.FindWithTag("Player");
            playerIsAlive = true;
            Instantiate(pUPrefab, pUSpawnPoints[0], Quaternion.identity);
            lives -= 1;
        }

        switch (playerState)
        {
            case PlayerState.DEFAULT:
                DisablePainter();
                break;
            case PlayerState.PAINT:
                EnablePainter();
                break;
            default:
                break;
        }
    }

    public void OnGameOver()
    {
        
        lives = 3;
        SceneManager.LoadScene(2);
        playerIsAlive = false;
        Restart();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnVictory()
    {
        SceneManager.LoadScene("Victory");
    }

    public void EnablePainter()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

        }
    }

    public void DisablePainter()
    {

    }

    public enum PlayerState
    {
        PAINT,
        DEFAULT
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void Restart()
    {
        foreach (Vector3 pos in hSpawnPoints)
        {
            Instantiate(hPrefab, pos, Quaternion.identity);
        }
        foreach (Vector3 pos in tSpawnPoints)
        {
            Instantiate(tPrefab, pos, Quaternion.identity);
        }
        foreach (Vector3 pos in gSpawnPoints)
        {
            Instantiate(gPrefab, pos, Quaternion.identity);
        }
    }
}
