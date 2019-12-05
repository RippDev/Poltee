using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransformRigidbody : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360;

    public float moveSpeed = 15;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);
    }


    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }

    /* Aca podemos usar Vector3.right o Vector3.forward según convenga. En mi caso como es un juego que se va a ver de costado, el jugador corre y avanza hacia la derecha, entonces debe moverse en el eje X, lo correcto es usar Vector3.right. Después termina multiplicando por moveSpeed, también se puede multiplicar por Time.deltaTime */

    private void Move(float input)
    {
        //transform.Translate(Vector3.right * input * moveSpeed);
        rb.AddForce(transform.forward * input * moveSpeed, ForceMode.Force);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
