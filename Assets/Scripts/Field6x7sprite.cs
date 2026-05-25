using UnityEngine;
using UnityEngine.UI;

public class Field6x7sprite : MonoBehaviour
{
    public Image image;
    public SpriteRenderer fl;
    public Sprite fl1s;
    public Sprite fl2s;
    private void Start()
    {
        if (MainSc.fieldX == 7) 
        { image.enabled = true; fl.sprite = fl2s; }
        else { image.enabled = false; fl.sprite = fl1s; }
    }
}
