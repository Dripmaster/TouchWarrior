using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffectEnd : MonoBehaviour
{
    public Sprite[] Texts;
    Animator anim;
    public Image image;
    public bool onDisble;
    public void setSprite(int v)
    {
        image.sprite = Texts[v];
        image.SetNativeSize();
    }
    private void Awake()
    {

        if (
        image == null)
            image = GetComponentInChildren<Image>();
        anim = GetComponent<Animator>();
        setSprite(0);
        if (onDisble)
            gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateEndX()
    {
        gameObject.SetActive(false);
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
