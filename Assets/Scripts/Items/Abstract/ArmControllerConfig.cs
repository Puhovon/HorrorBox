using UnityEngine;

namespace Items.Abstract
{
    [CreateAssetMenu(fileName = "ArmConfig", menuName = "Configs/ArmConfig")]
    public class ArmControllerConfig : ScriptableObject
    {
        [field: SerializeField] public float Distance;
        [field: SerializeField] public int MaxItems;
    }
}