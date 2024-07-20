using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Enemy/New Enemy")]
public class EnemyObject : ScriptableObject
{

    public int _life;
    public float _speed;

    public RuntimeAnimatorController _animatorController;
}
