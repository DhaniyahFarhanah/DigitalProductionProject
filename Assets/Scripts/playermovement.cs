using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour
{

    //define player states 0 to x
    public enum playerState
    {
        idle,
        walking,
        //eyesclosed,
        //earscover,
        //noseheld
    }

    public playerState currentState;

    //define reference time-variable
    private float lastStateChange = 0.0f;


    //define method for setting the state of playerState
    void setCurrentState(playerState state)
    {
        currentState = state;
        lastStateChange = Time.time;
    }


    // Use this for initialization
    void Start()
    {
        setCurrentState(playerState.idle); //call function to set state to idle
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentState)
        {
            case playerState.idle:
                //doidle();
                break;
            case playerState.walking:
                //dowalk();
                break;
            //case playerState.eyesclosed:
            //    //doeyes();
            //    break;
            //case playerState.earscover:
            //    //doears();
            //    break;
            //case playerState.noseheld:
            //    //doears();
            //    break;

        }

    }
}