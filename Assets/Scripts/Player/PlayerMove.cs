using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController charControl;
    public float walkSpeed;
    private float diagMoveModifier = 0.5f;

	void Start ()
    {
        charControl = GetComponent<CharacterController>();
	}

    private void FixedUpdate()
    {

    }

    void Update ()
    {
        MovePlayer();
	}

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * vert * walkSpeed;

        if(horiz != 0 && vert != 0)
        {
            moveDirSide *= diagMoveModifier;
            moveDirForward *= diagMoveModifier;
        }

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);
    }
}
