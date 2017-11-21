using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Execute()
    {

        state = Node_State.success;
        Debug.Log("chase");


    }
}
