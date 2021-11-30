using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 nextPoint;

    [SerializeField] private bool isValidPoint;
    [SerializeField] private int  positionList = 0;

    public static event Action onFinishMove;

    void Start()
    {
        nextPoint = transform.position;
        FloorController.onValidPoint += onValidPointHandler;
    }

    private void onValidPointHandler()
    {
        isValidPoint = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GroupController.indexPlayer == positionList) { 
            if (Input.GetMouseButtonDown(0) && canMove() && isValidPoint)
            {
                nextPoint = GetPositionTo(Input.mousePosition);
                StartCoroutine(moveUnity());
            
            }
        }
        /*
        if (!canMove())
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, 10f * Time.deltaTime);
        }
        */

    }

    void OnMouseOver()
    {

    }


    IEnumerator moveUnity()
    {
        while (transform.position != nextPoint)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, 10f * Time.deltaTime);
        }
        isValidPoint = false;
        onFinishMove?.Invoke();
    }
  

    private bool canMove()
    {
        return transform.position == nextPoint;
    }

    private Vector3 GetPositionTo(Vector3 newPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(newPosition);
        if (Physics.Raycast(ray, out hit))
        {
           return hit.point;
        }
        return Vector3.zero;
    }

    public void SetPositionList(int index)
    {
        positionList = index;
    }
}
