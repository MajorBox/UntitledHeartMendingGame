using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameManager.collectibleCount = gameManager.collectibleCount + 1;
            gameObject.SetActive(false);
        }
    }
}
