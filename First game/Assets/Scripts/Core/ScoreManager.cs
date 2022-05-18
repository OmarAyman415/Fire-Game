using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    public Text scoreText;
    public Text highscoreText;

    public GameObject pauseMenu;
    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        // Keep this object even when we go to a new scene
        if (instance == null)
        {
            instance = this;
            instance.score = 0;
            pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            DontDestroyOnLoad(gameObject);
        }
        // Delete the duplicate gameObjects
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        instance.highscore = PlayerPrefs.GetInt("highscore", 0);
    }



    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = score.ToString() + " POINTS";
        PlayerPrefs.SetInt("score", score);
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    public void Reset(){
        score = 0;
    }
}


