using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple")) 
        {
            gameManager.AddScore(1);
        } 
    }
}
