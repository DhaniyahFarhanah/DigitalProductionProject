using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateMove : MonoBehaviour
{
    //this is a shit ass way to do it but it works for now

    public Button[] gateArray;

    public Image image;

    bool finished = false;

    int count;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;

        foreach (var gate in gateArray)
        {
            if (gate.interactable == false)
            {
            count++;
            }
        }

        if(count == 11)
        {
            finished = true;
            Debug.Log("finished");
            image.CrossFadeAlpha(0, 0.5f, true);
        }
        else
        {
            finished = false;
            Debug.Log("not finished");
        }
        

    }

    
}
