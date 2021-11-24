using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private CharacterScript _player;
    [SerializeField]
    private LifeScript _playerLife;
    private Animator anim;
    private float playerX, playerZ, enemyX, enemyZ, velX, velY;
    private bool playerNear;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerX = _player.transform.localPosition.x;
        playerZ = _player.transform.localPosition.z;

        enemyX = this.transform.localPosition.x;
        enemyZ = this.transform.localPosition.z;

        this.transform.LookAt(_player.transform);

        velX = enemyX < playerX ? 0.03f : -0.03f;
        velY = enemyZ < playerZ ? 0.03f : -0.03f;

        float X = enemyX + velX;
        float Y = this.transform.localPosition.y;
        float Z = enemyZ + velY;

        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Zombie Punching")){     
            this.transform.localPosition = new Vector3(X,Y,Z);
        }

        anim.SetFloat("VelX",velX*33.3f);
        anim.SetFloat("VelY",velY*33.3f);
    }

    private void OnTriggerStay(Collider collision){
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attacking",true);
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other){
        anim.SetBool("Attacking",false);
        playerNear = false;
    }

    public void Attack(){
        Debug.Log("Ataco");
        if(playerNear){
            _playerLife.decreaseHealth(5.0f);
        }
    }
}
