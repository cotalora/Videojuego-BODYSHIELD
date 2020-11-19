using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loginn : MonoBehaviour
{
    public InputField userNameInput;
    public InputField passwordInput;
    public Button loginButton;

    UsuarioScript usuario;

    void Start()
    {
        usuario = GameObject.Find("Usuario").GetComponent<UsuarioScript>();
        loginButton.onClick.AddListener(() => {
            StartCoroutine(Main.instance.web.Login(userNameInput.text, passwordInput.text));
            usuario.usuarioname = userNameInput.text;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
