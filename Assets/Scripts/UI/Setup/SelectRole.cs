using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRole : MonoBehaviour
{
    private GameObject _roleListContent;
    private Button _btnEnter;
    private ToggleGroup _roleListToggleGroup;

    private GameObject _modelStudio;//ģ����Ӱ��
    private GameObject _modelPlace;//ģ�ͷ��ýڵ�

    private TouchRotate _modelTouchRotate;//ģ����ת�ڵ�

    private int _selectRoleIndex= -1;
    private int _lastRoleIndex=2;//��װ��һ������������¼���ϴ�ѡ�еĽ�ɫid����index��


    private void Awake()
    {
        _roleListContent = transform.Find("RoleList/Viewport/Content").gameObject;
        _roleListToggleGroup = _roleListContent.GetComponent<ToggleGroup>();
        _btnEnter = transform.Find("BtnEnter").GetComponent<Button>();
        _btnEnter.onClick.AddListener(OnBtnEnterClick);

        _modelTouchRotate = gameObject.Find<TouchRotate>("TouchRotate");


        //����ģ����Ӱ������
        _modelStudio = ResMgr.Instance.GetInstance("UI/SelectRole/ModelStudio");
        _modelPlace = _modelStudio.Find<Transform>("ModelPlace").gameObject;
        _modelTouchRotate.Target = _modelPlace.transform;


        //��ʼ����ɫ�б�
        int i = 0;
        //foreach (var roleInfo in RoleTable.Instance.GetAll())
        foreach (var roleInfo in UserData.Instance.AllRole)
        {
            var roleItem = ResMgr.Instance.GetInstance("UI/SelectRole/RoleItem");
            roleItem.transform.SetParent(_roleListContent.transform, false);
            var textName = roleItem.transform.Find("Label").GetComponent<Text>();
            var toggle = roleItem.GetComponent<Toggle>();

           // textName.text = roleInfo.Name;
            textName.text = roleInfo.Name;

            //��Ҫ����
            toggle.group = _roleListToggleGroup;
            //����Ҫ����д���ñհ�ʵ�ֽ�ɫ������toggle��.
            var index = i;
            ++i;
            toggle.onValueChanged.AddListener(
                (isOn)=> { OnToggleValueChanged(index,isOn); });//�հ�����ָ����������,���������Ļ���indexֵ��ͬʱ�����ı�
            //  Ĭ��ѡ��
            toggle.isOn = index == _lastRoleIndex; 
        }
    }

    private void OnToggleValueChanged(int roleIndex,bool isOn)
    {
        Debug.Log(string.Format("{0}.{1}", roleIndex, isOn));
        if(isOn)
        {
            if (_selectRoleIndex == roleIndex) { return; }
            // ��¼ѡ�������
            _selectRoleIndex = roleIndex;
            // �����֮ǰ���µ�ģ�ͣ����modelPlace������������壩--->>����Ϊ���һ��GameObject�µ���GameObject

            _modelPlace.DestroyAllChildren();//��װ����������

            // �����µ�ģ��
            var curRoleInfo = UserData.Instance.AllRole[roleIndex];


            //ModelPath
            //var model = ResMgr.Instance.GetInstance(curRoleInfo.ModelResPath);
            var modelPath = RoleTable.Instance[curRoleInfo.ModelID].ModelPath;
            var model = ResMgr.Instance.GetInstance(modelPath);
            model.transform.SetParent(_modelPlace.transform,false);

        }
    }

    /// <summary>
    /// ��ʼ����ɫ�б�
    /// </summary>
    private void OnBtnEnterClick()
    {
        //����һ����ɫѡ����Ϣ    
        SelectRoleCmd cmd = new SelectRoleCmd() { Index = _selectRoleIndex};
        Net.Instance.SendCmd(cmd);

        Debug.Log("ѡ���˽�ɫ��"+_selectRoleIndex);  
    }
}
//