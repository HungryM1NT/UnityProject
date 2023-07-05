using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic = false;
    public float offset = 0;
    private int sortingOrderBase = 0;
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        //renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y + offset);
        if ((transform.position.y - (int)(transform.position.y)) > 0.5)
            renderer.sortingOrder = -3;
        else
            renderer.sortingOrder = 1;

        if (isStatic)
            Destroy(this);
    }
}
