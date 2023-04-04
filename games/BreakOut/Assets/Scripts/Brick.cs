using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.BlockDestroyed(this.gameObject);
        Destroy(this.gameObject, 0f);
    }
}
