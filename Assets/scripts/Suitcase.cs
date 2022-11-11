using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suitcase : MonoBehaviour
{
    float min_x = -1f, max_x = 1f;

    bool canMove;
    float moveSpeed;
    bool gameOver;
    bool ignoreCollision;
    bool ignoreTrigger;

    Rigidbody2D myBody;
    void Awake() 
    {
        moveSpeed = 2f;
        min_x = -1.8f;
        max_x = 1.8f;
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    
    }
    void Start()
    {
        canMove = true;
        if (Random.Range(0, 2) > 0)
        {
            moveSpeed *= -1f;

        }
        Controller.controller.currentCase = this;
        
    }

    void Update()
    {
        MoveCase();
    }

    void MoveCase()
    {
        if (canMove)
        {
            Vector3 pos = transform.position;
            pos.x += moveSpeed * Time.deltaTime;
            if (pos.x > max_x)
            {
                moveSpeed *= -1f;
            }
            else if (pos.x < min_x)
            {
                moveSpeed *= -1f;
            }

            transform.position = pos;
        
        }
    }
    public void DropBox()
    {
        canMove = false;
        myBody.gravityScale = Random.Range(2, 4);
    
    }

    public void Landed()
    {
        if (gameOver)
            return;
        ignoreCollision = true;
        ignoreTrigger = true;
        Controller.controller.SpawnNewCase();
        Controller.controller.MoveCamera();



    }

    void RestartGame() {
        Controller.controller.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
            return;
        if (target.gameObject.tag == "platform")
        {
            Invoke("Landed", 0.5f);
            ignoreCollision = true;
        }
        if (target.gameObject.tag == "case")
        {
            Invoke("Landed", 0.5f);
            ignoreCollision = true;
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;
        if (target.tag == "GOver") 
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("RestartGame", 1f);
        }
    }

}
