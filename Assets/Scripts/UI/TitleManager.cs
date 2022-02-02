using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Animator openAnim;
    public bool isFirst;

    private void Awake()
    {
        if(isFirst)
        SoundManager.Instance.playBGM(0);
    }

 
    public void Btn_Classic()
    {

        SoundManager.Instance.playOneShot(8);
    }
    public void Btn_Challenge()
    {

        SoundManager.Instance.playOneShot(8);
    }
    public void Btn_Title()
    {
        SoundManager.Instance.playOneShot(8);
        SceneManager.LoadScene(0);
    }
    public void Btn_Shop()
    {
        SoundManager.Instance.playOneShot(8);
        SceneManager.LoadScene(2);

    }
    public void Btn_Collection()
    {
        SoundManager.Instance.playOneShot(8);
        SceneManager.LoadScene(3);
    }
    public void Btn_StartClassic()
    {

        SoundManager.Instance.playOneShot(8);
        SceneManager.LoadScene(4);
    }
    public void Btn_StartChallenge()
    {
        SoundManager.Instance.playOneShot(8);

    }

}
