using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPositon = transform.position;
        newPositon.x = player.transform.position.x;
        newPositon.y = player.transform.position.y;
        transform.position = newPositon;
    }
}
