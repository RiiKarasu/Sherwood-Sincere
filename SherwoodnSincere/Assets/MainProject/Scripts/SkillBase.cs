/*********************************************************************************************************
					山鬼灵镜---Development						
*********************************************************************************************************/

/*********************************************************************************************************
文件名（File Name）:   SkillBase.cs

作者（Author）:    #山鬼灵镜#

创建时间（CreateTime）:  9/28/2016 9:26:09 PM
*********************************************************************************************************/

using UnityEngine;
using System.Collections;

public class SkillBase : MonoBehaviour {			

	#region 技能字段
	/// <summary>
	/// 技能名字
	/// </summary>
	string name;
	/// <summary>
	/// 技能描述
	/// </summary>
	string description;
	/// <summary>
	/// 施法时间
	/// </summary>
	float castingTime;
	/// <summary>
	/// 冷却时间
	/// </summary>
	float coldTime;
	/// <summary>
	/// 施法距离
	/// </summary>
	float castingDistance;
	/// <summary>
	/// 技能造成效果
	/// </summary>
	EffectBase skillEffect;

	#endregion

	#region 构造方法

	SkillBase (int id){
		name = ShareDataBase.sDb.SelectFieldSql ("SELECT Name FROM SkillBase WHERE id="+id).ToString();
		description = ShareDataBase.sDb.SelectFieldSql ("SELECT Description FROM SkillBase WHERE id="+id).ToString();
		castingTime = float.Parse(ShareDataBase.sDb.SelectFieldSql ("SELECT CastingTime FROM SkillBase WHERE id="+id).ToString());
		coldTime =float.Parse( ShareDataBase.sDb.SelectFieldSql ("SELECT ColdTime FROM SkillBase WHERE id="+id).ToString());
	}
	#endregion

	#region 公共方法
	/// <summary>
	/// 初始化技能效果--有弹道技能
	/// </summary>
	/// <param name="area">影响范围.</param>
	/// <param name="damage">伤害.</param>
	/// <param name="msDown">减移速效果.</param>
	/// <param name="asDown">减攻速效果.</param>
	public void InitSkill(float area,float damage,float msDown,float asDown){
		skillEffect= new EffectBase (area,damage,msDown,asDown);
	}
	/// <summary>
	/// 初始化技能效果--无弹道技能
	/// </summary>
	/// <param name="area">影响范围.</param>
	/// <param name="pathPrefab">弹道预置体.</param>
	/// <param name="damage">伤害.</param>
	/// <param name="msDown">减移速效果.</param>
	/// <param name="asDown">减攻速效果.</param>
	public void InitSkill(float area,GameObject pathPrefab,float damage,float msDown,float asDown){
		skillEffect= new EffectBase (area,pathPrefab,damage,msDown,asDown);
	}
	/// <summary>
	/// 指向性技能释放
	/// </summary>
	/// <param name="target">目标对象.</param>
	public void CastingAction(GameObject target){
		skillEffect.SkillEffect (target);
	}
	/// <summary>
	/// 非指向性技能释放
	/// </summary>
	/// <param name="target">目标位置.</param>
	public void CastingAction(Vector3 target){
		skillEffect.SkillEffect (target);
	}
	#endregion

}
