using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // to load the game after failing when click on replay button
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
