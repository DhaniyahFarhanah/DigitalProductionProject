using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{

    public GameObject sensor;
    public GameObject player;
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D sensor)
    {
        if (sensor.CompareTag("Player"))
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D sensor)
    {
        if (sensor.CompareTag("Player"))
        {
            door.SetActive(true);
        }
    }
}
