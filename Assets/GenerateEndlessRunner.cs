using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEndlessRunner : MonoBehaviour
{
    public GameObject[] jumpables;
    public GameObject lareiraFinal;
    public Vector3 nextLevelStart;
    public float firstX;
    public float minDistanceBetween;
    public float maxDistanceBetween;
    public float distanceToGenerate;

    void Start()
    {
        float lastX = firstX;
        for(int i=0;lastX<firstX+distanceToGenerate-maxDistanceBetween-30;i++){
            int choosenJumpableIndex = Random.Range(0, jumpables.Length);
            GameObject choosenJumpable = jumpables[choosenJumpableIndex];
            int choosenJumpableXPosition = (int) Mathf.Ceil(
                lastX+Random.Range(minDistanceBetween, maxDistanceBetween));
            Instantiate(choosenJumpable,
                new Vector3(
                    choosenJumpableXPosition,
                    choosenJumpable.transform.position.y,
                    choosenJumpable.transform.position.z),
                Quaternion.identity);
            lastX = choosenJumpableXPosition;
        }
        GameObject fh = Instantiate(lareiraFinal, new Vector3(lastX+28,2,1), Quaternion.identity);
        fh.GetComponent<NextLevel>().nextLevelStart = nextLevelStart;
    }
}
