using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using UnityEngine;
using DG.Tweening;

public class NNMovePoints : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public GameObject PointParent;
    public float Speed;
    private int TargetIndexPoints = 0;
    private void OnValidate()
    {
        if (Points.Count == 0)
        {
            Points = PointParent.GetComponentsInChildren<Transform>().ToList();
            Points.RemoveAt(0);
        }
    }

    private void Awake()
    {
        GetAngleToPoint(TargetIndexPoints);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Points[TargetIndexPoints].position) < 0.2f)
        {
            TargetIndexPoints++;
            if (TargetIndexPoints >= Points.Count)
            {
                TargetIndexPoints = 0;
            }
            GetAngleToPoint(TargetIndexPoints);
        }

        MoveToPoint(TargetIndexPoints);
    }

    private float GetTimeMove(Vector3 start, Vector3 target, float speed)
    {
        return Vector3.Distance(start, target) / speed;
    }

    private void MoveToPoint(int index)
    {
        transform.position = Vector3.MoveTowards(transform.position, Points[index].position, Speed * Time.deltaTime);
    }

    private void GetAngleToPoint(int index)
    {
        Vector3 dir = Points[index].position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
