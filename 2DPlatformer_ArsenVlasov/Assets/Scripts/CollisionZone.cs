using UnityEngine;

public enum CollisionZoneType
{
    Ground
}

public class CollisionZone : MonoBehaviour
{
    [SerializeField] private CollisionZoneType _collisionZoneType;
    public CollisionZoneType Type => _collisionZoneType;
}
