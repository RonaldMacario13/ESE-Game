using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyObject enemySettings;

    private string enemyName;
    private float health;
    private float speed;
    private float attack;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();

        animator.runtimeAnimatorController = enemySettings.animatorController;

        enemyName = enemySettings.enemyName;
        health = enemySettings.health;
        speed = enemySettings.speed;
        attack = enemySettings.attack;
    }

}
