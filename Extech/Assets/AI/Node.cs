using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Node_State { running, success, faliure };

public class Node
{
    public List<Node> children = new List<Node>();
    public bool init;
    public Node headnode;
    public object value;
    public Node_State state;
    public bool process;

    public virtual void Execute()
    {
        init = true;
        Debug.Log("I am  initialised");

    }





}









