using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MoveCtrl : MonoBehaviour {

    private Transform tr;
    Transform tempT;

    private Vector3[] paths = new Vector3[] { new Vector3(-8, 4, 0), new Vector3(-4, -4, 0), new Vector3(0, 4, 0), new Vector3(4, -4, 0), new Vector3(8, 4, 0)};
    public float moveSpeed = 1f;

	// Use this for initialization
	void Start () {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

        tr = GetComponent<Transform>();

        //tr.position = new Vector3(-8.0f, 4.0f, 0f);
    }

    // Update is called once per frame
    bool moveStart = false;
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            moveStart = true;
        }

        if (moveStart == true)
        {
            
            //tr.Translate(paths[1] * Time.deltaTime * moveSpeed, Space.World);
            tr.position = paths[1] * Time.deltaTime * moveSpeed;

            //tr.DOMove(paths[1], 1).SetRelative().SetLoops(-1, LoopType.Yoyo);
        }
    }

    public Vector3 LocalToGlobalTransVector(Vector3 v)
    {
        //0기준으로 벡터 크기가 글로벌 크기로 얼마인지를 반환 ..
        tempT.localPosition = v;
        return tempT.position;
    }


    public Vector3 GlobalToLocalTransVector(Vector3 v)
    {
        //0기준으로 벡터 크기가 글로벌 크기로 얼마인지를 반환 ..
        tempT.position = v;
        return tempT.localPosition;
    }
    
}
