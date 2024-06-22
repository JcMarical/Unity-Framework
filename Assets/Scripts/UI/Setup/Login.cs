using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 登录界面
/// </summary>
public class Login : MonoBehaviour
{

    private InputField _inputAccount;
    private InputField _inputPassword;
    private Button _btnOK;



    private void Awake()
    {
        _inputAccount = transform.Find
            ("InputAccount").GetComponent<InputField>();      
        _inputPassword = transform.Find
            ("InputPassword").GetComponent<InputField>();
        _btnOK = transform.Find("BtnLogin").GetComponent<Button>();

        _btnOK.onClick.AddListener(onBtnOKClick);
    }
    private void onBtnOKClick()
    {

        //网络连接消息发送(实际用Json)
        //=================
        //账号密码格式检验
        var account = _inputAccount.text;
        var password = _inputPassword.text;
        if(string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
        { return; }


        _inputAccount.interactable = false;
        _inputPassword.interactable= false;
        _btnOK.interactable = false;


        Net.Instance.ConnectServer(doSuccess,doFailed);



        //连接服务器，等待返回数据。
        //暂时用假数据，直接进入选人界面。
       // Application.LoadLevel("SelectRole");
        //
        Debug.Log("ok btn");
    }
    private void doFailed()
    {

        _inputAccount.interactable = false;
        _inputPassword.interactable = false;
        _btnOK.interactable = false;
    }

    private void doSuccess()
    {
        //账号密码格式检验
        var account = _inputAccount.text;
        var password = _inputPassword.text;


        var cmd = new LoginCmd { Account = account, Password = password };
        Net.Instance.SendCmd(cmd);
        Debug.Log("成功发送LoginCmd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
