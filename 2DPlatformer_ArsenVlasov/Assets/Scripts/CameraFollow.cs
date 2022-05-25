using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public float leftLimit;
    [SerializeField] public float rightLimit;
    [SerializeField] public float topLimit;
    [SerializeField] public float bottomLimit;
    [SerializeField] public bool isLimitCameraWork = true;

    public void LateUpdate()
    {
        FollowToPlayer();
        if (isLimitCameraWork)
        {
            LimitCamera();
        }
    }

    private void FollowToPlayer()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1f);
    }

    private void LimitCamera()
    {
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            -1f
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
    }
}
