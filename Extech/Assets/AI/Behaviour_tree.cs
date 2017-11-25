using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Behaviour_tree : MonoBehaviour
{

    //TODO : REMOVE ALL MAGIC NUMBERS!

    public Node root;
    public GameObject player;
    public GameObject[] waypoints;
    public int target;
    public float speed;
    public bool playerspotted;
    public bool canmove;
    public float maxdistance = 10f;
    public bool waypoint;
    public float angle;
    public float vision = 30f;
    public RaycastHit hit;
    public character pct;
    public character ect;
    public float Maxvel = 1;
    public Vector3 Currvel;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pct = player.GetComponent<character>();
        ect = GetComponent<character>();

        target = 0;

        selector_node selector = new selector_node();

        root = selector;

        sequenc_node sequenc = new sequenc_node();
        selector.children.Add(sequenc);
        sequenc.children.Add(new Chase());
        sequenc.children.Add(new attack());
        selector.children.Add(new flee());
        selector.children.Add(new patrol());
        selector.children.Add(new idle());

        root.BT = this;

        root.Start();
    }
    // Use this for initialization
    public void Update()
    {
        root.Execute();
    }
    void OnDrawGizmos()
    {
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, maxdistance);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, vision);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, angle);

        }

    }



}
