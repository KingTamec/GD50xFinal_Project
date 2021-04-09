using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcoBoss : MonoBehaviour
{
    public float bossSpeed = 20f;
    public float bossHealth = 100000f;
    public ProgressBar progressBar;
    public GameObject player;
    public GameObject playerHUD;
    public GameObject deatheffect;
    public GameObject bossSpikePrefab;
    public AudioSource shotSound;
    public AudioSource deathSound;
    public GameObject goal;
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject allRemainingIcos;

    private ProgressBar bossHealthBar;
    private Vector3 targetPos;

    private List<GameObject> bossSpikes = new List<GameObject>();
    private float x;
    private float y;
    private float z;

    void Start()
    {
        x = transform.position.x;   // Start Position x = -61 | y = 64 | z = 286
        y = transform.position.y;
        z = transform.position.z;
        targetPos = new Vector3(Random.Range(x-2f, x+2f), Random.Range(y, y+20), Random.Range(z-2f, z+2f));

        StartCoroutine(Teleportation());

        StartCoroutine(ShootSpikes());

        bossHealthBar = Instantiate(progressBar, playerHUD.transform);
        bossHealthBar.transform.SetParent(playerHUD.transform, false);
        bossHealthBar.SetMaxValue((int) bossHealth);
        bossHealthBar.SetValue(bossHealth);
    }

    void Update()
    {
        if (transform.position == targetPos)
        {
            targetPos = new Vector3(Random.Range(x-10, x+10), Random.Range(y-6, y+6), Random.Range(z-10, z+10));
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, bossSpeed*Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        bossHealth -= damage;
        bossHealthBar.SetValue(bossHealth);
        if (bossHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        player.GetComponent<Player>().gameMusic.Stop();
        StopAllCoroutines();
        deathSound.Play();
        deatheffect.GetComponent<ParticleSystem>().Play();
        transform.localScale = new Vector3(0,0,0); 
        Destroy(bossHealthBar.gameObject);
        goal.SetActive(true);
        foreach (var spawner in spawners)
            Destroy(spawner.gameObject);

        // Code to kill all remaining Icos with death effect
        for (int i = 0; i < 8; i ++)
        {
            Transform holder = allRemainingIcos.transform.GetChild(i);
            foreach (Transform child in holder)
                child.GetComponent<Target>().Die();
        }
        Destroy(gameObject, 6f);
    }

    IEnumerator Teleportation()
    {
        while(true)
        {
            transform.position = new Vector3(Random.Range(x-10, x+10), Random.Range(y-6, y+6), Random.Range(z-10, z+10));
            yield return new WaitForSeconds(Random.Range(2,4));
        }
    }

    IEnumerator ShootSpikes()
    {
        while(true)
        {
            //Code for 32-gonal bipyramidal Spike shooting
            shotSound.Play();
            float angle = 0.000f;
            Vector3 playerPos = transform.position - player.transform.position;
            float shootangle = 90f - Vector3.Angle(transform.up, playerPos);

            //int sign = 1;
            for (int i = 0; i < 64; i ++)
            {
                bossSpikes.Add(Instantiate(bossSpikePrefab, transform.position, transform.rotation));
                
                bossSpikes[i].transform.RotateAround(bossSpikes[i].transform.position, 
                bossSpikes[i].transform.up, angle);
                angle += 5.625f;

                bossSpikes[i].transform.RotateAround(bossSpikes[i].transform.position, 
                bossSpikes[i].transform.right, shootangle);             
            }

            // old Code for octagonal bipyramidal Spike shooting
            //int angle = 45;
            //int sign = 1;
            //for (int i = 0; i < 10; i ++)
            //{
            //    bossSpikes.Add(Instantiate(bossSpikePrefab, transform.position, transform.GetChild(2).transform.rotation));
            //    if (i > 0 && i < 8)
            //    {
            //        bossSpikes[i].transform.RotateAround(bossSpikes[i].transform.position, 
            //        bossSpikes[i].transform.right, angle);
            //        angle += 45;
            //    }
            //    if (i > 7)
            //    {
            //        angle = 90;
            //        bossSpikes[i].transform.RotateAround(bossSpikes[i].transform.position,
            //        bossSpikes[i].transform.up * sign, angle);
            //        sign -= 2;
            //    }
            //}

            yield return new WaitForSeconds(Random.Range(4,6));

            // Code to destroy all spikes and ready the bossSpike list for next instantiation
            foreach (var spike in bossSpikes)
            {
                Destroy(spike.gameObject);
            }
            bossSpikes.Clear();
        }
    }
}
