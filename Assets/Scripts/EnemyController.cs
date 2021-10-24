using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public BoxCollider2D rbl2;
    public int right;

    // Start is called before the first frame update
    void Start()
    {
        rbl2 = GetComponent<BoxCollider2D>();
        right = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (right == 2)
        {
            transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);
        }
        if (right == 3)
        {
            transform.Translate(Vector3.left * Time.deltaTime, Camera.main.transform);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Reseter Left"))
        {
            right = 3;
        }
        if (collision.gameObject.CompareTag("Reseter Right"))
        {
            right = 2;
        }
    }
}
