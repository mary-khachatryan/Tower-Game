using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    public static Controller controller;
    public Spawner spawner;

    public Suitcase currentCase;
    public CameraFollow cameraScript;
    int moveCount;
    int score = 0;
    public Text scoreText;
    void Awake()
    {
        if (controller == null)
            controller = this;
    
    
    }
    void Start()
    {

        spawner.Spawn();
        scoreText.text= "Score:" + score;
            }
    // Update is called once per frame
    void Update()
    {
        DetectInput();
        scoreText.text = "Score:" + score;
    }
    void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentCase.DropBox();
        
        }
    }

    public void SpawnNewCase()
    {
        Invoke("NewCase", 1f);

    }
    void NewCase()
    {
        spawner.Spawn();
    }

    public void MoveCamera()
    {
        moveCount++;
        score++;
        if (moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 1f;
        }
    //
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        score = 0;
    }
}
