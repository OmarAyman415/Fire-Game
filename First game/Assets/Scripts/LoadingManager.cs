
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [Header("Next Level Sound")]
    [SerializeField] private AudioClip nextLevelSound;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    SceneManager.LoadScene(1);

        //}
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {

            SceneManager.LoadScene(1);
            SoundManager.instance.PlaySound(nextLevelSound);
        }
    }
}
