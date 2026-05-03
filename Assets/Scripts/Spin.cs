using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 0.5f * speed);
    }
}
