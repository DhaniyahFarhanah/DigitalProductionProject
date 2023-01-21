using UnityEngine;

public class playercollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ghost")
        {
            PlayerManager.isGameOver = true;
        }
    }
} 