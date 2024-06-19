using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Shoot Values")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Vector2 bulletSpeed;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float shotsCooldown;

    [Header("Movement Values")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool facingRight = true;

    [Header("Jump Values")]
    [SerializeField] private float jumpForce;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isGrounded;

    




    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Shoot();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("ControlHorizontal");

        if (horizontalInput != 0)
        {
            
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

            if (horizontalInput > 0 && !facingRight)
            {
                Flip();
            }
            else if (horizontalInput < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("JumpControl") && isGrounded)
        {
            Debug.Log("Pulsando A");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Flip()
    {
        // Cambia la dirección en la que el personaje está mirando.
        facingRight = !facingRight;

        // Multiplica la escala x del personaje por -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Shoot()
    {
        if(Input.GetButtonDown("ShootControl") && canShoot)
        {
            SpawnObject();
            StartCoroutine(ShotCooldown());
        }
    }

    private void SpawnObject()
    {
        // Instanciar el objeto en la posición y rotación del objeto de referencia
        GameObject instantiatedObject = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        // Obtener el Rigidbody2D del objeto instanciado
        Rigidbody2D rb = instantiatedObject.GetComponent<Rigidbody2D>();

        // Verificar si el objeto instanciado tiene un Rigidbody2D
        if (rb != null)
        {
            if (facingRight)
            {
                rb.velocity = bulletSpeed;
            }
            else
            {
                rb.velocity = bulletSpeed * -1;
            }
        }
    }

    IEnumerator ShotCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotsCooldown);
        canShoot = true;
    }
}
