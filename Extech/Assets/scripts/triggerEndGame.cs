using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEndGame : MonoBehaviour {

    public GameObject winMenu;

    private void Awake()
    {
        winMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameWon();
        }
    }

    public void gameWon()
    {
        winMenu.SetActive(true);

        // manager set time scale 0 here
    }

    public void gameLost()
    {
        //manager kill and respawn player here
    }
}
