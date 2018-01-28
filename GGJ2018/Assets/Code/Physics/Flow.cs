using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Flow : MonoBehaviour
{
    public Vector3 direction;

    public FlowData data;

    public int id;
    private FlowDirector _director;
    private FlowDirector Director
    {
        get
        {
            if (!_director)
                _director = FlowDirector.Instance;
            return _director;
        }
    }

    public Flow prev;
    public List<Flow> next = new List<Flow>();
    private CircleCollider2D _collider;

    //--------------------------------------------------------


    private void Awake()
    {
        RefreshCollider();
    }

    private void OnValidate()
    {
        _collider = GetComponent<CircleCollider2D>();
        RefreshCollider();
        Recalculate();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        var cell = other.GetComponent<Cell>();
        if (cell)
        {
            cell.AddForce(direction.normalized * data.strength); //TODO add rolloff
        }
    }

    private void RefreshCollider()
    {
        _collider.radius = data.effectRadius;
    }

    private void Recalculate()
    {
        if (next.Count > 0)
        {
            var sum = Vector3.zero;
            foreach (var flow in next)
            {
                sum += (flow.transform.position - transform.position);
            }
            direction = sum.normalized;
        }
        else
        {
            direction = direction.normalized;
        }
    }

    //--------------------------------------------------------

    void OnDrawGizmos()
    {
        // Draw effect radius.
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        if (Director.end.Equals(this))
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);
        }
        Gizmos.DrawSphere(transform.position, data.effectRadius);

        // Draw force vector.
        Recalculate();
        Gizmos.color = new Color(0, 0, data.strength / 10f, 1f);
        Gizmos.DrawLine(transform.position, transform.position + direction.normalized * data.effectRadius);
    }


    [ContextMenu("Spawn Flow")]
    public void SpawnFlow()
    {
        var go = Instantiate(Director.prefab);
        var flow = go.GetComponent<Flow>();
        flow.id = Director.iter;

        go.name = "Flow" + Director.iter + " (parent = Flow" + id + ")";
        go.transform.position = transform.position + direction.normalized * data.effectRadius * 1.5f;
        go.transform.parent = transform.parent;

        flow.direction = direction;
        flow.prev = this;
        next.Add(flow);
        Director.Add(this, flow);

#if UNITY_EDITOR
        UnityEditor.Selection.SetActiveObjectWithContext(gameObject, null);
        UnityEditor.Selection.activeGameObject = gameObject;
#endif

        Recalculate();
    }

    [ContextMenu("Remove Flow")]
    public void RemoveFlow()
    {
        Director.Remove(this);
        prev.next.Remove(this);

        foreach (var flow in next)
        {
            flow.prev = prev;
            prev.next.Add(flow);
        }

        DestroyImmediate(gameObject);
    }
}
