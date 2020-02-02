using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;   
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool started;
    public float countdown; //contador inicial 
    public float timerCount; //contador de 20 segundos
    public bool completed;
    public Text timerText;
    public Text countdownText;
    public int lost = 0; 

    public bool victorySound;
    public List<Sprite> Sprites;
    public Image heart;

    public int collectibleCount;

    private void Start()
    {
        countdown = 3;
        timerCount = 20;
        started = false;
        completed = false;
        victorySound = false;
    }

    public void LoseLevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel 1 - Negacion y Aislamiento":
                SceneManager.LoadScene(sceneName: "Nivel 1 - Negacion y Aislamiento");
                break;

            case "NIvel 2 - Ira":
                SceneManager.LoadScene(sceneName: "NIvel 2 - Ira");
                break;

            case "NIvel 3 - Negociacion":
                SceneManager.LoadScene(sceneName: "NIvel 3 - Negociacion");
                break;

            case "Nivel 4 - Depression":
                SceneManager.LoadScene(sceneName: "Nivel 4 - Depression");
                break;

            case "NIvel 5 - Aceptacion":
                SceneManager.LoadScene(sceneName: "NIvel 5 - Aceptacion");
                break;
        }
    }


    public void ChangeLevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel 1 - Negacion y Aislamiento":
                SceneManager.LoadScene(sceneName: "NIvel 2 - Ira");
                break;

            case "NIvel 2 - Ira":
                SceneManager.LoadScene(sceneName: "NIvel 3 - Negociacion");
                break;

            case "NIvel 3 - Negociacion":
                SceneManager.LoadScene(sceneName: "Nivel 4 - Depression");
                break;

            case "Nivel 4 - Depression":
                SceneManager.LoadScene(sceneName: "NIvel 5 - Aceptacion");
                break;

            case "NIvel 5 - Aceptacion":
                SceneManager.LoadScene(sceneName: "Menu");
                break;
        }
    }


    private void Update()
    {
        if(completed)
        {
            timerText.text = "";

            if (collectibleCount == 4)
            {
                countdownText.text = "YOU WIN";
                timerText.text = "";
                Invoke("ChangeLevel", 2.0f);
                //ChangeLevel();
            }
            else
            {
                countdownText.text = "YOU LOSE";
                timerText.text = "";
                Invoke("LoseLevel", 2.0f);
                //LoseLevel();
            }
        }
        else
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                if (countdown >= -1)
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
                    CheckWinCondition();
                }
            }
        }
    }



    public void CheckWinCondition()
    {
        switch (collectibleCount)
        {
            case 0:
                heart.sprite = Sprites[0];
                break;
            case 1:
                heart.sprite = Sprites[1];
                break;
            case 2:
                heart.sprite = Sprites[2];
                break;
            case 3:
                heart.sprite = Sprites[3];
                break;
            case 4:
                heart.sprite = Sprites[4];
                completed = true;
                break;
            default:
                heart.sprite = Sprites[0];
                break;
        }
    }
}
