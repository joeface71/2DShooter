using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Enemies/EnemyData", order = 0)]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField]
    public int MaxHealth { get; set; } = 3;

    [field: SerializeField]
    public int Damage { get; set; } = 1;
}