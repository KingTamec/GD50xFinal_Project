using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 25f;
    public float impactForce = 50f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactFlare;
    Animator shootAnimation;

    public AudioSource fireSound;

    private float readyToFire = 0f;

    void Start()
    {
        shootAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        // Input.GetButtonDown to have to click each time ... GetButton for rapid fire

        if (Input.GetButtonDown("Fire1") && Time.time >= readyToFire )
        {
            readyToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        fireSound.Play();
        muzzleFlash.Play();
        shootAnimation.SetTrigger("shotPistol");

        int layerMask = 1 << 9;

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMask)) 
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impact = Instantiate(impactFlare, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }
    }
}
