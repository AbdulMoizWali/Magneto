using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 20;
    [SerializeField] private int totalScore = 0;
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;



    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            totalScore = GameObject.FindGameObjectsWithTag("Coin").Length * 10;
            scoreText.text = score.ToString();
            healthText.text = health.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        score += 10;
        scoreText.text = score.ToString();
        if (score == totalScore)
        {
            winPanel.SetActive(true);
            Debug.Log("You win!");
        }
    }

    public void TakeDamage()
    {
        health -= damage;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("Game Over!");
        }
    }

    public void ResetGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
