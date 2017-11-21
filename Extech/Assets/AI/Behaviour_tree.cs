using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript;



public class Behaviour_tree : MonoBehaviour
{



    public Node root;




    public void Start()
    {


        selector_node selector = new selector_node();

        root = selector;

        selector.children.Add(new patrol());
        sequenc_node sequenc = new sequenc_node();
        selector.children.Add(sequenc);
        sequenc.children.Add(new attack());
        sequenc.children.Add(new Chase());





    }
    // Use this for initialization
    public void Update()
    {
        root.Execute();

    }



}
