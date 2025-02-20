using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;
    public Transform playerTransform;
    public float parentPos;

    void Update()
    {
        parentName = transform.name;
        parentPos = transform.position.z;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(10);
        if (parentName == "Segment(Clone)" && playerTransform.position.z > (parentPos + 50))
        {
            //yield return new WaitForSeconds(20);
            Destroy(gameObject);
        }
    }
}
