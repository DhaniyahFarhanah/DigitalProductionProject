using UnityEngine;
using System.Collections;
//using System.Collections.Generic;


public class states : MonoBehaviour
{
    //define player states 0 to x

    public enum playerState
    {
        idle,
        holdbreath,
        eyesclosed,
        earscovered

    }

    public playerState currentState;

    //define reference time variable

    private float lastStateChange = 0.0f;

    void setCurrentState(playerState state)
    {
        currentState = state;
        lastStateChange = Time.time;
    }

    //for initialisation
    void Start()
    {
        setCurrentState(playerState.idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentState)
        {
            case playerState.idle:
            break;

            case playerState.holdbreath:
            break;

            case playerState.eyesclosed:
            break;

            case playerState.earscovered:
            break;
        }
    }
}
