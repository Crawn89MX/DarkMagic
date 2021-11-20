using System.Collections;
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
    private float x,y;

    private float cameraY, playerY,diffAngle;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(_playerFocusPoint==null)
        {
            Debug.LogWarning("Se debe asignar la camara del jugador desde el inspector");
        }
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
            if((y != 0 && x == 0)){
                x = -1;
                if((diffAngle > 0 && diffAngle < 180) || (diffAngle+360 < 180) ){
                    x = 1;
                } 
            }
        }

        transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);
        transform.Rotate(0,x*Time.deltaTime*velocidadRotacion,0);

        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);
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
