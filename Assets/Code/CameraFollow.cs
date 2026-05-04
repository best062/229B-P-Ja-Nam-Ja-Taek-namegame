using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // ลากตัวละคร (Player) มาใส่ช่องนี้

    [Header("Camera Settings")]
    public float smoothSpeed = 5f; // ความสมูทของการตาม (ค่ายิ่งน้อยยิ่งตามช้า ค่ายิ่งมากยิ่งตามติด)
    public Vector3 offset = new Vector3(0f, 0f, -10f); // ระยะห่างกล้อง (2D แกน Z ต้องติดลบไว้เสมอ)

    void FixedUpdate()
    {
        // ตรวจสอบว่ามีตัวละครให้ตามหรือไม่
        if (target != null)
        {
            // คำนวณตำแหน่งที่กล้องควรจะไปอยู่
            Vector3 desiredPosition = target.position + offset;
            
            // ค่อยๆ เคลื่อนกล้องไปยังเป้าหมายอย่างนุ่มนวลด้วย Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
            
            // อัปเดตตำแหน่งกล้อง
            transform.position = smoothedPosition;
        }
    }
}