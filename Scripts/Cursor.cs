using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public static GameObject cleckedObject;
    public static Vector3 cursorPosition;

    Ray ray;
    RaycastHit hit;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            cursorPosition = Constants.getGroundedVector3(hit.point);
            hit.collider.gameObject.SendMessage("RespondOnClick", SendMessageOptions.DontRequireReceiver);
            print(hit.collider.name);
        }
    }
}
