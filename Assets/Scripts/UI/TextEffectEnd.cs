using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffectEnd : MonoBehaviour
{
    public Sprite[] Texts;
    Animator anim;
    Image image;

    public void setSprite(int v)
    {
        image.sprite = Texts[v];
    }
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();
        anim = GetComponent<Animator>();
        setSprite(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateEnd()
    {
        GameManager.Instance.startNext();
    }
    public void Create()
    {
        anim.SetTrigger("Create");
    }
}
