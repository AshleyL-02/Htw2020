using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * forces shadow to appear -0.1f below parent
 */

public class CherryBlossomShadowUI : MonoBehaviour
{
    private static readonly float SHADOW_HEIGHT = -0.05f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 parentTransform = this.transform.parent.position;
        this.transform.position = new Vector3(parentTransform.x, parentTransform.y +SHADOW_HEIGHT, parentTransform.z);
    }
}
