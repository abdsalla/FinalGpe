using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;  // GameManager creation

    public PlayerState playerState;
    public bool playerIsAlive; 
    public int lives;
    public float score;
    public List<Trampolines> trampolines;
    public List<Hazards> hazards;
    public List<Vector3> hSpawnPoints;
    public List<Vector3> tSpawnPoints;
    public Transform hPrefab;
    public Transform tPrefab;
    public Transform pPrefab;


    [HideInInspector]
    public Vector3 checkPoint;
    private int randint;


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
        {
            checkPoint.Set(-9, -3, 0);  // first checkpoint
            Instantiate(pPrefab, checkPoint, Quaternion.identity);   // Instanting the player
            playerIsAlive = true; 

        }
        
        // spawning traps and tramps
       foreach (Vector3 pos in hSpawnPoints)
        {
            Instantiate(hPrefab, pos, Quaternion.identity);
        }
        foreach (Vector3 pos in tSpawnPoints)
        {
            Instantiate(tPrefab, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (lives == 0)
        {
            OnGameOver(); // points to the gameover scene
        }

        if (playerIsAlive == false)
        {
            Instantiate(pPrefab, checkPoint, Quaternion.identity);
            playerIsAlive = true;
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
        Debug.Log("You Lose");
        SceneManager.LoadScene("GameOver");
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

    }

    public void DisablePainter()
    {

    }

    public enum PlayerState
    {
        PAINT,
        DEFAULT
    }
}
