using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{
    public Vector3 Velocity;
    public float speed;
    public int CurrentWaypoint;
    public List<Transform> Waypoints;
    private Vector3 target;
    private Vector3 movedirection;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(CurrentWaypoint)
        {
            case 0:
                target = Waypoints[CurrentWaypoint].position;
                movedirection = target - transform.position;
                movedirection = movedirection.normalized;
                dir = movedirection;
                GetComponent<Rigidbody>().velocity = new Vector3(movedirection.x * speed * Time.deltaTime, 0, movedirection.z * speed * Time.deltaTime);
              // GetComponent<Rigidbody>().velocity  = movedirection * speed * Time.deltaTime;
                transform.LookAt(Waypoints[CurrentWaypoint].position);
                break;
            case 1:
                transform.LookAt(Waypoints[CurrentWaypoint].position);
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
                dir = transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.05f);
                break;
            case 2:
                transform.LookAt(Waypoints[CurrentWaypoint].position);
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
                dir = transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.05f);
                break;
            case 3:
                transform.LookAt(Waypoints[CurrentWaypoint].position);
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
                dir = transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, Time.deltaTime * speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.05f);
                break;
        }
    }


}
