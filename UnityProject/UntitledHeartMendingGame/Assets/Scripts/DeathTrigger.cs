using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameManager.completed = true;
        }
    }
}