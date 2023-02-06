using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D playerRB;
    public GameObject dialogueBox;
    public PlayerManager PManager;

    public float charSpeed;
    public float dirX;
    public float input;


    public Sprite idle;
    public Sprite walking;
    public Sprite closedEyes;
    public Sprite breath;
    public Sprite crouch;

    public PlayerWalkState walkState = new PlayerWalkState();
    public PlayerCrouchState crouchState = new PlayerCrouchState();
    public PlayerHoldBreathState breathState = new PlayerHoldBreathState();
    public PlayerEyesState eyesState = new PlayerEyesState();
    public PlayerIdleState idleState = new PlayerIdleState();

    internal PlayerBaseState yeetState;
    internal PlayerBaseState twerkState;
    internal PlayerBaseState killState;

    public Image timerBar;
    public float maxTime = 1f;
    float remainingTime;

    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
        timerBar = GetComponentInChildren<Image>();
        timerBar.enabled = false;
        remainingTime = maxTime;
        //PManager.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            charSpeed = 0f;
    
        }

        else
        {
            input = Input.GetAxisRaw("Horizontal");

            if (input < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (input > 0)
            {
                spriteRenderer.flipX = false;
            }
            currentState.UpdateState(this);

        }

    }

    void FixedUpdate() //set to run 50 frames per second
    {
        playerRB.velocity = new Vector2(input * charSpeed, playerRB.velocity.y);

    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;

        switch (currentState)
        {
                case PlayerWalkState:
                spriteRenderer.sprite = walking;
                charSpeed = 6f;
                break;

                case PlayerCrouchState:
                spriteRenderer.sprite = crouch;
                charSpeed = 3f;
                break;

                case PlayerHoldBreathState:
                spriteRenderer.sprite = breath;
                charSpeed = 2f;

                if (remainingTime > 0 && Input.GetKeyDown(KeyCode.X))
                {
                    timerBar.enabled = true;
                    remainingTime -= Time.deltaTime;
                    timerBar.fillAmount = remainingTime / maxTime;
                }

                else if (remainingTime > 0 && Input.GetKeyUp(KeyCode.X))
                {
                    timerBar.enabled = false;
                    Time.timeScale = 0;
                }

                else if (remainingTime == 0 && Input.GetKeyDown(KeyCode.X))
                {
                    timerBar.enabled = false;
                    PManager.gameOverScreen.SetActive(true);
                    Time.timeScale = 0;
                }

                break;

                case PlayerEyesState:
                spriteRenderer.sprite = closedEyes;
                charSpeed = 1f;
                break;

                case PlayerIdleState:
                spriteRenderer.sprite = idle;
                charSpeed = 0f;
                break;
               

        }

        state.EnterState(this);
    }
}
