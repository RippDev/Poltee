using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransform : MonoBehaviour
{
    private string horizontalInputAxis = "Horizontal";
    private string verticalInputAxis = "Vertical";
    public Animator _anim;

    public float rotationRate = 360;

    public float moveSpeed = 2;

    // Use this for initialization
    void Start()
    {
        _anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMoveAxis = Input.GetAxis(horizontalInputAxis);
        float verticalMoveAxis = Input.GetAxis(verticalInputAxis);

        ApplyInput(horizontalMoveAxis, verticalMoveAxis);
    }


    private void ApplyInput(float horizontalMoveInput, float verticalMoveInput)
    {
        HorizontalMove(horizontalMoveInput);
        VerticalMove(verticalMoveInput);
        _anim.SetFloat("walking", horizontalMoveInput);
    }

    /* Aca podemos usar Vector3.right o Vector3.forward según convenga. En mi caso como es un juego que se va a ver de costado, el jugador corre y avanza hacia la derecha, entonces debe moverse en el eje X, lo correcto es usar Vector3.right. Después termina multiplicando por moveSpeed, también se puede multiplicar por Time.deltaTime */

    private void HorizontalMove(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime);
    }

    private void VerticalMove(float input)
    {
        //transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
        transform.Translate(Vector3.left * input * moveSpeed * Time.deltaTime);
    }

}
