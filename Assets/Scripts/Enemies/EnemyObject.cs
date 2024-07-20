using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Enemy/New Enemy Config")]
public class EnemyObject : ScriptableObject
{
    public int _health;
    public float _speed;

    public RuntimeAnimatorController _animatorController;
}
