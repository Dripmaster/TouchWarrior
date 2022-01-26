using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconDisplay : MonoBehaviour
{
    public int imageId;
    Image image;
    bool isFliped;
    // Start is called before the first frame update
    void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        isFliped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        image.color = Color.white;
        GetComponentInParent<Animator>().SetTrigger("Create");
    }
    public void hide()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        image.color = new Color(0,0,0,0);
    }
    public void setImage(int i)
    {
        //generate effect Here
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        imageId = i;
        image.sprite =  GameManager.Instance.GetSprite(i);

    }

    public void fire()
    {
        //correct and disappear effect Here

        GetComponentInParent<Animator>().SetTrigger("Destroy");
    }
    public void flip(bool v,bool Forceanim = false)
    {
        if(v != isFliped || Forceanim)
            //StartCoroutine(flipAnim(v));
            GetComponentInParent<Animator>().SetTrigger("Flip");
        isFliped = v;
    }
    public void flipOk()
    {

        if (isFliped)
        {
            image.sprite = GameManager.Instance.GetQusetionSprite();
        }
        else
        {
            image.sprite = GameManager.Instance.GetSprite(imageId);
        }
    }
}
