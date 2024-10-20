using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Range(1, 10)] public float Speed;
        [field: SerializeField, Range(1, 10)] public float SpeedY;
        [field: SerializeField, Range(1, 100)] public float RotateSpeedX;
        [field: SerializeField, Range(1, 100)] public float RotateSpeedY;
        [field: SerializeField, Range(1, 180)] public float VerticalRotationHigherBound;
        [field: SerializeField, Range(-180, -1)] public float VerticalRotationLowerBound;
    }
}