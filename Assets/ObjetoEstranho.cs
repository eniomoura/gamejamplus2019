using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEstranho : MonoBehaviour
{
    public GameObject player;
    Transform translate;
    
    void Start()
    {
        translate = player.GetComponent<Transform>();
        print(translate);
    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider Colisao){
        if(Colisao.gameObject.name == "Player"){
           
            translate.position += new Vector3 ( 0.0f, 20.0f , 0.0f);
        }
    }
}
