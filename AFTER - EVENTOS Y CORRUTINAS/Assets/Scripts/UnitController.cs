using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Debug.Log(GetPositionTo(Input.mousePosition));
           //transform.position = Vector3.MoveTowards(transform.position, GetPositionTo(Input.mousePosition), 10f * Time.deltaTime);
        }
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
}
