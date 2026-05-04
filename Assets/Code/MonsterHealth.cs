using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    private int currentHealth;

    private RoomController currentRoom;
    private MonsterAI aiScript;

    // ตั้งค่าโอกาสเกิด (เปอร์เซ็นต์)
    [Header("Damage Chances (0-100%)")]
    public float doubleDamageChance = 20f; 
    public float tripleDamageChance = 5f;  

    void Start()
    {
        currentHealth = maxHealth;
        aiScript = GetComponent<MonsterAI>();
    }

    public void SetRoom(RoomController room)
    {
        currentRoom = room;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            int finalDamage = 1;
            float randomValue = Random.Range(0f, 100f);
            
            if (randomValue <= tripleDamageChance)
            {
                finalDamage = 3;
                Debug.Log("CRITICAL HIT! TRIPLE DAMAGE! x3");
            }
            else if (randomValue <= (tripleDamageChance + doubleDamageChance))
            {
                finalDamage = 2;
                Debug.Log("NICE! DOUBLE DAMAGE! x2");
            }
            else
            {
                 Debug.Log("Normal Damage.");
            }

            TakeDamage(finalDamage); 
            Destroy(other.gameObject); 
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (currentRoom != null && aiScript != null)
        {
            currentRoom.MonsterDefeated(aiScript);
        }

        Destroy(gameObject); 
    }
}