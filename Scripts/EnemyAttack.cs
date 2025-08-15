using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    //[SerializeField] Transform target;
    PlayerHealth target;
    [SerializeField] float damage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackHitEvent();
        target = FindFirstObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        Debug.Log("Hit " + target.name + " for " + damage + " damage.");
    }
}
