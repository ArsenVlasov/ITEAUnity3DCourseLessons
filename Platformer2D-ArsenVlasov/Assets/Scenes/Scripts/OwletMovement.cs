using UnityEngine;

public class OwletMovement : MonoBehaviour
{
    [SerializeField] public float owletSpeedX = 10f;
    [SerializeField] public float owletSpeedY = 10f;

    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Movement(Vector2.up);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Movement(Vector2.left);
        }
        if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            Movement(Vector2.right);
        }
    }

    private void Movement(Vector2 target)
    {
        Vector3 movement = new Vector3(target.x*owletSpeedX, target.y*owletSpeedY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
