using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;

    float currentHealth;

    void Awake() 
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float amount) 
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            GetComponent<DeathHandler>()?.HandleDeath();
            //Destroy(this.gameObject);
        }
    }
}
