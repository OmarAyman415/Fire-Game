
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject endMenu;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Time.timeScale = 0f;
            endMenu.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        ScoreManager.instance.Reset();
    }


    public void ExitToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
