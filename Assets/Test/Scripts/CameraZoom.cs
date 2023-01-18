using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    public GameObject player;

    bool zoomIn;

    [Range(1,5)]
    public float zoomSize;

    [Range(0.01f,0.1f)]
    public float zoomSpeed;


    void Start()
    {
        cam = Camera.main;
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void zoomCamera()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,zoomSize, zoomSpeed);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y +2, gameObject.transform.position.z);
    }
    void zoomOut()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,5,zoomSpeed);
    }
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            zoomCamera();
        }
        else
        {
            zoomOut();
        }

       
    }
}
