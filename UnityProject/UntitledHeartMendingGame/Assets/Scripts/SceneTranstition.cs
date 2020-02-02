using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranstition : MonoBehaviour
{
    public void Reload()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeLevel()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel 1 - Negacion y Aislamiento":
                SceneManager.LoadScene(sceneName: "Nivel 2 - Ira");
                break;

            case "Nivel 2 - Ira":
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

    public void Level1()
    {
        SceneManager.LoadScene(sceneName: "Nivel 1 - Negacion y Aislamiento");
    }

    public void Level2()
    {
        SceneManager.LoadScene(sceneName: "Nivel 2 - Ira");
    }

    public void Level3()
    {
        SceneManager.LoadScene(sceneName: "Nivel 1 - Negacion y Aislamiento");
    }

    public void Level4()
    {
        SceneManager.LoadScene(sceneName: "Nivel 1 - Negacion y Aislamiento");
    }

    public void Level5()
    {
        SceneManager.LoadScene(sceneName: "Nivel 1 - Negacion y Aislamiento");
    }

    public void Credits()
    {
        SceneManager.LoadScene(sceneName: "Credits");
    }

    public void Menu()
    {
        Debug.Log("Intentando");
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
