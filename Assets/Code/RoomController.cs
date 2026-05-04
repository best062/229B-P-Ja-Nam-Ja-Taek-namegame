using UnityEngine;
using System.Collections.Generic; // เพิ่มเข้ามาเพื่อใช้งาน List

public class RoomController : MonoBehaviour
{
    [Header("Room Objects")]
    public GameObject[] doors;
    
    public List<MonsterAI> monstersInRoom; 

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            LockRoom();
        }
    }

    void LockRoom()
    {
        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                door.SetActive(true); 
            }
        }
        
        foreach (MonsterAI monster in monstersInRoom)
        {
            if (monster != null)
            {
                monster.ActivateMonster();
                
                MonsterHealth health = monster.GetComponent<MonsterHealth>();
                if (health != null)
                {
                    health.SetRoom(this);
                }
            }
        }
        
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("Room Locked!");
    }
    
    public void MonsterDefeated(MonsterAI defeatedMonster)
    {
        monstersInRoom.Remove(defeatedMonster);
        
        if (monstersInRoom.Count <= 0)
        {
            OpenRoom();
        }
    }

    void OpenRoom()
    {
        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                door.SetActive(false); 
            }
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerHealth pHealth = player.GetComponent<PlayerHealth>();
            if (pHealth != null)
            {
                int randomHeal = Random.Range(1, 4); 
                pHealth.Heal(randomHeal);
            }
        }
        Debug.Log("Room Cleared! Doors Opened.");
    }
}