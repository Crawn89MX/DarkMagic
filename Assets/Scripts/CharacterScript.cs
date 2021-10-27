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

    private float cameraY, playerY;

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
        // if(cameraY > 180f)
        // {
        //     cameraY = cameraY - 360f;
        // }
        playerY = _player.eulerAngles.y;
        // if(playerY > 180f)
        // {
        //     playerY = playerY - 360f;
        // }
            Debug.Log(playerY);
            Debug.Log(cameraY);

        if(y != 0 && x == 0)
        {
            // (cameraY - playerY < (360-cameraY)+playerY) && !Mathf.Approximately(cameraY , playerY)
            // (cameraY < playerY && (cameraY - playerY) < 180) || (cameraY > playerY && ((cameraY+360) - playerY) < 180)
            // if(cameraY > playerY )
            if(((cameraY - playerY) > 0 && (cameraY - playerY) < 180) || ((cameraY+360) - playerY < 180) )
            {
                x = 1;
            }
            else
            {
                x = -1;
            }  
        }
        
        

        transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);
        transform.Rotate(0,x*Time.deltaTime*velocidadRotacion,0);

        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);
    }
}
