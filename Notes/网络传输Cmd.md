
| Cmd名称              | 传输方向  | 作用       | 内容                         |
| ------------------ | ----- | -------- | -------------------------- |
| LoginCmd           | C 2 S | 登录指令     | 账号、密码                      |
| RoleListCmd        | S 2 C | 角色列表传输指令 | SelectRoleInfo列表           |
| SelectRoleInfo     |       | 数据结构体    | 名字，模型ID                    |
| SelectRoleCmd      | C 2 S | 当前选择的角色  | 角色信息：姓名、ID                 |
| EnterMapCmd        | S 2 C | 当前场景指令   | 场景ID                       |
| MainRoleThisIDCmd  | S 2 C | 当前角色指令   | ThisID（只用传ID）              |
| CreateSceneRoleCmd | S2C   | 场景角色信息指令 | ThisID,Name,模型ID，出生位置，出生朝向 |
|                    |       |          |                            |
