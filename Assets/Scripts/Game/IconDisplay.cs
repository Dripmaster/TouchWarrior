using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconDisplay : MonoBehaviour
{
    public int imageId;
    Image image;
    bool isFliped;
    public Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        isFliped = false;
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show()
    {

        transform.parent.gameObject.SetActive(true);
        isFliped = false;
    }
    public void hide()
    {
        if (!transform.parent.gameObject.activeInHierarchy)
            return;

        anim.SetTrigger("Destroy");
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
        GetComponentInParent<GameBtn>().isFlipcorrect = true;
        flip(true);
    }
    public void flip(bool v,bool Forceanim = false)
    {
        if(v != isFliped || Forceanim)
            //StartCoroutine(flipAnim(v));
            anim.SetTrigger("Flip");
        isFliped = v;
    }
    public void flipOk(bool isf)
    {

        if (isFliped)
        {
            if (isf)
            {
                image.sprite = GameManager.Instance.GetBackSprite();
                GameManager.Instance.checkNext();
            }
            else
            {

                image.sprite = GameManager.Instance.GetQusetionSprite();
            }
        }
        else
        {
            image.sprite = GameManager.Instance.GetSprite(imageId);
        }
    }
}
