using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEndlessRunner : MonoBehaviour
{
    public GameObject[] jumpables;
    public GameObject lareiraFinal;
    public Vector3[] levelStarts;
    public Vector3 nextLevelStart;
    public List<GameObject> generated;
    public int currentLevel;
    public float firstX;
    public float minDistanceBetween;
    public float maxDistanceBetween;
    public float distanceToGenerate;

    void Start() {
        currentLevel=0;
        Generate();    
    }

    public void Generate()
    {
        {
            float lastX = firstX;
            for(int i=0;lastX<firstX+distanceToGenerate-maxDistanceBetween-30;i++){
                int choosenJumpableIndex = Random.Range(0, jumpables.Length);
                GameObject choosenJumpable = jumpables[choosenJumpableIndex];
                int choosenJumpableXPosition = (int) Mathf.Ceil(
                    lastX+Random.Range(minDistanceBetween, maxDistanceBetween));
                generated.Add(Instantiate(choosenJumpable,
                    new Vector3(
                        choosenJumpableXPosition,
                        choosenJumpable.transform.position.y,
                        choosenJumpable.transform.position.z),
                    Quaternion.identity));
                lastX = choosenJumpableXPosition;
            }
            GameObject fh = Instantiate(lareiraFinal, new Vector3(lastX+28,2,1), Quaternion.identity);
            generated.Add(fh);
            fh.GetComponent<NextLevel>().nextLevelStart = nextLevelStart;
            if(currentLevel==levelStarts.Length){
                //CENA FINAL                
            }else{
                nextLevelStart = levelStarts[currentLevel];
            }
            currentLevel++;
        }
        
    }

    public void Regenerate(){
        foreach (GameObject g in generated)
        {
            GameObject.Destroy(g);
        }
        generated = new List<GameObject>();
        Generate();
    }
}
