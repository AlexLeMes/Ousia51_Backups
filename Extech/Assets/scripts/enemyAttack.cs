using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour {

    GameObject _player;

    public float damage = 1f;

    public float viewDistance = 25f;
    float attackDistance = 5f;

    bool playerSeen = false;
    float distanceToPlayer;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, viewDistance);

        if (hitColliders.Equals(_player))
        {
            Debug.DrawRay(transform.position, _player.transform.position, Color.red);

            if (Physics.Raycast(transform.position, _player.transform.position))
            {
                Debug.Log("enemySeesPlayer");
                playerSeen = true;
            }
            else
            {
                Debug.Log("enemyDoesntSeePlayer");
                playerSeen = false;
            }
        }
    }

    public void attack()
    {
        Debug.Log("attack");
        Debug.Log("damageToDeal = " + damage);
    }

}
