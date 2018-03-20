using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeTouch : MonoBehaviour
{
    //public GameObject[] lamps;
    public GameObject[] boxCollider2D;

    public float speed;
    public Transform target;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    private void Start()
    {
        //boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }
   
    void Update ()
    {
        Touch();
	}

    private void FixedUpdate()
    {
        transform.RotateAround(target.position, zAxis, speed);
    }

    private void Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                foreach (var box in boxCollider2D)
                {
                    if (Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)) == box.GetComponent<BoxCollider2D>())
                    {
                        this.transform.position = new Vector3(touch.position.x, touch.position.y, transform.position.z);
                        //this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000 * Time.deltaTime, ForceMode2D.Force);
                        //this.transform.RotateAround(box.gameObject.transform.position, Vector3.right, 100 * Time.deltaTime);
                        box.gameObject.SetActive(false);
                    }
                }
            }
        }

        /*
        if(Input.GetMouseButtonDown(0))
        {

            Ray2D ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D raycastHit;

            if (Physics2D.Raycast(ray, out raycastHit))
            {
                Debug.Log("da" + Input.mousePosition);
                Debug.Log(raycastHit.collider.gameObject.name);
            }
        }*/
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(worldPos.x, worldPos.y);


            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                
                if (raycastHit.collider.gameObject.name == "GrassLeft")
                {
                    this.transform.position = Input.GetTouch(0).position;
                }
                /*
                if (raycastHit.collider.tag == "Lamp")
                {
                    this.transform.position = touchPos;
                }
            }
        }*/
    }
}
