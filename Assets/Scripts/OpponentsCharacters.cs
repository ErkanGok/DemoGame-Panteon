using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentsCharacters : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject Player;
    public Texture[] CharacterTexture;
    public GameObject Parent;
    public GameObject[] OpponentCharacters;
    public Text Order;
    private int j = 1;
    
    private int temp;

    public bool isGo;


    // Start is called before the first frame update
    void Start()
    {
        

        OpponentCharacters = new GameObject[10];
       
        temp = Mainmenu.OpponentCharacter;
        if (temp == 0)
        {
            Parent.SetActive(false);
        }

        for (var i = 1; i < 10; i++)
        {
            if (i <= 4)
            {
                prefab2 = (GameObject)Instantiate(prefab, new Vector3(prefab3.transform.position.x - (3 * i), prefab3.transform.position.y, prefab3.transform.position.z), Quaternion.identity);
            }

            if (i > 4)
            {
                prefab2 = (GameObject)Instantiate(prefab, new Vector3(7.45f - (j * 3), prefab3.transform.position.y, prefab3.transform.position.z - 3), Quaternion.identity);
                j++;
            }
            OpponentCharacters[i] = prefab2;
            isGo = true;
            prefab2.transform.SetParent(Parent.transform);

            prefab2.AddComponent<MeshCollider>().convex = true;
            prefab2.AddComponent<BoxCollider>().isTrigger = true;

            prefab2.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture = CharacterTexture[i];
            prefab2.AddComponent<HurtPlayer>().DamageToGive = 0;
            prefab2.AddComponent<NPCHealthManager>();
            prefab2.GetComponent<NPCHealthManager>().maxHealth = 3;
            prefab2.GetComponent<NPCHealthManager>().theNpc = prefab2.GetComponent<NPCController>();
            prefab2.GetComponent<NPCHealthManager>().invincibilityLength = 1;
            prefab2.GetComponent<NPCHealthManager>().playerRenderer = prefab2.GetComponentInChildren<SkinnedMeshRenderer>();
            prefab2.GetComponent<NPCHealthManager>().flashLenght = 0.1f;
            prefab2.GetComponent<NPCHealthManager>().respawnLength = 0.4f;

        }
    }



    // Update is called once per frame
    void Update()
    {

        ///for ranking......
        if (isGo)
        {
            //player local is always 0...
            int rank = 1;
            float z_local1 = Player.transform.position.z;
            float z_player1 = OpponentCharacters[1].transform.position.z;
            float z_player2 = OpponentCharacters[2].transform.position.z;
            float z_player3 = OpponentCharacters[3].transform.position.z;
            float z_player4 = OpponentCharacters[4].transform.position.z;
            float z_player5 = OpponentCharacters[5].transform.position.z;
            float z_player6 = OpponentCharacters[6].transform.position.z;
            float z_player7 = OpponentCharacters[7].transform.position.z;
            float z_player8 = OpponentCharacters[8].transform.position.z;
            float z_player9 = OpponentCharacters[9].transform.position.z;

            if (z_local1 < z_player1)
            {
                rank++;
            }
            if (z_local1 < z_player2)
            {
                rank++;
            }
            if (z_local1 < z_player3)
            {
                rank++;
            }
            if (z_local1 < z_player4)
            {
                rank++;
            }
            if (z_local1 < z_player5)
            {
                rank++;
            }
            if (z_local1 < z_player6)
            {
                rank++;
            }
            if (z_local1 < z_player7)
            {
                rank++;
            }
            if (z_local1 < z_player8)
            {
                rank++;
            }
            if (z_local1 < z_player9)
            {
                rank++;
            }

            //=============================================
           

           

            Order.text = "Order : " + rank;
        }





        //if (Player.transform.position.z > OpponentCharacters[1].transform.position.z && Kademe == 0)
        //{
        //    Kademe = 1;
        //    OrderSayac += Kademe;           
        //}       

        //else if (Player.transform.position.z < OpponentCharacters[1].transform.position.z && Kademe == 0)
        //{
        //    Kademe = 1;
        //    OrderSayac -= Kademe;

        //}


        //Kademe = 0;







       

    }
}
