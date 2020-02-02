using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameManager gameManager;
    public BoxCollider2D box_collider;
    public GameObject PS_Kokoro;
    public Transform GO_Transf;


    void Start()
    {
        box_collider = GetComponent<BoxCollider2D>();
        GO_Transf = gameObject.GetComponent<Transform>();
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
            Instantiate(PS_Kokoro,GO_Transf);
            gameObject.SetActive(false);


        }
    }
}
