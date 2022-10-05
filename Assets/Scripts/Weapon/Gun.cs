using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float speed = 40f;
    public GameObject bullet;
    public Transform aimPoint;
    
    
    //Basic Features
    public float spread, reloadTime, timeBetweenShots, timeBetweenShooting;
    public int magSize, tapSize, bulletsLeft, bulletsShot;
    public bool allowHold, isReloading;
    private bool isShooting, isReadyToShoot;
    public float damage = 10.0f;
    public float range = 100.0f;

    //Player
    public GameObject player;

    //Visual 
    public GameObject muzzleFlash;

    //Audio 
    //public AudioSource audioSource;
    //public AudioClip audioClip;
    
    public void Awake()
    {
        bulletsLeft = magSize;
        isReadyToShoot = true;
        
    }

    public void Shoot()
    {
        isReadyToShoot = false;

        Vector3 directionSpread = aimPoint.forward;
        directionSpread.x += Random.Range(-spread /2.0f, spread / 2.0f);
        directionSpread.y += Random.Range(-spread, spread);

        GameObject spawnBullet = Instantiate(bullet, aimPoint.position, aimPoint.rotation);
        spawnBullet.GetComponent<Rigidbody>().velocity = speed * directionSpread.normalized;

        bulletsLeft--;
        bulletsShot++;

        if (muzzleFlash != null)
        {
            //muzzleFlash.Emit(100);
        }
        
        //audioSource.PlayOneShot(audioClip);
        Destroy(spawnBullet, 2);
    }

    private void ResetShoot()
    {
        isReadyToShoot = true;
    }

    //private IEnumerator Reload()
    //{
    //    isReloading = true;

    //    ReloadComplete();
    //}

    private void ReloadComplete()
    {
        bulletsLeft = magSize;
        isReloading = false;
    }
}
