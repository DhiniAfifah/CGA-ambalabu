using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject optionMenu;
    private GameObject loading;

    public AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = GameObject.Find("MainMenuCanvas");
        optionMenu = GameObject.Find("OptionCanvas");
        loading = GameObject.Find("LoadingCanvas");

        mainMenu.GetComponent<Canvas>().enabled = true;
        optionMenu.GetComponent<Canvas>().enabled = false;
        loading.GetComponent<Canvas>().enabled = false;
    }

    public void StartBtn()
    {
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        buttonSound.Play();
        SceneManager.LoadScene("testing");
    }

    public void OptionBtn()
    {
        buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = false;
        optionMenu.GetComponent <Canvas>().enabled = true;
    }

    public void ExitBtn()
    {
        buttonSound.Play();
        Application.Quit();
    }

    public void ReturnToMainMenuBtn()
    {
        buttonSound.Play();
        mainMenu.GetComponent <Canvas>().enabled = true;
        optionMenu.GetComponent< Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
