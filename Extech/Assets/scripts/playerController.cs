using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    /*
    TODO:
        - set the player to only be able to move when
        the mouse position is a certain distance away from the player
*/
    // character _character;

    //PLAYER MOVE SPEED
    public float moveSpeed = 5f;
    //public float rotateSpeed = 90f;
    public float boostSpeed = 3f;
    float maxSpeed = 10f;
    float currentSpeed = 0f;

    //public Slider healthBar;
    public Slider staminaBar;

    cameraController _camera;
    public GameObject camera;

    float stamnia = 1f;
    public float maxStam = 100f;

    float stamRegenAmount = 5f;
    float stamUsageAamount = 35f;

    float stamStopAmount = 5f;
    float stamCanBeUsedAmount = 1f;

    bool canMove = true;
    bool moving = false;
    bool canBoost = true;
    bool boosting = true;
    //private pickups pickup;

    private void Awake()
    {
        _camera = camera.GetComponent<cameraController>();
    }

    private new void Start()
    {
        stamnia = maxStam;
        staminaBar.maxValue = maxStam;
        staminaBar.value = stamnia;

        currentSpeed = moveSpeed;

        stamCanBeUsedAmount = maxStam / 2;
        //player can re-sprint when stamina is half their max stamina
    }

    void Update()
    {

        Debug.DrawRay(transform.position, camera.transform.position, Color.green);

        if ((Vector3.Distance(transform.position, camera.transform.position) > 11) || (!Physics.Raycast(transform.position, camera.transform.position)))
        {
            _camera.moveTowardsPlayer = true;
        }
        else
        {
            _camera.moveTowardsPlayer = false;
        }

        /*
        if (!Physics.Raycast(transform.position, camera.transform.position))
        {
            _camera.moveTowardsPlayer = true;
        }
        else
        {
            _camera.moveTowardsPlayer = false;
        }
        */
        //Debug.Log(!Physics.Raycast(transform.position, camera.transform.position));


        //PLAYER KEY INPUT MOVEMENT//
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && canBoost)
        {

            currentSpeed += boostSpeed;

            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

            stamnia -= stamUsageAamount * Time.deltaTime;

            staminaBar.value = stamnia;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = moveSpeed;
        }

        if (stamnia < maxStam)
        {
            canMove = false;
            stamnia += stamRegenAmount * Time.deltaTime;
        }

        if (stamnia <= stamStopAmount)
        {
            canBoost = false;
            currentSpeed = moveSpeed;
        }
        else if (stamnia >= stamCanBeUsedAmount)
        {
            canBoost = true;
        }

        staminaBar.value = stamnia;
    }

}
