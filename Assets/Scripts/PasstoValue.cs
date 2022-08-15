using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PasstoValue : MonoBehaviour
{


    public Text goldText;
    public Text HealthText;
    public Texture _firstCharacter;
    public Texture _secondCharacter;
    public Texture _thirdCharacter;
    public SkinnedMeshRenderer CharacterMeshRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        

        goldText.text = "Gold : " + GameManager.currentGold;
        HealthText.text = "Health : " + HealthManager.currentHealth;
        
        if (CharacterSelection.NumberTexture == 1)
        {
            CharacterMeshRenderer.material.mainTexture = _firstCharacter;
        }
        if (CharacterSelection.NumberTexture == 2)
        {
            CharacterMeshRenderer.material.mainTexture = _secondCharacter;
        }
        if (CharacterSelection.NumberTexture == 3)
        {
            CharacterMeshRenderer.material.mainTexture = _thirdCharacter;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
