using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Animator openAnim;


    public void SetButtonSet(int i)
    {
        PlayerPrefs.SetInt("ButtonSets",i);
    }
    public void Btn_Classic()
    {

    }
    public void Btn_Challenge()
    {

    }
    public void Btn_Open()
    {
        openAnim.SetTrigger("Open");
    }
    public void Btn_Title()
    {
        SceneManager.LoadScene(0);
    }
    public void Btn_Shop()
    {
        SceneManager.LoadScene(2);

    }
    public void Btn_Collection()
    {
        SceneManager.LoadScene(3);
    }
    public void Btn_StartClassic()
    {

        SceneManager.LoadScene(4);
    }
    public void Btn_StartChallenge()
    {
        
    }

}
