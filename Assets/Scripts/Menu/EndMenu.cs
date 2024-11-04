using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ApplicationExit()
    {
        Application.Quit();
    } 
}
