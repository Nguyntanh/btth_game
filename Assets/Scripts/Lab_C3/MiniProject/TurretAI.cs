using UnityEngine;

public class TurretAI : MonoBehaviour {
    public Transform target;
    public float rotSpeed = 5f;

    void Update() {
        if (target == null) return;
        
        Vector3 dir = target.position - transform.position;
        dir.y = 0; // Chỉ xoay ngang

        if (dir != Vector3.zero) {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            // Xoay mượt (Slerp)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
    }
}