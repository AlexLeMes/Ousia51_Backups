using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
    /*
        TODO:
            
    */

    GameObject player;
    Transform pTrans;

    public Transform lookat;

    Vector3 playerPos;
    Vector3 gotoPos;
    //public float smoothing = 0.1f;
    //private Vector3 velocity = Vector3.zero;

    public bool moveTowardsPlayer = false;
    public float moveTowardsPlayerSpeed = 5f;

    float sensitivity = 5f;

    public Vector3 offset;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        pTrans = player.GetComponent<Transform>();
        transform.position = pTrans.transform.position + offset;
    }

    private void Update()
    {
        /*
        if (!moveTowardsPlayer)
        {
            Vector3.MoveTowards(transform.position, player.transform.position, moveTowardsPlayerSpeed * Time.deltaTime);
            transform.LookAt(pTrans.transform);
        }
        else if(moveTowardsPlayer)
        {
            transform.position = pTrans.transform.position + offset;
            //transform.LookAt(pTrans.transform);
        }
        */

        /*
        float horizontal = Input.GetAxis("Mouse X") * sensitivity;
        pTrans.Rotate(0, horizontal, 0);
        */

    }

    
    private void LateUpdate()
    {
        float direction = pTrans.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, direction, 0);

        transform.position = pTrans.transform.position + rotation * offset;
        transform.LookAt(lookat);
    }     
    
}
