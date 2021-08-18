using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{   //variables and Ienumerator

    #region variables
    public Vector3 playerinput;
    public Vector2 playermouse;

    public Transform playercam;
    public Rigidbody rb;

    public float speed = 15f;
    public float sensitivity;
    public float jumpforce;
    public float xrot;

    public bool canjump = true;
    public Vector3 sped;
    public bool isstrafe = false;
    public Transform player;
    public bool colliding = true;
    public float time;
    public bool walljump = false;
    public bool slopedown;
    public float slopespeed = .1f;
    private bool isslide;
  
    IEnumerator strafee(float time)


    {


        isstrafe = true;
        yield return new WaitForSecondsRealtime(time);
        isstrafe = false;


    }
       
    IEnumerator ifstrafe()
    {


        speed = 10.5f;
        yield return new WaitForSecondsRealtime(10f);
        speed = 15f;
    }


    IEnumerator wj()
    {


        speed = 22.5f;
        jumpforce = 1.5f;
        Physics.gravity = new Vector3(0, -5F, 0);
        yield return new WaitForSecondsRealtime(1f);
        speed = 15f;
        jumpforce = 1f;
        Physics.gravity = new Vector3(0, -9.81F, 0);
    }

    
    
    #endregion

    // Update function that contains many things
    
    #region inputs and others
    public void Update()
    {
        playerinput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));




        playermouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));



        moveplayer();




        sped = rb.velocity;


        strafe();




        if (walljump == false)
        {
            if (isstrafe == true)
            {
                speed = 10.5f;

            }
            else
            {
                speed = 15f;
            }

        }
        if (walljump == true)
        {
            StartCoroutine(wj());
        }


        

    }
    #endregion




    //determines if player can jump
    //also contains walljump

    #region jump
    private void OnCollisionEnter(Collision collisionifo)
    {

        Debug.Log(collisionifo.collider.tag);

        if (collisionifo.collider.tag == ("ground") || collisionifo.collider.tag == "walljump" || collisionifo.collider.tag == "table" || collisionifo.collider.tag == "slope")
        {
            canjump = true;





        }




        else
        {
            canjump = false;

        }







        if (walljump)
        {
            speed = 15f;

            jumpforce = 4f;
        }

        else
        {
            speed = 10f;
            jumpforce = 1f;
        }



        




        if (collisionifo.collider.tag == ("walljump"))
        {
            walljump = true;
        }
        else
        {
            walljump = false;
        }




        if (collisionifo.collider.tag == "slope")
        {


            isslide = true;
            if (isslide)
            {
                float a = 24f;
                float b = speed;
                rb.AddForce(Vector3.down * 8000);

                speed = Mathf.Lerp(a, b, slopespeed);
                isslide = false;
            }
            
           

        }

        else
        {
            isslide = false;

            if (isslide)
            {
                rb.AddForce(Vector3.up * 6, ForceMode.Impulse);
            }
        }

        



        
    }



    #endregion



    //move player
    #region move
    private void moveplayer()
    {
        Vector3 movevector = transform.TransformDirection(playerinput) * speed;

        rb.velocity = new Vector3(movevector.x, rb.velocity.y, movevector.z);



        if (canjump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {


                rb.AddForce(new Vector3(0, 5, 0) * jumpforce, ForceMode.Impulse);


                canjump = false;

            }

        }



    }

    #endregion

    void slidespeed()
    {
        speed = 15f;
    }



    


    //this function will make speed slower if press two keys at once.

    //do not open this




    #region twokeys
    public void strafe()
    {

        if (Input.GetKey("w") && Input.GetKey("a"))



        {


            StartCoroutine(strafee(0.1f));

        }

        

        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            StartCoroutine(strafee(0.1f));
        }


        if (Input.GetKey("w") && Input.GetKey("d"))



        {


            StartCoroutine(strafee(0.1f));

        }

        if (Input.GetKey("d") && Input.GetKey("w"))
        {
            StartCoroutine(strafee(0.1f));
        }




        if (Input.GetKey("s") && Input.GetKey("a"))



        {


            StartCoroutine(strafee(0.1f));

        }

        if (Input.GetKey("a") && Input.GetKey("s"))
        {
            StartCoroutine(strafee(0.1f));
        }




        if (Input.GetKey("s") && Input.GetKey("d"))



        {
            StartCoroutine(strafee(0.1f));


        }

        if (Input.GetKey("d") && Input.GetKey("s"))
        {
            StartCoroutine(strafee(0.1f));
        }
        //KeyCode.RightArrow


        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))



        {

            StartCoroutine(strafee(0.1f));


        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(strafee(0.1f));
        }


        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))



        {

            StartCoroutine(strafee(0.1f));

        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(strafee(0.1f));
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))



        {

            StartCoroutine(strafee(0.1f));


        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(strafee(0.1f));
        }


        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))



        {

            StartCoroutine(strafee(0.1f));


        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(strafee(0.1f));
        }


    }


    #endregion





}
