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

    public bool gameOver;

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
    }

    public void OnDeath()
    {
        lives = Mathf.Clamp(lives - 1, 0, int.MaxValue);

        if (lives <= 0)
        {
            lives = 0;
            gameOver = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void PlayAgain() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void Quit() => Application.Quit();
}
