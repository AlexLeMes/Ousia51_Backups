using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : Node
{

    public override void Execute()
    {
        state = Node_State.running;

        if (BT.waypoint)
        {
            BT.transform.position = Vector3.MoveTowards(BT.transform.position, BT.waypoints[BT.target].transform.position, BT.speed * Time.deltaTime);
            BT.transform.LookAt(BT.waypoints[BT.target].transform.position);

            if (Vector3.Distance(BT.transform.position, BT.waypoints[BT.target].transform.position) < 0.01)
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
