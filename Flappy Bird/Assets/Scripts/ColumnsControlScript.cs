using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsControlScript : MonoBehaviour
{

    public float velocity;
    void Start()
    {
        Destroy(gameObject, 5f); // Destroys the columns prefab after 5 seconds. The game is made efficient.
    }
    void FixedUpdate()
    {
        transform.position += velocity * Vector3.left *  Time.deltaTime; //We move our columns prefab. Columns prefab's location is right.
                                                                         //So we move the left. We give a velocity on Unity proporties.
                                                                         //Time.deltaTimeis working every frame.
    }
}
