using System.Collections.Generic;
using UnityEngine;

public class MainSc : MonoBehaviour
{
    static List<FS> yellow = new List<FS>();
    static List<FS> red = new List<FS>();
    public static int fieldX = 9;
    public static int fieldY = 8;
    static public int scoreYellow = 0;
    static public int scoreRed = 0;
    static public int scoreToWin = 1;
    static public int num = 1;
    static public bool canAct = true;
    public Object gm;
    public Object gm2;
    public Indicator ind;
    public Win win;
    public Line line;

    private void Start()
    {
        num = 1;
        yellow.Clear();
        red.Clear();
        ind.ChangeSprite();
    }
    private int CheckField(int x, int y)
    {
        if (yellow.Count > 0)
        {
            for (int i = 0; i < yellow.Count; i++)
            {
                if (yellow[i].X == x & yellow[i].Y == y)
                {
                    return 1;
                }
            }
        }
        if (red.Count > 0)
        {
            for (int i = 0; i < red.Count; i++)
            {
                if (red[i].X == x & red[i].Y == y)
                {
                    return 2;
                }
            }
        }
        return 0;
    }
    public void Act(int theX)
    {
        int x = theX - 1;
        int y = 8 - fieldY;
        bool d = false;
        for (int i = 8 - fieldY; i < 8; i++)
        {
            if (CheckField(x - 1, y) != 0) { y += 1; }
            else { i = 999; }
        }
        if (y < 8)
        {
            if (num % 2 == 0) { red.Add(new FS(x - 1, y)); }
            else { yellow.Add(new FS(x - 1, y)); }
            num += 1;
            ind.ChangeSprite();
            if (num % 2 == 0)
            { Instantiate(gm, new Vector3(-3.95f + 0.95f * x, -3.95f + 0.95f * y, 1), new Quaternion()); }
            else
            { Instantiate(gm2, new Vector3(-3.95f + 0.95f * x, -3.95f + 0.95f * y, 1), new Quaternion()); }
            ChekProgr(yellow, 1);
            ChekProgr(red, 2);
        }
    }
    private void ChekProgr(List<FS> obj, int k)
    {
        int COUNT;
        if (obj.Count > 0)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                COUNT = 0;

                int x1 = 0; int x2 = 0;
                int y1 = 0; int y2 = 0;

                x1 = obj[i].X; x2 = obj[i].X + 3; y1 = obj[i].Y; y2 = obj[i].Y;
                for (int g = 1; g <= 3; g++) //  -
                {
                    if (CheckField(obj[i].X + g, obj[i].Y) == k) { COUNT += 1; }
                    if (COUNT > 2) { Debug.Log($"Победа! Code: {k}"); win.G(k); line.Show(x1, x2, y1, y2, 1); }
                }

                x1 = obj[i].X; x2 = obj[i].X + 3; y1 = obj[i].Y; y2 = obj[i].Y + 3;
                COUNT = 0;
                for (int g = 1; g <= 3; g++) //  /
                {
                    if (CheckField(obj[i].X + g, obj[i].Y + g) == k) { COUNT += 1; }
                    if (COUNT > 2) { Debug.Log($"Победа! Code: {k}"); win.G(k); line.Show(x1, x2, y1, y2, 2); }
                }

                x1 = obj[i].X; x2 = obj[i].X; y1 = obj[i].Y; y2 = obj[i].Y + 3;
                COUNT = 0;
                for (int g = 1; g <= 3; g++) //  |
                {
                    if (CheckField(obj[i].X, obj[i].Y + g) == k) { COUNT += 1; }
                    if (COUNT > 2) { Debug.Log($"Победа! Code: {k}"); win.G(k); line.Show(x1, x2, y1, y2, 3); }
                }

                x1 = obj[i].X; x2 = obj[i].X - 3; y1 = obj[i].Y; y2 = obj[i].Y + 3;
                COUNT = 0;
                for (int g = 1; g <= 3; g++) //  \
                {
                    if (CheckField(obj[i].X - g, obj[i].Y + g) == k) { COUNT += 1; }
                    if (COUNT > 2) { Debug.Log($"Победа! Code: {k}"); win.G(k); line.Show(x1, x2, y1, y2, 4); }
                }
            }
        }
    }
}
