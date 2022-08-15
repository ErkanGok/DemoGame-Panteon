using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public static int currentHealth = 3;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLenght = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public Text healthText;


    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;

        //thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                healthText.enabled = !healthText.enabled;
                flashCounter = flashLenght;
            }

            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
                healthText.enabled = true;
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            healthText.text = "Health : " + currentHealth;

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                thePlayer.KnockBack(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;
                healthText.enabled = false;

                flashCounter = flashLenght;
            }
        }
    }

    

    public void Respawn()
    {
        if (!isRespawning)
        {
            StartCoroutine("ResapwnCo");
        }

    }

    public IEnumerator ResapwnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        

        yield return new WaitForSeconds(respawnLength);

        isRespawning = false;
        thePlayer.gameObject.SetActive(true);

        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;
        healthText.text = "Health : " + currentHealth;

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        healthText.enabled = false;
        flashCounter = flashLenght;
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
