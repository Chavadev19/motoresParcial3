using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeBetweenShots;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawner;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= 0)
            MoveFromLeft();
        else
            MoveFromRight();

    }

    private void MoveFromRight()
    {
        if(gameObject.transform.position.x > 7)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(rb.velocity.x - moveSpeed * Time.deltaTime, rb.velocity.y);
        }
        
    }
    private void MoveFromLeft()
    {
        if (gameObject.transform.position.x < -7)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(rb.velocity.x + moveSpeed * Time.deltaTime, rb.velocity.y);
        }
    }

    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShots);
            Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
        }
    
    }
}
