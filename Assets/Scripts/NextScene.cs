using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject FinalSahne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        FinalSahne.SetActive(false);
        SceneManager.LoadScene(0);

    }

    private void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (other.tag == "Player" && sceneName == "Level1")
        {
            SceneManager.LoadScene(2);
        }

        if (sceneName == "Level2")
        {
            FinalSahne.SetActive(true);
        }
    }
}
