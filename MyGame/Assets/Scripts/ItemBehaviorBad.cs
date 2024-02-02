using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviorBad : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("The gods hate you. You died!");
        }
    }
}

