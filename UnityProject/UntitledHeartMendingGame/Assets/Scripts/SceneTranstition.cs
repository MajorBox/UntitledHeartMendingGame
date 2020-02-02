using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranstition : MonoBehaviour
{
    public void Reload()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Level1()
    {
        SceneManager.LoadScene(sceneName: "Nivel 1 - Negacion y Aislamiento");
    }

    public void Level2()
    {
        SceneManager.LoadScene(sceneName: "Nivel 1 - Negacion y Aislamiento");
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
