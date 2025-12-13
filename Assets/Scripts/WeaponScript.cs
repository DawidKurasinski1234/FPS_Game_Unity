using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Collections;
using TMPro;

public class WeaponScript : MonoBehaviour
{
    public Animator playerAnimator;
    public float damage = 10f;
    public float range = 100f;
    public int MaxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 2f;
    public Camera fpsCam;
    private bool isReloading = false;
    Target enemy;
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        currentAmmo = MaxAmmo;
    }

    void Update()
    {
        ammoText.text = currentAmmo.ToString() + " / " + MaxAmmo.ToString();
        if (Input.GetButtonDown("Fire1") && currentAmmo  > 0 && isReloading == false)
        {
            playerAnimator.SetTrigger("Shoot");
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < MaxAmmo && isReloading == false)
        {
            StartCoroutine(Reload());
            isReloading = true;
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
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = MaxAmmo;
        isReloading = false;
    }


}
