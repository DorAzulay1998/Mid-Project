using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{

    public Animator on;
    void Start()
    {
        on = GetComponent<Animator>();
    }

    void Update()
    {
        on.SetBool("On", true);
    }
}
