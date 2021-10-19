/*****************************************************************************
// File Name :         Rotate.cs
// Author :            Tristan Blair
// Creation Date :     10/15/2021
//
// Brief Description : Allows enemies or other objects to rotate
*****************************************************************************/
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }
}
