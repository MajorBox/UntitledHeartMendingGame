using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(gameManager.collectibleCount <= 2)
            {
                AudioManager.Instance.PlayCollectible();
            }
            else
            {
                AudioManager.Instance.PlayVictory();
            }
            
            gameManager.collectibleCount = gameManager.collectibleCount + 1;
            gameObject.SetActive(false);
        }
    }
}
