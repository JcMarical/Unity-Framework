using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��¼����
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

        //����������Ϣ����(ʵ����Json)
        //=================
        //�˺������ʽ����
        var account = _inputAccount.text;
        var password = _inputPassword.text;
        if(string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
        { return; }


        _inputAccount.interactable = false;
        _inputPassword.interactable= false;
        _btnOK.interactable = false;


        Net.Instance.ConnectServer(doSuccess,doFailed);



        //���ӷ��������ȴ��������ݡ�
        //��ʱ�ü����ݣ�ֱ�ӽ���ѡ�˽��档
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
        //�˺������ʽ����
        var account = _inputAccount.text;
        var password = _inputPassword.text;


        var cmd = new LoginCmd { Account = account, Password = password };
        Net.Instance.SendCmd(cmd);
        Debug.Log("�ɹ�����LoginCmd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
