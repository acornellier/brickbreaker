using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Text livesText;
    public Text scoreText;
    public GameObject gameOverPanel;

    public int lives;
    public int score;
    public int remainingBricks;
    public bool gameOver;

    void Start()
    {
        remainingBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        livesText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    public void OnBrickDestroy()
    {
        score += 1;
        --remainingBricks;
        if (remainingBricks <= 0)
            OnGameOver();
    }

    public void OnDeath()
    {
        lives = Mathf.Clamp(lives - 1, 0, int.MaxValue);

        if (lives <= 0)
            OnGameOver();
    }

    void OnGameOver()
    {
        lives = 0;
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void Quit() => Application.Quit();
}
