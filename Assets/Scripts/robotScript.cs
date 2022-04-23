using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotScript : MonoBehaviour
{

    public TextMesh textoFeedback;
    public string msgInteraccion;

    public CharacterController player;

    public GameObject Robot;
    public bool isOnRobot;

    public GameObject Globo;

    // Start is called before the first frame update
    void Start()
    {
        SetTextMessage(msgInteraccion, false);
        Debug.Log(Input.GetJoystickNames());
        Globo.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(isOnRobot)
        {

            if (Input.GetButtonDown("Fire2"))
            {
                //Debug.Log("Toca B");
                SetTextMessage(" ", true);
                Globo.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<CharacterController>();



            if (player != null)
            {
                //Entro un player
                isOnRobot = true;
                SetTextMessage(msgInteraccion, true);

                
            }
        }
        Debug.Log("Entro");

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() == player)
        {

            //Robot.GetComponent<Animator>().SetBool("OpenChest", false);
            isOnRobot = false;
            player = null;
            SetTextMessage(msgInteraccion, false);
            Globo.SetActive(false);


        }
    }

    void SetTextMessage(string message, bool isActive)
    {
        textoFeedback.text = message;
        textoFeedback.gameObject.SetActive(isActive);
    }
}
