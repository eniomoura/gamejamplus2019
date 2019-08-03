using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEstranho : MonoBehaviour
{
    public GameObject player;
    public float startDistance;
    Transform translate;
    
    
    void Start()
    {
        translate = player.GetComponent<Transform>();
        print(translate);
    }

    void OnTriggerEnter(Collider Colisao){
        if(Colisao.gameObject.name == "Player"){
            translate.position = new Vector3(
                translate.position.x+500,
                translate.position.y, translate.position.z);
            player.GetComponent<Mover>().speed=0.4f;
        }
    }
}
