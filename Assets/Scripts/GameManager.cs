using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject EscapeObj, ChaseObj, RandomObj, StartButton;
    Vector2 RandomPosition;
    float rndXPos, rndYPos;
    float _score;
    public TextMeshProUGUI scoreText;
    public List<GameObject> EnemyList = new List<GameObject>();
    private bool isInGame = false;
    void FixedUpdate()
    {
        if(isInGame)
        {
            _score += 1 * Time.deltaTime;
        }
        scoreText.text = "Score: " + (int)_score;
    }

    void CreateGameObjects(GameObject obj)
    {
        rndXPos = Random.Range(-7, 7);
        rndYPos = Random.Range(-4, 4);
        RandomPosition = new Vector2(rndXPos, rndYPos);

        GameObject ob = Instantiate(obj, RandomPosition, Quaternion.identity);
        EnemyList.Add(ob);
    }

    public void AddScore()
    {
        _score += 5;
    }

    public void GameStart()
    {
        isInGame = true;
        StartButton.SetActive(false);
        _score = 0;

        CreateGameObjects(EscapeObj);
        CreateGameObjects(ChaseObj);
        CreateGameObjects(RandomObj);
    }

    public void GameEnd()
    {
        isInGame = false;

        foreach (GameObject ob in EnemyList)
            Destroy(ob);
        EnemyList.Clear();

        StartButton.SetActive(true);
    }


}
