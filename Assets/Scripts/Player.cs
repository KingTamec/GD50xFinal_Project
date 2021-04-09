/*ICOSPHERE a FPS game by Thomas Feuerstein
My Final Project for the Harvard course
CS50's Introduction to Game Development

This is a Noncommercial project!
My purpose in this is mainly to improve my skills in 
scripting in C# and to get more familiar with working with the UnityEngine

Game music: yellow by cyba (c) 
copyright 2019 Licensed under 
a Creative Commons Attribution Noncommercial (3.0) license.
http://dig.ccmixter.org/files/cyba/60166 

& new circle by cyba (c) 
copyright 2019 Licensed under 
a Creative Commons Attribution Noncommercial  (3.0) license. 
http://dig.ccmixter.org/files/cyba/60087 

Sound Effects from https://freesound.org
Many thanks to: 
tim.kahn for clorina.wav | StonedB for Huge Laser.wav | 
soundmonster0 for game-over.wav | problematist for space-laser-shot.ogg |
ticebilla for shoot.wav | mattc90 for neurofunk-d-n-b-style-distorted-synth-bass-wob.wav |
cbj-student for breaking-glass-mix.wav | speedenza for whoosh-woow-pt26.wav |
navadaux for whipy-woosh-transition.wav | filmmakersmanual for bullet-flyby-3.wav |
dwareing for maroon.wav | prutsik for space-swoosh.mp3 | rhodesmas for win-02.wav |
mrickey13 for playerhurt1.wav & playerhurt2.wav | deathscyp for damage-1.wav |
javierzumer for charging-loop-2.wav | unfa for medium-far-explosion.wav |
matrixxx for powerup-07.wav |

All remaining sounds are self-made with the programm Bfxr (https://www.bfxr.net/) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public Image hitEffect;
    public AudioClip[] hitSounds;
    public AudioClip pickupSound;
    public Image flashEffect;
    public float playerHealth = 100f;
    public Text HealthValue;
    public Text stats;
    public AudioSource gameMusic;
    public GameObject pauseMenu;

    [HideInInspector] public int shots = 0;
    [HideInInspector] public int hits = 0;
    [HideInInspector] public int kills = 0;
    [HideInInspector] public int score = 0;
    [HideInInspector] public int accuracyInPercent = 0;
    [HideInInspector] public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private AudioSource audioSource;
    private float alpha = 1f;
    private bool fadeInComplete = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!fadeInComplete)
        {
            alpha -= Time.deltaTime/3;
                
            if (alpha <= 0f)
            {
                alpha = 0f;
                fadeInComplete = true;
            }
            flashEffect.color = new Color (1,1,1,alpha);
        }

        HealthValue.text = string.Format("{0}", playerHealth.ToString());

        if (transform.position.y < 0)
        {
            GameOver();
        }

        if (hits != 0)
        {
            accuracyInPercent = (int)Mathf.RoundToInt(((float)hits/(float)shots)*100f);
        }

        if (stats != null)
        {
            stats.text = string.Format("{0}\n{1}\n{2}%", kills, score, accuracyInPercent);
        }

        // CODE for PauseMenu
        if (Input.GetButtonDown("Pause") && Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        if (Input.GetButtonDown("Submit") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        if (Input.GetButtonDown("Cancel") && Time.timeScale == 0)
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Ico")
        {
            Destroy(collider.transform.parent.gameObject);
            PlayerTakeDamage(5);
        }
        else if (collider.transform.tag == "Spike")
        {
            PlayerTakeDamage(2);
        }
        else if (collider.transform.tag == "Pickup")
        {
            audioSource.clip = pickupSound;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    public void PlayerTakeDamage(int amount)
    {
        PlayHitSound();
        float colorAmount = 1f - 0.6f*(playerHealth/100f);
        hitEffect.color = new Color (1,0,0,colorAmount);
        StopAllCoroutines();
        StartCoroutine(FadeOutHitEffect(colorAmount));
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    private void PlayHitSound()
    {
        int n = Random.Range(1, hitSounds.Length);
        audioSource.clip = hitSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        hitSounds[n] = hitSounds[0];
        hitSounds[0] = audioSource.clip;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator FadeOutHitEffect(float alpha)
    {
        while(true)
        {
            if(alpha > 0f)
            {
                alpha -= Time.deltaTime*2;
                hitEffect.color = new Color (1,1,1,alpha);
            }
            else
            {
                alpha = 0f;
                hitEffect.color = new Color (1,1,1,0);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

