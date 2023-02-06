using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    public Sprite cutButtonImage;
    public Button button;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CutButton()
    {
        button.image.sprite = cutButtonImage;
    }
}
