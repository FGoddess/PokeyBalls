using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawner : MonoBehaviour
{
    public void Initialize(List<Block> blocks)
    {
        GameObject obj = gameObject;

        foreach(var block in blocks)
        {
            obj = CreateSegment(obj, block.gameObject);
        }
    }

    private GameObject CreateSegment(GameObject currentPoint, GameObject segment)
    {
        var yPos = currentPoint.transform.position.y + segment.transform.localScale.y / 2 + currentPoint.transform.localScale.y / 2;
        var pos = new Vector3(currentPoint.transform.position.x, yPos, currentPoint.transform.position.z);
        return Instantiate(segment, pos, Quaternion.identity, transform);
    }
}
