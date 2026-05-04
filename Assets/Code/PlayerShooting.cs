using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public Transform firePoint;     
    public GameObject bulletPrefab;  
    public float bulletForce = 20f;  
    
    public float bulletMass = 0.5f;  

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        
        if (rbBullet != null)
        {
            rbBullet.mass = bulletMass;
            
            float forceMagnitude = bulletMass * bulletForce; 
            
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = (mousePos - (Vector2)firePoint.position).normalized;
            
            rbBullet.AddForce(shootDirection * forceMagnitude, ForceMode2D.Impulse);
        }
    }
}