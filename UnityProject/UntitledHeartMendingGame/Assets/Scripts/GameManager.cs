using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool started;
    public float countdown; //contador inicial 
    public float timerCount; //contador de 20 segundos
    public bool completed;
    public Text timerText;
    public Text countdownText;
    private IEnumerator coroutine;

    public int collectibleCount;

    private void Start()
    {
        countdown = 3;
        timerCount = 20;
        started = false;
        completed = false;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        
        if (countdown <= 0)
        {
            if(countdown >= -1)
            {
                countdownText.text = "GO";
            }
            else
            {
                countdownText.text = "";
            }

            started = true;
        }
        else
        {
            countdownText.text = countdown.ToString("f0");
        }

        if (started)
        {
            if (timerCount <= 0)
            {
                //gameOver
                timerText.text = "0.00";
                completed = true;
            }
            else
            {
                timerCount -= Time.deltaTime;
                timerText.text = timerCount.ToString("f2");
            }
        }
    }
}
