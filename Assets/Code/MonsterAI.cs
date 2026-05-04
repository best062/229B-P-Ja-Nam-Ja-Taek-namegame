using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [Header("Monster Settings")]
    public float moveSpeed = 1f;
    public float stoppingDistance = 1f; 
    
    public bool isActive = false; 

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (!isActive) return;

        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            float distance = direction.magnitude;

            if (distance > stoppingDistance)
            {
                movement = direction.normalized;
            }
            else
            {
                movement = Vector2.zero; 
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); 
            }
        }
    }

    void FixedUpdate()
    {
        if (!isActive) return;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    public void ActivateMonster()
    {
        isActive = true;
    }
}