using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager GM;
    public Rigidbody rb;
    public float jumpForce;
    public Transform modelHolder;
    public LayerMask whatIsGround;
    public bool onGround;

    public Animator anim;
    public bool canMove;

    private Vector3 startPosition;
    private Quaternion startRotation;

    public float invincibleTime = 2;
    private float invincibleTimer;

    public GameObject coinEffect;



    void Start()
    {
        startPosition = transform.position;

        startRotation = transform.rotation;
    }

    void Update()
    {
        if (GM.canMove)
      {
            onGround = Physics.OverlapSphere(modelHolder.position, 0.2f, whatIsGround).Length > 0;

            if (onGround)
            {
                canMove = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (onGround)
                {
                    rb.velocity = new Vector3(0f, jumpForce, 0f);
                }
                else
                {
                    if (canMove)
                    {
                        rb.velocity = new Vector3(0f, jumpForce, 0f);
                        canMove = false;
                    }
                }

            }

            if(invincibleTimer > 0)
            {
                invincibleTimer -= Time.deltaTime;
            }


        }

     anim.SetBool("walking", GM.canMove);
        anim.SetBool("onGround", onGround);


    }

    private void OnTriggerEnter(Collider other)
    {

        if (invincibleTimer <= 0)
        {

            if (other.tag == "Hazards")
            {
                GM.HitHazard();

                //rb.isKinematic = false;

                rb.constraints = RigidbodyConstraints.None;
                rb.velocity = new Vector3(Random.Range(GameManager._worldSpeed / 2f, -GameManager._worldSpeed / 2f), 2.5f, -GameManager._worldSpeed / 2f);
            }

            if (other.tag == "Power")
            { 
                invincibleTimer = invincibleTime;
                Instantiate(coinEffect, other.transform.position, other.transform.rotation);

                Destroy(other.gameObject);
            }

        }

            if (other.tag == "Coin")
            {
                GM.AddCoin();
            Instantiate(coinEffect, other.transform.position, other.transform.rotation);


                Destroy(other.gameObject);
            }
        
    }


    

    public void ResetPlayer()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        transform.rotation = startRotation;
        transform.position = startPosition;

        invincibleTimer = invincibleTime;
    }


    
}
