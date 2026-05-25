using System.Collections;
using UnityEngine;

public class Fishka : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Anim(transform.position.x, transform.position.y));
    }
    IEnumerator Anim(float endX, float endY)
    {
        transform.position = new Vector3(transform.position.x, 2.7f, 1);
        for (float y = transform.position.y; y > endY; y -= 0.5f)
        {
            transform.position = new Vector3(transform.position.x, y, 1);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(endX, endY, 1);
    }
}
