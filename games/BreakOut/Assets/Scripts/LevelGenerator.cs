using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject brick;

    [Range(1, 8)]
    public int countX = 3;
    [Range(1, 8)]
    public int countY = 3;

    [Range(0, 0.2f)]
    public float marginX = 0.02f;
    [Range(0, 0.2f)]
    public float marginY = 0.02f;

    public List<Color> colors;
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        GameManager.Instance.bricks = new List<GameObject>();
        for (int i = 0; i < countY; i++)
        {
            for (int j = 0; j < countX; j++)
            {
                float x = Mathf.Pow(-1, (j % 2)) * ((brick.transform.localScale.x + marginX) * Mathf.Ceil(j / 2f));
                float y = brick.transform.localScale.y + (brick.transform.localScale.y + marginY) * i;

                Vector3 position = new Vector3(x, y);
                GameObject newBrick = Instantiate(brick, position, Quaternion.identity);
                newBrick.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)];
                GameManager.Instance.bricks.Add(newBrick);
            }
        }
    }

}
