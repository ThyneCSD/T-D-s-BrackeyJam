using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private int magAmmo;
    [SerializeField] private int totalAmmo;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletRange;
    [SerializeField] private float reloadTime;
    [SerializeField] private float fireCooldown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
