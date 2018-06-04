using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehaviour : MonoBehaviour {
    private Rigidbody tongue;
    public float tongueSpeed;
    public float tongueThickness;
    public float minWaitingPeriod;
    public float maxWaitingPeriod;
    private Vector3 offset;
    private Vector2 screenBounds;
    private bool hasReachedTheLimit = false;

    // Use this for initialization
    void Start() {
        tongue = GetComponent<Rigidbody>();
        offset = new Vector3(tongueSpeed, 0);
        transform.localScale = new Vector3(0, tongueThickness);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


    }

    private bool isCoroutineExecuting = false;

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        if (!hasReachedTheLimit)
        {
            tongue.transform.localScale += offset;
        }
        else
        {
            tongue.transform.localScale -= offset;
        }
        if (tongue.transform.localScale.x >= screenBounds.x * 4)
        {
            hasReachedTheLimit = true;
            yield return new WaitForSeconds(time);
        }
        if (tongue.transform.localScale.x <= 0)
        {
            hasReachedTheLimit = false;
            yield return new WaitForSeconds(time);
        }

        isCoroutineExecuting = false;
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(ExecuteAfterTime(Random.Range(minWaitingPeriod, maxWaitingPeriod)));
    }

    void OnTriggerEnter(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "Furniture")
        {
            hasReachedTheLimit = true;
        }
    }
}

