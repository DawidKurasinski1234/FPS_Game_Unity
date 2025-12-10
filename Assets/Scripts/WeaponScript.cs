using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WeaponScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int MaxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 2f;
    public Camera fpsCam;
    private bool isReloading = false;
    Target enemy;

    private void Start()
    {
        currentAmmo = MaxAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo  > 0 && isReloading == false)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        currentAmmo -= 1;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            enemy = hit.transform.GetComponent<Target>();
            
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

    }
    
       
}
