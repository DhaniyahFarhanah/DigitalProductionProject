using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    void Start()
    {
        //idk
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("You hab oepend the duur");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("u closd the duur");
        }
    }
}