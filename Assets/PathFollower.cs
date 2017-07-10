using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MOVERTYPE
{
    MOVER,
    FOLLOWER,
}

public class PathFollower : MonoBehaviour {

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;

    public MOVERTYPE currType;

	void Start () {

        StartCoroutine(MoveStart());
	}
	
	void Update () {

        if (moveStart == true)
        {
            // Ease 방식 - 목적지에 가까울수록 느려짐
            //Vector3 dir = path[currentPoint].position - transform.position;
            //transform.position += dir * Time.deltaTime * speed;
            //if (dir.magnitude <= reachDist)
            //{
            //    currentPoint++;
            //}

            // linear 방식 - 방향만 정해서 움직이기
            float dist = Vector3.Distance(path[currentPoint].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);
            if (dist <= reachDist)
            {
                currentPoint++;
            }


            // 다 도착했으면 트레일 렌더러 HIDE
            if (currentPoint >= path.Length)
            {
                currentPoint = path.Length - 1;
            }
        }
	}

    bool moveStart = false;
    IEnumerator MoveStart()
    {
        if (currType == MOVERTYPE.FOLLOWER)
            yield return new WaitForSeconds(0.2f);
        else
            yield return new WaitForEndOfFrame();

        moveStart = true;
    }

    private void OnDrawGizmos()
    {
        if(path.Length > 0)
        for(int i = 0; i < path.Length; i++)
        {
            if(path[i] != null)
            {
                Gizmos.DrawSphere(path[i].position, reachDist);
            }
        }
    }
}
