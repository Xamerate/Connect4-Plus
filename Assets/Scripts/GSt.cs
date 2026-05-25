using UnityEngine;

public class GSt : MonoBehaviour
{
    public Darkness darkness;
    public MenuB buttons;
    void Start()
    {
        MainSc.canAct = true;
        buttons.STATE = 2;
        darkness.FadeOut();
    }
}
