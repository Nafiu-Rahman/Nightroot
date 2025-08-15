using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] int ammoAmount = 25;

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }

    public void IncreaseCurrentAmmo(int amount)
    {
        ammoAmount+= amount;
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
