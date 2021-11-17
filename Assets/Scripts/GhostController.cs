using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject target;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(target.transform);
        CheckAttack();
        CheckChase();
        CheckIdle();

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Chasing")){
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime*3);
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attacking")){
            transform.GetComponent<Rigidbody>().AddForce(-target.transform.forward * 0.4f, ForceMode.Impulse);
        }


        Debug.Log(target.transform.position);

        // transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);
        // transform.Rotate(0,x*Time.deltaTime*velocidadRotacion,0);

        // anim.SetFloat("VelX",x);
        // anim.SetFloat("VelY",y);
    }

    // private void CheckAttack(){
    //     if(Vector3.Distance(target.transform.position, this.transform.position) < 2){
    //         anim.SetTrigger("Attack");
    //     }
    // }

    private void CheckAttack(){
        if(Vector3.Distance(target.transform.position, this.transform.position) < 2){
            anim.SetTrigger("Attack");
        }
    }

    private void CheckIdle(){
        if(Vector3.Distance(target.transform.position, this.transform.position) < 10 && Vector3.Distance(target.transform.position, this.transform.position) >= 2){
            anim.SetTrigger("Idle");
        }
    }

    private void CheckChase(){
        if(Vector3.Distance(target.transform.position, this.transform.position) >= 10){
            anim.SetTrigger("Stop");
        }
    }
}
