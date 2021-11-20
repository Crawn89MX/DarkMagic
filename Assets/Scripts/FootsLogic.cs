using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootsLogic : MonoBehaviour
{
    public CharacterScript characterScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other){
        characterScript.CanJump = true;
    }

    public void OnTriggerExit(Collider other){
        characterScript.CanJump = false;
    }
}
