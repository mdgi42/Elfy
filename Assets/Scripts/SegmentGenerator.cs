using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegementGenerator : MonoBehaviour
{
    public GameObject[] segment;
    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    //public int numberOfTiles = 10;


    void Update()
    {
        if (creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }

    }

    IEnumerator SegmentGen()
    {
        //for (int i = 0; i < numberOfTiles; i++)
        //{
            segmentNum = Random.Range(0, 3);
            Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 50;
            yield return new WaitForSeconds(3);
            creatingSegment = false;
        //}
    }

}

