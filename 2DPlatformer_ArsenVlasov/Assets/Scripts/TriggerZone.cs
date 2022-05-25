using UnityEngine;

public enum TriggerZoneType
{
    Death,
    Finish,
    Diamond
}

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private TriggerZoneType _triggerZoneType;
    public TriggerZoneType Type => _triggerZoneType;
}
