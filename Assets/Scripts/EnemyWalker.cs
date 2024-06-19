using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= 0)
            MoveRight();
        else
            MoveLeft();

    }

    private void MoveRight()
    {
        rb.velocity = new Vector2(rb.velocity.x + moveSpeed * Time.deltaTime, rb.velocity.y);
    }
    private void MoveLeft()
    {
        rb.velocity = new Vector2(rb.velocity.x - moveSpeed * Time.deltaTime, rb.velocity.y);
    }

}
