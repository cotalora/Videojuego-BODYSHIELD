﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsuarioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string usuarioname = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("USI: " + usuarioname);
        DontDestroyOnLoad(gameObject);
    }
}