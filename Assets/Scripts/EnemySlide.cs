using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlide : MonoBehaviour
{
    [SerializeField] private float movetSpeed;
    [SerializeField] private bool goingRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
        Move();
    }

    private void CheckPosition()
    {
        if (gameObject.transform.position.x <= -10)
            goingRight = true;
        if(gameObject.transform.position.x >= 10)
            goingRight = false;
    }

    private void Move()
    {
        if (goingRight)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + movetSpeed, gameObject.transform.position.y);
        else
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - movetSpeed, gameObject.transform.position.y);

    }
}
