using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Waypoint> paths = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    
    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void FindPath() {
        paths.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path"); 
        foreach(Transform child in parent.transform) {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null) paths.Add(waypoint);
        }
    }

    void ReturnToStart() {
        transform.position = paths[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint way in paths) {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = way.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while(travelPercent < 1) {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath() {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
