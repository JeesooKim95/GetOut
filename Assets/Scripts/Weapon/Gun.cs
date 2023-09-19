using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float speed = 40f;
    public GameObject bullet;
    public Transform aimPoint;


    //Basic Features
    public float spread, reloadTime, timeBetweenShots, timeBetweenShooting;
    private float lastShotTime;
    public int magSize, tapSize;
    private int bulletsLeft, bulletsShot;
    public bool allowHold;
    private bool isShooting, isReadyToShoot, isReloading;
    public float range = 100.0f;
    public int _damage = 10;

    //Player
    public GameObject player;

    //Visual 
    [SerializeField]
    private ParticleSystem muzzle;
    //Raycast 
    [SerializeField]
    private TrailRenderer bullet_trail;
    [SerializeField]
    private ParticleSystem impact_particle;
    [SerializeField]
    private LayerMask mask;

    //Audio 
    //public AudioSource audioSource;
    //public AudioClip audioClip;


    public void Awake()
    {
        bulletsLeft = magSize;
        isReadyToShoot = true;
    }

    private void Update()
    {

    }


    public void Shoot()
    {   
        if (lastShotTime + timeBetweenShooting < Time.time /*&& bulletsLeft > 0*/)
        {
            FindObjectOfType<AudioManager>().Play("Rifle_Single");
            Vector3 direction = GetDirection();

            if (Physics.Raycast(aimPoint.position, direction, out RaycastHit hit, float.MaxValue, mask))
            { 
                
                TrailRenderer trail = Instantiate(bullet_trail, aimPoint.position, Quaternion.identity);

                StartCoroutine(SpawnTrail(trail, hit));

                if (hit.collider.tag =="Enemy")
                {
                    hit.collider.GetComponent<Health>().TakeDamage(_damage);
                }
            }

            bulletsLeft--;
            bulletsShot++;

            if (muzzle != null)
            {
                muzzle.Emit(100);
            }

            lastShotTime = Time.time;
        }
        else if(bulletsLeft <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Rifle_Empty");
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = aimPoint.forward;

        direction += new Vector3(Random.Range(-spread, spread), 
            Random.Range(-spread, spread), 
            Random.Range(-spread, spread));

        direction.Normalize();

        return direction;
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 start_pos = trail.transform.position;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(start_pos, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }
        //Animator.SetBool("IsShooting", false);
        trail.transform.position = hit.point;
        
        Instantiate(impact_particle, hit.point, Quaternion.LookRotation(hit.normal));
               

        Destroy(trail.gameObject, trail.time);
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

    public void IncreaseMagSize(int amount)
    {
        magSize += amount;
    }

    public void IncreaseDamage(int amount)
    {
        _damage += amount;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public int GetMagSize()
    {
        return magSize;
    }
}
