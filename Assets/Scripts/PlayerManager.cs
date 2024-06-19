using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private bool hasDead = false;

    private void Update()
    {
        if(hasDead)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerDetector"))
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Debug.Log("Se ha pisado");
        }

        if(collision.gameObject.CompareTag("PlayerKiller") || collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy"))
        {
            hasDead = true;
        }
    }


}
