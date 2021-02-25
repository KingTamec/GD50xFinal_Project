using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Image hitEffect;
    public float playerHealth = 100f;
    public Text HealthValue;
    
    void Start()
    {

    }

    void Update()
    {
        HealthValue.text = string.Format("{0}", playerHealth.ToString());
    }

    void OnTriggerEnter(Collider collider)
    {
        float colorAmount = 0.7f - 0.6f*(playerHealth/100f);
        hitEffect.color = new Color (1,0,0,colorAmount);
        Invoke("stopHitEffect", 0.2f);
        Destroy(collider.gameObject);
        PlayerTakeDamage(5);
    }

    void stopHitEffect()
    {
        hitEffect.color = new Color (1,0,0,0);
    }

    public void PlayerTakeDamage(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

