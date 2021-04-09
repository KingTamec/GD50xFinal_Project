using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public ParticleSystem deathEffect;
    public AudioSource deathSound;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        FindObjectOfType<Player>().kills++;
        deathEffect.Play();
        deathSound.Play();
        this.transform.localScale = new Vector3(0,0,0);
        if (gameObject.GetComponent<IcoCode>())
        {
            FindObjectOfType<Player>().score += 20;
        }
        if (gameObject.GetComponent<MicroIcoCode>())
        {
            FindObjectOfType<Player>().score += 50;
        }
        
        if (gameObject.GetComponent<SpikyCode>())
        {
            FindObjectOfType<Player>().score += 150;
            gameObject.GetComponent<SpikyCode>().alive = false;
            gameObject.GetComponent<SpikyCode>().StopAllCoroutines();
            Destroy(gameObject, 4f);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
}
