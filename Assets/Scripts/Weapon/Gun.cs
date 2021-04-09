using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 25f;
    public float impactForce = 50f;
    public bool rapidfire;
    public float heating = 0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactFlare;
    Animator shootAnimation;
    AutomaticOverHeat overHeat;

    public AudioSource fireSound;
    public AudioSource clampSound;

    private float readyToFire = 0f;

    void Start()
    {
        shootAnimation = GetComponent<Animator>();
        if (rapidfire)
        {
            overHeat = transform.parent.GetComponent<AutomaticOverHeat>();
        }
    }

    void Update()
    {
        // Input.GetButtonDown to have to click each time ... GetButton for rapid fire
        if (rapidfire == true)
        {
            if (Input.GetButton("Fire1") && Time.time >= readyToFire && !overHeat.overHeated)
            {
                readyToFire = Time.time + 1f / fireRate;
                Shoot();
            }
            else if (Input.GetButtonDown("Fire1") && Time.time >= readyToFire && overHeat.overHeated)
            {
                readyToFire = Time.time + 1f / fireRate;
                clampSound.Play();
            }
        }
        if (rapidfire == false)
        {   
            if (Input.GetButtonDown("Fire1") && Time.time >= readyToFire )
            {
                readyToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        transform.parent.parent.parent.GetComponent<Player>().shots++;
        fireSound.Play();
        muzzleFlash.Play();
        shootAnimation.SetTrigger("shoot");

        int layerMask = (1 << 9) | (1 << 2);

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMask)) 
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                transform.parent.parent.parent.GetComponent<Player>().hits++;
            }
            
            if (hit.transform.tag == "IcoBoss")
            {
                IcoBoss boss = hit.transform.GetComponent<IcoBoss>();
                boss.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                float distToPlayer = Vector3.Distance(hit.transform.position, 
                    transform.parent.parent.parent.position);

                hit.rigidbody.AddForce(-hit.normal * impactForce * 1/distToPlayer);
            }

            GameObject impact = Instantiate(impactFlare, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }

        if (rapidfire == true)
        {
            overHeat.RaiseHeat(heating);
        }
    }
}
