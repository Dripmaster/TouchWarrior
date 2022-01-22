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

    public void setImage(int i)
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        imageId = i;
        image.sprite =  GameManager.Instance.GetSprite(i);
        image.color = Color.yellow;
    }

    public void fire()
    {
        image.color = Color.white;
    }
    public void flip(bool v)
    {
        if(v != isFliped)
        StartCoroutine(flipAnim(v));
        isFliped = v;
    }
    IEnumerator flipAnim(bool v)
    {
        Vector3 tempScale = transform.localScale;
        int scaleDir = -1;
        do
        {
            yield return null;

            Vector3 targetScale = transform.localScale;
            targetScale.x += scaleDir * 0.1f * Time.deltaTime * 90f;
            transform.localScale = targetScale;
            if (transform.localScale.x <= 0f)
            {
                if (v)
                {
                    image.sprite = GameManager.Instance.GetQusetionSprite();
                }
                else
                {
                    image.sprite = GameManager.Instance.GetSprite(imageId);

                }
                scaleDir *= -1;
                break;
            }
        } while (true);

        do
        {
            yield return null;

            Vector3 targetScale = transform.localScale;
            targetScale.x += scaleDir * 0.1f * Time.deltaTime * 90f;
            transform.localScale = targetScale;
            if (transform.localScale.x >= 1f)
            {
                transform.localScale = tempScale;
                break;
            }
        } while (true);
    }
}
