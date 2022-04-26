using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _blockTemplate;
    [SerializeField] private GameObject _halfBlockTemplate;
    [SerializeField] private GameObject _finishTemplate;

    [SerializeField] private int _towerSize;

    private void Awake()
    {
        GameObject obj = gameObject;

        for(int i = 0; i < _towerSize; i++)
        {
            obj = CreateSegment(obj, _blockTemplate);
            obj = CreateSegment(obj, _halfBlockTemplate);
        }

        CreateSegment(obj, _finishTemplate);
    }

    private GameObject CreateSegment(GameObject currentPoint, GameObject segment)
    {
        var yPos = currentPoint.transform.position.y + segment.transform.localScale.y / 2 + currentPoint.transform.localScale.y / 2;
        var pos = new Vector3(currentPoint.transform.position.x, yPos, currentPoint.transform.position.z);
        return Instantiate(segment, pos, Quaternion.identity, transform);
    }
}
