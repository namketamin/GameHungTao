using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private GameManager gameManager;
    bool gameOver = false;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void SpawnObject()
    {
        Instantiate(prefab, new Vector3(Random.Range(-10f, 10f), 8f, 0f), Quaternion.identity);
    }
    public void OnCollisionEnter2D(Collision2D collision)
       {
        if (collision.gameObject.CompareTag("Player") && !gameOver)
        {
            SpawnObject();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            gameManager.GameOver();
            gameOver = true;
        }
    }
}
