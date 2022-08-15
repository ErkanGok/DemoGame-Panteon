using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHealthManager : MonoBehaviour
{
    public int maxHealth;
    public  int currentHealth = 3;

    public NPCController theNpc;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLenght = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

 


    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;

        //thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = theNpc.transform.position;
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
                
                flashCounter = flashLenght;
            }

            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
                
            }
        }
    }

    public void HurtNPC(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;
           

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                theNpc.KnockBack(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;
               

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
        theNpc.gameObject.SetActive(false);
        

        yield return new WaitForSeconds(respawnLength);

        isRespawning = false;
        theNpc.gameObject.SetActive(true);

        theNpc.transform.position = respawnPoint;
        currentHealth = maxHealth;
       

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        
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
