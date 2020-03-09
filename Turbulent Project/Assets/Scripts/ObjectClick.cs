using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    private FocusPoint fS;

    private bool changePosition = false;
    public Vector3 defaultPosition;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickObject();
        }

        if (Input.GetMouseButtonDown(1))
        {            
            changePosition = false;
        }

        if (changePosition == true)
        {
            transform.position = Vector3.Lerp(transform.position, fS.whereToFocus, 0.05f);
        }

        if (changePosition == false)
        {
            transform.position = Vector3.Lerp(transform.position, defaultPosition, 0.05f);
        }
    }

    void ClickObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            var rig = hitInfo.collider;
                
            if (rig.CompareTag("Interactable"))
            {
                Debug.Log(rig.name + " clicked.");
                fS = rig.GetComponent<FocusPoint>();
                changePosition = true;
            }
        }
    }
}
