using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{


    public void Btn_Classic()
    {

    }
    public void Btn_Challenge()
    {

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
