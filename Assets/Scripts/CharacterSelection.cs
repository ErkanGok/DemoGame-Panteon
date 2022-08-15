using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{

    
    public Texture _firstCharacter;
    public Texture _secondCharacter;
    public Texture _thirdCharacter;

    public static int NumberTexture;

    public  SkinnedMeshRenderer CharacterMeshRenderer;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void firstCharacter()
    {
        CharacterMeshRenderer.material.mainTexture = _firstCharacter;
        this.gameObject.SetActive(false);
        NumberTexture = 1;

       
    }

    public void secondCharacter()
    {
        CharacterMeshRenderer.material.mainTexture = _secondCharacter;
        this.gameObject.SetActive(false);
        NumberTexture = 2;

        
    }

    public void thirdCharacter()
    {
        CharacterMeshRenderer.material.mainTexture = _thirdCharacter;
        this.gameObject.SetActive(false);
        NumberTexture = 3;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
