using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplitViewMenu : MonoBehaviour
{

    public Animator animator;
    public Canvas[] content;
    public GameObject[] indicators;

    private void Start()
    {       
        if(!PlayerPrefs.HasKey("mode"))
        {
            PlayerPrefs.SetInt("mode", 0);
        }
        indicators[PlayerPrefs.GetInt("mode")].SetActive(true);
    }


    public void Click(int mode)
    {
        PlayerPrefs.SetInt("mode", mode);
        for(int i = 0; i < content.Length; i++)
        {
            //canvas change
            content[i].enabled = mode == i ? true : false;

            //scene change
            //SceneManager.LoadScene(mode);

            indicators[i].SetActive(mode == i ? true : false);
        }
        animator.SetInteger("state", 2);
    }

    public void HamburgerClick()
    {
        animator.SetInteger("state", animator.GetInteger("state") == 1 ? 2 : 1);
    }
}
