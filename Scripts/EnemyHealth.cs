using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    void Awake() 
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount) 
    {
        BroadcastMessage("OnDamageTaken");
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
