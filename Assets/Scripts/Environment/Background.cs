using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public int size;
    public float plane_size;
    public GameObject plane_prefab;

    List<GameObject> planes;
    // Start is called before the first frame update
    void Start()
    {
        planes = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                planes.Add(Instantiate(plane_prefab, new Vector3(-size / 2 * plane_size + plane_size * j, -size / 2 * plane_size + plane_size * i, 0), Quaternion.identity));
                planes[planes.Count - 1].transform.parent = gameObject.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
