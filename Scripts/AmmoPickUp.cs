using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    [SerializeField] int ammoAmount = 25;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<Ammo>()?.IncreaseCurrentAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
