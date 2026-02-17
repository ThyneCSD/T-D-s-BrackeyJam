using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] private Transform shootPoint;

    [Header("Bullet stats")]
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletRange;

    [Header("Ammo stats")]
    [SerializeField] private int magAmmo;
    [SerializeField] private int currentMag;
    //[SerializeField] private int totalAmmo;
    [Header("Cooldown times")]
    [SerializeField] private float reloadTime;
    [SerializeField] private float currentReload;
    [SerializeField] private float fireCooldown ;
    [SerializeField] private float currentCooldown;

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
            if (currentMag > 0)
            {
                FireGun();
            }
            else
            {
                currentReload = reloadTime;
                currentMag = magAmmo;
            }
        }
    }

    private void FireGun()
    {
        currentCooldown = fireCooldown;
        currentMag--;

        //Wat er gebeurt als je schiet

        //animation


        //ra+akt ie iets
        shootPoint.transform.position = Vector3.zero;
        //if (Physics.Raycast() )
    }

}
