using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : Node
{

    public override void Execute()
    {
      
        if (Vector3.Distance(BT.transform.position, BT.player.transform.position) < 5f)
        {
            Debug.Log("attack"+state);
            state = Node_State.success;
            BT.pct.takeDamage(25f * Time.deltaTime);
            //attack animation here

        }
        else
        {
            state = Node_State.faliure;
        }

    }
}
