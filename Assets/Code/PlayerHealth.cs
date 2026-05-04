using UnityEngine;
using TMPro; // เรียกใช้ระบบ TextMeshPro สำหรับ UI

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 10;
    private int currentHealth;

    [Header("UI References")]
    public TextMeshProUGUI hpText; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth < 0) 
        {
            currentHealth = 0;
        }

        UpdateHealthUI(); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Heal(int amount)
    {
        currentHealth += amount;
        
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }

        UpdateHealthUI();
        Debug.Log("Healed " + amount + " HP! Current HP: " + currentHealth);
    }

    void UpdateHealthUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHealth + " / " + maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player Died! Game Over.");
        
        GameManager gm = FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            gm.GameOver();
        }
        
        Destroy(gameObject); 
    }
}