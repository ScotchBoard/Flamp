using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(worldPos.x, worldPos.y);

            if (boxCollider2D == Physics2D.OverlapPoint(touchPos))
            {
                player.transform.position = touchPos;
                //Do stuff with it here like check gameObject tags and such.
            }
        }
    }
}
