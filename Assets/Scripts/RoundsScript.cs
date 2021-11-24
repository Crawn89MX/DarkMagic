using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsScript : MonoBehaviour
{
    private int NumRounds;
    private int NumEnemys;
    private bool PreparingNextRound;

    // Start is called before the first frame update
    void Start()
    {
        NumRounds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(NumEnemys == 0 && PreparingNextRound==false){
            StartCoroutine ("returne");
            PreparingNextRound = true;
            NumRounds = NumRounds + 1;
        }
    }

    IEnumerator returne(){
        yield return new WaitForSeconds (.06f);
    }
}
