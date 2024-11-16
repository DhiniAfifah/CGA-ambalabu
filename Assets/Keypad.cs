using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadObj;
    public GameObject hud;
    public GameObject inv;

    public GameObject animateObj;
    public Animator anim;

    public TMP_Text textObj;
    public string answer = "12345";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public bool animate;

    // Start is called before the first frame update
    void Start()
    {
        keypadObj.SetActive(false);
    }

    public void Number(int number)
    {
        textObj.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textObj.text == answer)
        {
            correct.Play();
            textObj.text = "Bener";
        } else
        {
            wrong.Play();
            textObj.text = "Salah";
        }
    }

    public void Clear()
    {
        {
            textObj.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keypadObj.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (textObj.text == "Right" && animate)
        {
            anim.SetBool("animate", true);
        }

        if (keypadObj.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
