using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsMove : MonoBehaviour
{
    public PlayerControlManager player; // We access the componenet on PlayerControlManager.
    public GameObject columns;
    public float heightTop,heightBottom; // I have defined two public variables for our field boundaries.
                                         // We use this to determine the range in which colons will be created.
    void Start()
    {
        StartCoroutine(CopyColumns()); // We started IEnumerator
    }
    public IEnumerator CopyColumns()
    {
        while (player.Death==false)
        {
            yield return new WaitForSeconds(2f); // Unity produce columns prefab every 2 seconds.
            Instantiate(columns, new Vector3(4.7f, Random.Range(heightTop, heightBottom), 0), Quaternion.identity);
            // We  specify clon the prefab. Its name is columns. 
            //We add new location on the scene. heigt is defined by hand on the Unity.
            //We add Queternion class. Quaternion.identity columns is constant.

        }
    }
}
