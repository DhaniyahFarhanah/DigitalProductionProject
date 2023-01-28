using System.Collections;

using UnityEngine;

public class combinationpuzzle : MonoBehaviour
{
    public static string correctCombi = "1942";
    //not manipulating as numbers that are used operationally (+ - * /)

    public static string playerCode = "";

    public static int totalDigits = 0;
    
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(totalDigits == 4) {
            if (playerCode == correctCombi)
            {
                Debug.Log("Yay");
            }
            else
            {
                playerCode = "";
                totalDigits = 0;
                Debug.Log("lol try again");
            }
        }
    }

    void OnMouseDown()
    {
        playerCode += gameObject.name;
        totalDigits += 1;
    }
}
