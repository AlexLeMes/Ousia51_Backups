using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance = null;



    /*
        TODO:
            //SET-UP SINGLETON
    */

    int mainMenu = 0;
    public int mainLevel = 1;

    public GameObject console;
    
    //EDIT THESE WHEN MADE INSTANCE

    GameObject player;
    playerController _playerController;

    GameObject playerWeapon;
    weapon _weapon;

    public GameObject spawnPoint;
    Vector3 spawnLocation;

    bool isPaused = false;

    public GameObject pauseMenuObj;

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        
    }

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerController = player.GetComponent<playerController>();

        playerWeapon = GameObject.FindGameObjectWithTag("playerWeapon");
        _weapon = playerWeapon.GetComponent<weapon>();

        spawnLocation = spawnPoint.transform.position;

        console.SetActive(false);
        pauseMenuObj.SetActive(false);

        respawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("PAUSE_GAME");
            pauseGame();
        }


        if(Input.GetKeyDown(KeyCode.C))
        {
            console.SetActive(!console.activeSelf);
        }
    }

    public void respawn()
    {
        player.transform.position = spawnLocation;
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(mainLevel);
    }

    public void pauseGame()
    {
        if(Time.timeScale < 1)
        {
            Time.timeScale = 1;
            pauseMenuObj.SetActive(false);
        }
        else if(Time.timeScale >= 1)
        {
            Time.timeScale = 0;
            pauseMenuObj.SetActive(true);
        }

        if(pauseMenuObj.activeSelf)
        {
            _playerController.enabled = false;
            _weapon.enabled = false;
        }
        else
        {
            _playerController.enabled = true;
            _weapon.enabled = true;
        }

    }

    public void gotoMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    
    public void debugAddAmmo()
    {
        _weapon.gas += 250;
    }
    
}
