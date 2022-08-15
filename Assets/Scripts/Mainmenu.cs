using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{

    public static int OpponentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SinglePlayer()
    {
        OpponentCharacter = 0;
        SceneManager.LoadScene(1);
    }

    public void ApplicationExit()
    {
        Application.Quit();
        
    }

    public static void _OpponentCharacter()
    {
        OpponentCharacter = 1;
        SceneManager.LoadScene(1);
    }
}
