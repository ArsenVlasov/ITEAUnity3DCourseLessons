using UnityEngine;

public class LaunchRopeWithBall : MonoBehaviour
{
    [SerializeField] private Rigidbody _ball;

    void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseKey.LeftKey))
        {
            UntieRope();
        }
    }

    private void UntieRope()
    {
        _ball.constraints = RigidbodyConstraints.None;
    }
}
