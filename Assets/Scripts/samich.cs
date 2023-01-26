using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class samich : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject Z;
    public TMP_Text dialogueText;

    public string[] dialogue;
    private int index;


    public float wordSpeed;
    public bool playerIsClose;
    public bool start = true;

    public float speed = 1.2f; 

    public float range = 1; 

    float startingY; 

    int direction = 1;

    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && start == true)
        {
            Debug.Log("Interact");

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }

            else
            {
                start = false;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        else if (Input.GetKeyDown(KeyCode.E) && start == false)
        {
            NextLine();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime * direction); //for the enemy to start moving 

        if (transform.position.y < startingY || transform.position.y > startingY + range) //if enemy moved to the point outside range, flip it and it goes in the other direction
        {
            direction *= -1; //flip
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        start = true;
        dialoguePanel.SetActive(false);

    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            playerIsClose = true;
            Z.SetActive(true);
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            playerIsClose = false;
            Debug.Log("Player is out of range");
            Z.SetActive(false);
            zeroText();
        }
    }

}
