using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private Animator anim;
    float playerX, playerZ, enemyX, enemyZ, velX, velY;

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

        this.transform.LookAt(_player);

        velX = enemyX < playerX ? 0.05f : -0.05f;
        velY = enemyZ < playerZ ? 0.05f : -0.05f;

        float X = enemyX + velX;
        float Y = this.transform.localPosition.y;
        float Z = enemyZ + velY;

        this.transform.localPosition = new Vector3(X,Y,Z);

        anim.SetFloat("VelX",velX*20);
        anim.SetFloat("VelY",velY*20);
    }

    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
        }
    }
}
