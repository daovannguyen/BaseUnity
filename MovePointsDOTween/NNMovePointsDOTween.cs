using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using UnityEngine;
using DG.Tweening;

public class NNMovePointsDOTween : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();
    public GameObject PointParent;
    public float Speed;
    private int CurrentIndexPoints = 0;
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
        DoMoveToPoint(CurrentIndexPoints);
        GetAngleToPoint(CurrentIndexPoints);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Points[CurrentIndexPoints].position) < 0.2f)
        {
            CurrentIndexPoints++;
            if (CurrentIndexPoints >= Points.Count)
            {
                CurrentIndexPoints = 0;
            }

            DoMoveToPoint(CurrentIndexPoints);
            GetAngleToPoint(CurrentIndexPoints);
        }
        //transform.position = Vector3.MoveTowards(transform.position, Points[CurrentIndexPoints].position, Speed * Time.deltaTime);
    }

    private float GetTimeMove(Vector3 start, Vector3 target, float speed)
    {
        return Vector3.Distance(start, target) / speed;
    }

    private void DoMoveToPoint(int index)
    {
        transform.DOMove(Points[index].position,
            GetTimeMove(transform.position, Points[index].position, Speed));
    }

    private void GetAngleToPoint(int index)
    {
        Vector3 dir = Points[index].position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
