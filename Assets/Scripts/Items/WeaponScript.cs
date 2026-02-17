using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private int magAmmo;
    [SerializeField] private int currentMag;
    [SerializeField] private int totalAmmo;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletRange;
    [SerializeField] private float reloadTime;
    [SerializeField] private float currentReload;
    [SerializeField] private float fireCooldown ;
    [SerializeField] private float currentCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else if (currentCooldown < 0)
        { 
        currentCooldown = 0;
        }
        if (currentReload > 0)
        {
            currentReload -= Time.deltaTime;
        }
        else if (currentReload < 0)
        {
            currentReload = 0;
        }



        if (Input.GetButtonDown("Fire1") && currentCooldown == 0 && currentReload == 0)
        {
            FireGun();
        }
    }

    private void FireGun()
    {
        currentCooldown = fireCooldown;


    }


}
