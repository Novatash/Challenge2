using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyController : MonoBehaviour
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
            transform.Translate(Vector3.down * Time.deltaTime, Camera.main.transform);
        }
        if (right == 3)
        {
            transform.Translate(Vector3.up * Time.deltaTime, Camera.main.transform);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Reseter Up"))
        {
            right = 3;
        }
        if (collision.gameObject.CompareTag("Reseter Down"))
        {
            right = 2;
        }
    }
}
