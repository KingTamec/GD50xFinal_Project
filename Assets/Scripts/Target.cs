using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public ParticleSystem deathEffect;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        deathEffect.Play();
        this.transform.localScale = new Vector3(0,0,0); 
        Destroy(gameObject, 0.2f);
    }
}
