using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Edge : MonoBehaviour
{
    public Vector2 center = Vector2.zero;
    public float radius = 5f;
    [SerializeField]
    [Range(36f, 360f)]
    public int density = 36;
    public float max_offset = 1f;
    [SerializeField]
    [Range(0.1f, 5f)]
    public float speed = 3f;

    private List<Vector3> Nodes_v3;
    private List<Vector2> Nodes_v2;

    private List<Vector3> Nodes_v3_dynamic;
    private List<Vector2> Nodes_v2_dynamic;

    private LineRenderer lineRenderer_static;
    private LineRenderer lineRenderer_dynamic;
    private EdgeCollider2D edgeCollider;

    private float vel;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer_static = GetComponent<LineRenderer>();
        lineRenderer_dynamic = transform.GetChild(0).GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        Nodes_v3 = new List<Vector3>();
        Nodes_v2 = new List<Vector2>();

        Nodes_v3_dynamic = new List<Vector3>();
        Nodes_v2_dynamic = new List<Vector2>();

        float angle = 360 / density;

        for(int i = 0; i < density; i++)
        {
            Nodes_v3.Add(new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * radius, Mathf.Sin(angle * Mathf.Deg2Rad * i) * radius, 0f));
            Nodes_v2.Add(new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * radius, Mathf.Sin(angle * Mathf.Deg2Rad * i) * radius));
            Nodes_v3_dynamic.Add(new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * radius, Mathf.Sin(angle * Mathf.Deg2Rad * i) * radius, 0f));
            Nodes_v2_dynamic.Add(new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * radius, Mathf.Sin(angle * Mathf.Deg2Rad * i) * radius));
        }

        Nodes_v3.Add(Nodes_v3[0]);
        Nodes_v2.Add(Nodes_v2[0]);
        Nodes_v3_dynamic.Add(Nodes_v3[0]);
        Nodes_v2_dynamic.Add(Nodes_v3[0]);
        
        lineRenderer_static.positionCount = density;
        lineRenderer_static.SetPositions(Nodes_v3.ToArray());

        lineRenderer_dynamic.positionCount = density;
        lineRenderer_dynamic.SetPositions(Nodes_v3_dynamic.ToArray());

        edgeCollider.SetPoints(Nodes_v2);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNodes(AudioManager.instance.GetMax());
    }

    void UpdateNodes(float samples)
    {
        float angle = 360 / density;
        float length, target;

        length = math.remap(0f, 0.21f, 0f, 1f, samples) * max_offset;
        target = radius + length;
        offset = Mathf.SmoothDamp(offset, target, ref vel, speed);

        for (int i = 0; i <= density; i++)
        {
            Nodes_v3[i] = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * radius, Mathf.Sin(angle * Mathf.Deg2Rad * i) * radius, 0f);
            Nodes_v2[i] = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * radius, Mathf.Sin(angle * Mathf.Deg2Rad * i) * radius);

            Nodes_v3_dynamic[i] = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * offset, Mathf.Sin(angle * Mathf.Deg2Rad * i) * offset, 0f);
            Nodes_v2_dynamic[i] = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * i) * offset, Mathf.Sin(angle * Mathf.Deg2Rad * i) * offset);
        }

        lineRenderer_static.SetPositions(Nodes_v3.ToArray());
        lineRenderer_dynamic.SetPositions(Nodes_v3_dynamic.ToArray());
        edgeCollider.SetPoints(Nodes_v2);
    }
}
