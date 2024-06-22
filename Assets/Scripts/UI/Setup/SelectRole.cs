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

    private GameObject _modelStudio;//模型摄影棚
    private GameObject _modelPlace;//模型放置节点

    private TouchRotate _modelTouchRotate;//模型旋转节点

    private int _selectRoleIndex= -1;
    private int _lastRoleIndex=2;//假装有一个服务器，记录的上次选中的角色id索引index。


    private void Awake()
    {
        _roleListContent = transform.Find("RoleList/Viewport/Content").gameObject;
        _roleListToggleGroup = _roleListContent.GetComponent<ToggleGroup>();
        _btnEnter = transform.Find("BtnEnter").GetComponent<Button>();
        _btnEnter.onClick.AddListener(OnBtnEnterClick);

        _modelTouchRotate = gameObject.Find<TouchRotate>("TouchRotate");


        //处理模型摄影鹏部分
        _modelStudio = ResMgr.Instance.GetInstance("UI/SelectRole/ModelStudio");
        _modelPlace = _modelStudio.Find<Transform>("ModelPlace").gameObject;
        _modelTouchRotate.Target = _modelPlace.transform;


        //初始化角色列表
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

            //需要分组
            toggle.group = _roleListToggleGroup;
            //必须要这样写，用闭包实现角色索引和toggle绑定.
            var index = i;
            ++i;
            toggle.onValueChanged.AddListener(
                (isOn)=> { OnToggleValueChanged(index,isOn); });//闭包传入指数和索引号,不这样做的话，index值会同时发生改变
            //  默认选中
            toggle.isOn = index == _lastRoleIndex; 
        }
    }

    private void OnToggleValueChanged(int roleIndex,bool isOn)
    {
        Debug.Log(string.Format("{0}.{1}", roleIndex, isOn));
        if(isOn)
        {
            if (_selectRoleIndex == roleIndex) { return; }
            // 记录选择的索引
            _selectRoleIndex = roleIndex;
            // 先清除之前留下的模型（清空modelPlace下面的所有物体）--->>抽象为清空一个GameObject下的子GameObject

            _modelPlace.DestroyAllChildren();//封装的意义所在

            // 生成新的模型
            var curRoleInfo = UserData.Instance.AllRole[roleIndex];


            //ModelPath
            //var model = ResMgr.Instance.GetInstance(curRoleInfo.ModelResPath);
            var modelPath = RoleTable.Instance[curRoleInfo.ModelID].ModelPath;
            var model = ResMgr.Instance.GetInstance(modelPath);
            model.transform.SetParent(_modelPlace.transform,false);

        }
    }

    /// <summary>
    /// 初始化角色列表
    /// </summary>
    private void OnBtnEnterClick()
    {
        //发送一个角色选择消息    
        SelectRoleCmd cmd = new SelectRoleCmd() { Index = _selectRoleIndex};
        Net.Instance.SendCmd(cmd);

        Debug.Log("选中了角色："+_selectRoleIndex);  
    }
}
//