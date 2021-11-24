﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField]
    private Transform _playerFocusPoint, _player;
    [SerializeField]
    private float velocidadMovimiento = 5.0f;
    [SerializeField]
    private float velocidadRotacion = 200.0f;
    private Animator anim;
    [SerializeField]
    private float x,y,z;
    [SerializeField]
    private Rigidbody rigidBody;
    [SerializeField]
    private float forceJump = 8f;
    public bool CanJump, Punched;

    private float cameraY, playerY,diffAngle;

    // Start is called before the first frame update
    void Start()
    {
        CanJump = false;
        anim = GetComponent<Animator>();

        if(_playerFocusPoint==null)
        {
            Debug.LogWarning("Se debe asignar la camara del jugador desde el inspector");
        }
    }

    void FixedUpdate()
    {
        if((x!=0 || y!=0))
            transform.Rotate(0,z*Time.deltaTime*velocidadRotacion,0);


        transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);
        transform.Translate(x*Time.deltaTime*velocidadMovimiento,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        cameraY = _playerFocusPoint.eulerAngles.y;
        playerY = _player.eulerAngles.y;
        diffAngle = cameraY - playerY;

        if(!(diffAngle > -2 && diffAngle < 2)){
            if((y != 0 || x != 0)){
                z = -1;
                if((diffAngle > 0 && diffAngle < 180) || (diffAngle+360 < 180) ){
                    z = 1;
                } 
            }
        }

        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);

        if(!Punched){
            if(Input.GetMouseButtonDown(1)){
                anim.SetBool("Attacking",true);
            }
            Punched = true;
        }else{
            anim.SetBool("Attacking",false);
            Punched = false;
        }

        if(CanJump){
            if(Input.GetKeyDown(KeyCode.Space)){
                anim.SetBool("Jump",true);
                rigidBody.AddForce(new Vector3(0,forceJump,0),ForceMode.Impulse);
            }
            anim.SetBool("Floor",true);
        }else{
            Falling();
        }
    }

    public void Falling(){
        anim.SetBool("Floor",false);
        anim.SetBool("Jump",false);
    }

    


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            // Debug.Log("Se encontró objeto");
            Interactable interacted = collision.GetComponent<Interactable>();

            if (interacted != null)
            {
                // Ejecutamos el método del script Interactable
                interacted.Interact();
            }
            else
            {
                Debug.Log("pero el objeto no tiene script para interactuar");
            }
        }
    }


}
