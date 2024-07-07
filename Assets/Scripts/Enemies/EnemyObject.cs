using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Enemy/ New Enemy")]
public class EnemyObject : ScriptableObject
{

    public float speed;

    public RuntimeAnimatorController animatorController;
}
