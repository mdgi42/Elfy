using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 6;
    public float horizontalSpeed = 5;
    public float verticalSpeed = 5;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    public bool isJumping = false;
    public bool isSliding = false;
    public bool comingDown = false;
    public bool atFirst = true;
    public GameObject playerObject;
    public GameObject trigger;

    private int desiredLane = 3; //0 sx, 1 centro, 2 dx
    public float laneDistance = 1.10f;

    public GameObject[] personaggi;
    private int personaggioCorrente;

    void Start()
    {
        
        //soldiCollezionati = PlayerPrefs.GetInt("Soldi", 0);

        //Scelgo il personaggio da mostrare
        personaggioCorrente = PlayerPrefs.GetInt("Personaggio", 0);
        foreach (GameObject personaggio in personaggi)
        {
            personaggio.SetActive(false);
        }
        personaggi[personaggioCorrente].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (SwipeManager.swipeLeft) //(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                if (desiredLane > 0)
                {
                    desiredLane--;
                    //targetPosition += Vector3.left * laneDistance;
                    //transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime * playerSpeed);
                }
                //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
            }
        }
        if (SwipeManager.swipeRight) //(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                if (desiredLane < 6)
                {
                    desiredLane++;
                    //targetPosition += Vector3.right * laneDistance;
                    //transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime * playerSpeed);
                }
                //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1, Space.World);
            }
        }

        //if (isJumping == false && isSliding == false)
        //{

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (desiredLane == 0)
                //targetPosition += Vector3.left * ( laneDistance + laneDistance/2 );
                targetPosition += Vector3.left * 6.60f;
            else if (desiredLane == 1)
                //targetPosition += Vector3.left * laneDistance;
                targetPosition += Vector3.left * 4.40f;
            else if (desiredLane == 2)
                //targetPosition += Vector3.right * laneDistance;
                targetPosition += Vector3.left * 2.20f;

            else if (desiredLane == 4)
                //targetPosition += Vector3.right * (laneDistance + laneDistance / 2);
                targetPosition += Vector3.right * 2.20f;
            else if (desiredLane == 5)
                //targetPosition += Vector3.right * (laneDistance + laneDistance / 2);
                targetPosition += Vector3.right * 4.40f;
            else if (desiredLane == 6)
                //targetPosition += Vector3.right * (laneDistance + laneDistance / 2);
                targetPosition += Vector3.right * 6.60f;

            transform.position = Vector3.Lerp(transform.position, targetPosition, 40 * Time.deltaTime * playerSpeed);
        //}

        if (SwipeManager.swipeUp) //(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if(isJumping == false && isSliding == false)
            {
                isJumping = true;
                //playerObject.GetComponent<Animator>().Play("Jump");
                personaggi[personaggioCorrente].GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }
        if (SwipeManager.swipeDown)
        {
            if (isSliding == false && isJumping == false)
            {
                isSliding = true;
                //playerObject.GetComponent<Animator>().Play("Sprinting Forward Roll");
                personaggi[personaggioCorrente].GetComponent<Animator>().Play("Sprinting Forward Roll");
                StartCoroutine(SlideSequence());
            }
        }
        if (isJumping == true)
        {
            if (comingDown == false && atFirst == true)
            {
                //Vector3 jumpPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
                Vector3 jumpPosition = targetPosition;
                jumpPosition += Vector3.up * 2.20f;
                //trigger.SetActive(false);
                //transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed, Space.World);
                transform.position = Vector3.Lerp(transform.position, jumpPosition, 40 * Time.deltaTime * playerSpeed);
                //transform.Translate(Vector3.up * 0.53f * verticalSpeed, Space.World);
                atFirst = false;
            }
            if (comingDown == true && atFirst == true)
            {
                //Vector3 landPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
                Vector3 landPosition = targetPosition;
                landPosition += Vector3.down * 2.20f;
                //trigger.SetActive(true);
                //transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed * -1, Space.World);
                transform.position = Vector3.Lerp(transform.position, landPosition, 40 * Time.deltaTime * playerSpeed);
                //transform.Translate(Vector3.up * 0.53f * verticalSpeed * -1, Space.World);
                atFirst = false;
            }

        }
        if (isSliding == true)
        {
            if (comingDown == false && atFirst == true)
            {
                trigger.SetActive(false);
                atFirst = false;
            
                //playerObject.transform.RotateAroundLocal(Vector3.forward, -70.0f);
                //transform.rotation = new Quaternion(0.0f, 0.0f, -70.0f, 0.0f);
                //transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed, Space.World);
                //transform.Rotate(-1.0f, 0.0f, 0.0f, Space.World);
            }
            if (comingDown == true && atFirst == true)
            {
                trigger.SetActive(true);
                atFirst = false;
                //playerObject.transform.RotateAroundLocal(Vector3.forward, 70.0f);
                //transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed * -1, Space.World);
                //transform.Rotate(1.0f, 0.0f, 0.0f, Space.World);
            }

        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.50f);
        comingDown = true;
        atFirst = true;
        yield return new WaitForSeconds(0.50f);
        isJumping = false;
        comingDown = false;
        atFirst = true;
        //playerObject.GetComponent<Animator>().Play("Running");
        personaggi[personaggioCorrente].GetComponent<Animator>().Play("Running");
    }
    IEnumerator SlideSequence()
    {
        yield return new WaitForSeconds(1.15f);
        comingDown = true;
        atFirst = true;
        yield return new WaitForSeconds(0.30f);
        isSliding = false;
        comingDown = false;
        atFirst = true;
        //playerObject.GetComponent<Animator>().Play("Running");
        personaggi[personaggioCorrente].GetComponent<Animator>().Play("Running");
    }
}
