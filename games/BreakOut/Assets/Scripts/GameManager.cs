using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> bricks;

    public int score;
    public TextMeshProUGUI scoreText;

    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        instance = this;
    }

    private GameManager() { }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void BlockDestroyed(GameObject brick){
        IncreaseScore();
        bricks.Remove(brick);
        if(bricks.Count == 0)
            this.Restart();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
