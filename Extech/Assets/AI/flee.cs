using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flee : Node {

    public override void Execute()
    {
        if (BT.ect.characterOnFire == true)
        {
            state = Node_State.success;
            Debug.Log("fleeeeeee");
            BT.transform.position = Vector3.MoveTowards(BT.transform.position, -BT.player.transform.position, BT.speed * Time.deltaTime);
            BT.waypoint = false;
        }
        else
        {
           
            BT.ect.characterOnFire=false;
        }
        state = Node_State.faliure;

    }




}
