using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float MoveSpeed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * MoveSpeed) * Time.deltaTime;

        if (transform.position.x <= -18)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
