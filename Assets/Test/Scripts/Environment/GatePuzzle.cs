using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class GatePuzzle : MonoBehaviour
{


    public KeyCode key;

    public Button _button;

    // Start is called before the first frame update
    void Awake()
    {
        _button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {

        }
    }


    public void Cut()
    {
        _button.interactable = false;
    }
}
