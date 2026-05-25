using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public UnityEngine.UI.Image spr;
    public Sprite yellow;
    public Sprite red;
    public Text number;
    public Text score;
    public void ChangeSprite()
    {
        if (MainSc.num % 2 == 1)
        { spr.sprite = yellow; }
        else 
        { spr.sprite = red; }

        number.text = MainSc.num.ToString();

        score.text = $"<b><color=yellow>{MainSc.scoreYellow}</color><color=white>:</color><color=red>{MainSc.scoreRed}</color></b>";
    }
}
