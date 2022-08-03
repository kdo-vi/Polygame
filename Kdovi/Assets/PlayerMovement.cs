using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody m_Rb;


    private float activeMoveSpeed;
    public float dashSpeed;
    private float dashCounter;
    public float dashLenght = .5f, dashCooldown = 1f;
    private float dashCoolCounter;
    // Start is called before the first frame update
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        activeMoveSpeed = speed;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if(horizontalInput != 0 && verticalInput != 0)
        {
             horizontalInput = horizontalInput * 0.5f;
             verticalInput = verticalInput * 0.5f;

        }
        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        if (movement == Vector3.zero)
        {
            return;
        }

        //Quaternion targetRotation = Quaternion.LookRotation(movement);

        //Debug.Log(targetRotation.eulerAngles);

        m_Rb.MovePosition(m_Rb.position + movement * activeMoveSpeed * Time.deltaTime);
        //m_Rb.MoveRotation(targetRotation);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;

                dashCounter = dashLenght;
            }
        }
        
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter<= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }
        
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            
        }
    }

}