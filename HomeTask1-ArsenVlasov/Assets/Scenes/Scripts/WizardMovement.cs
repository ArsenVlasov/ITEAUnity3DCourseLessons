using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    [SerializeField] public float speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Movement(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Movement(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Movement(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movement(Vector3.right);
        }
    }

    private void Movement(Vector3 direction)
    { 
        transform.position = transform.position + direction*speed*Time.deltaTime;
    }
}
