using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 0.5f;

    private float nextAttackTime;

    public Transform player;
    private PlayerHealth playerHealth;

    void Start()
    {
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (player == null ||  playerHealth == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            playerHealth.TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
