using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : Node
{

    Vector3 lookatPos;

    public override void Execute()
    {
        state = Node_State.running;

        if (BT.waypoint)
        {
            BT.transform.position = Vector3.MoveTowards(BT.transform.position, BT.waypoints[BT.target].transform.position, BT.speed * Time.deltaTime);
            lookatPos = new Vector3(BT.waypoints[BT.target].transform.position.x, BT.transform.position.y, BT.waypoints[BT.target].transform.position.z);
            BT.transform.LookAt(lookatPos);

            if (Vector3.Distance(BT.transform.position, BT.waypoints[BT.target].transform.position) < 3f)
            {
                
                BT.target++;

                if (BT.target == BT.waypoints.Length)
                {

                    Debug.Log("patrol" + state);
                    BT.target = 0;
                }
            }
            else
            {
                state = Node_State.faliure;
            }

        }

    }
}
