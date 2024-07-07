using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Enemy/ New Enemy")]
public class EnemyObject : ScriptableObject
{
    public string enemyName;
    public float health;
    public float speed;
    public float attack;

    public RuntimeAnimatorController animatorController;
}
