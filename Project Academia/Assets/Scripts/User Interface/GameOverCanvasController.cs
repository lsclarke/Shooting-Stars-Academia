using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvasController : MonoBehaviour
{
    public GameObject HUD;
    [SerializeField]
    public StarBoy starBoy;
    public void ActivateGameOverScreen()
    {
        HUD.SetActive(true);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RetryFromCheckPoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}