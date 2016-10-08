/*********************************************************************************************************
					山鬼灵镜---Development						
*********************************************************************************************************/

/*********************************************************************************************************
文件名（File Name）:   CharacterBase.cs

作者（Author）:    #山鬼灵镜#

创建时间（CreateTime）:  9/28/2016 9:12:09 PM
*********************************************************************************************************/

using UnityEngine;
using System.Collections;

public class CharacterBase
{


	#region 角色属性字段

	/// <summary>
	/// 角色名称
	/// </summary>
	/// <value>The name.</value>
	public string name;

	/// <summary>
	/// 角色种族
	/// </summary>
	public string race;

	/// <summary>
	/// 角色血量
	/// </summary>
	/// <value>The hp.</value>

	public float hp{ set; get; }

	/// <summary>
	/// 角色攻击力
	/// </summary>
	/// <value>The attack.</value>

	public float attack{ set; get; }

	/// <summary>
	/// 角色攻击范围
	/// </summary>
	/// <value>The attack of aera.</value>

	public float attackOfAera{ set; get; }

	/// <summary>
	/// 角色攻击速度
	/// </summary>
	/// <value>The attack speed.</value>

	public float attackSpeed{ set; get; }

	/// <summary>
	/// 角色移动速度
	/// </summary>
	/// <value>The move speed.</value>

	public float moveSpeed{ set; get; }


	#endregion

	#region 构造方法

	/// <summary>
	/// 实例化角色方法
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="ant">Ant.</param>
	/// <param name="aud">Aud.</param>

	public CharacterBase (int id)
	{
		name = ShareDataBase.sDb.SelectFieldSql ("SELECT name FROM CharactorBase WHERE id=" + id).ToString ();
		race = ShareDataBase.sDb.SelectFieldSql ("SELECT race FROM CharactorBase WHERE id =" + id).ToString ();
		hp = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT hp FROM CharactorBase WHERE id =" + id).ToString ());
		attack = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT attack FROM CharactorBase WHERE id=" + id).ToString ());
		attackOfAera = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT attackOfAera FROM CharactorBase WHERE id=" + id).ToString ());
		attackSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT attackSpeed FROM CharactorBase WHERE id=" + id).ToString ());
		moveSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT moveSpeed FROM CharactorBase WHERE id=" + id).ToString ());
	}

	#endregion


}
