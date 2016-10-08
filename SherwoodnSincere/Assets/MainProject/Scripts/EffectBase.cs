/*********************************************************************************************************
					山鬼灵镜---Development						
*********************************************************************************************************/

/*********************************************************************************************************
文件名（File Name）:   EffectBase.cs

作者（Author）:    #山鬼灵镜#

创建时间（CreateTime）:  10/8/2016 9:15:16 AM
*********************************************************************************************************/

using UnityEngine;
using System.Collections;

public class EffectBase : MonoBehaviour {			

	#region 影响字段
	/// <summary>
	/// 受影响的区域范围
	/// </summary>
	float effectArea;
	/// <summary>
	/// 弹道轨迹
	/// </summary>
	GameObject pathPrefab;
	/// <summary>
	/// 造成伤害值
	/// </summary>
	float damage;
	/// <summary>
	/// 持续伤害
	/// </summary>
	float lastDamage;
	/// <summary>
	/// 减少移动速度
	/// </summary>
	float moveSpeedDown;
	/// <summary>
	/// 减少攻击速度
	/// </summary>
	float attackSpeedDown;
	/// <summary>
	/// 影响时间
	/// </summary>
	float effectTime;

	#endregion

	#region 构造方法
	/// <summary>
	/// 有技能弹道的技能效果构造函数
	/// </summary>
	/// <param name="area">影响范围</param>
	/// <param name="pathPrefab">技能弹道效果</param>
	/// <param name="damage">伤害值</param>
	/// <param name="msDown">移速减少值</param>
	/// <param name="asDown">攻速减少值</param>
	public EffectBase(float area,GameObject pathPrefab,float damage,float lastDamage,float msDown,float asDown){
		this.effectArea = area;
		this.pathPrefab = pathPrefab;
		this.damage = damage;
		this.lastDamage = lastDamage;
		this.moveSpeedDown = msDown;
		this.attackSpeedDown = asDown;
	}
	/// <summary>
	/// 没有技能弹道的技能效果构造函数
	/// </summary>
	/// <param name="area">影响范围</param>
	/// <param name="damage">伤害值</param>
	/// <param name="msDown">移速减少值</param>
	/// <param name="asDown">攻速减少值</param>
	public EffectBase(float area,float damage,float lastDamage,float msDown,float asDown){
		this.effectArea = area;
		this.damage = damage;
		this.lastDamage = lastDamage;
		this.moveSpeedDown = msDown;
		this.attackSpeedDown = asDown;
	}
		
	#endregion

	#region 公有方法
	/// <summary>
	/// 技能影响对象方法
	/// 非指向性技能
	/// 可全屏释放
	/// </summary>
	/// <param name="target">目标</param>
	public void SkillEffect(Vector3 target){
		if (pathPrefab != null) {
			GameObject path = Instantiate (pathPrefab, transform.position, Quaternion.identity)as GameObject;
			path.GetComponent<NavMeshAgent> ().SetDestination (target);
			if (Vector3.Distance (path.transform.position, target) < 0.1f) {
				Collider[] targets = Physics.OverlapSphere (target, effectArea);
				if (target!=null) {
					foreach (Collider item in targets) {
						if (item.tag.Equals(Tags.Enemy)) {
							SkillAction (item.GetComponent<GameObject>());
						}
					}
				}
				Destroy (path);
			}
		}
	}

	/// <summary>
	/// 技能影响对象方法
	/// 指向性技能
	/// 可对玩家自己释放
	/// </summary>
	/// <param name="target">玩家</param>
	public void SkillEffect(GameObject target){
		if (pathPrefab != null) {
			GameObject path = Instantiate (pathPrefab, transform.position, Quaternion.identity)as GameObject;
			path.GetComponent<NavMeshAgent> ().SetDestination (target.transform.position);
			if (Vector3.Distance (path.transform.position, target.transform.position) < 0.1f) {
				SkillAction (target);
				Destroy (path);
			}
		}
	}
		
	#endregion

	#region 私有方法
	/// <summary>
	/// 击中效果
	/// </summary>
	/// <param name="target">Target.</param>
	private void SkillAction(GameObject target){
		CharacterAction targetCharactor = target.GetComponent<CharacterAction> ();
		targetCharactor.UnderAttack (damage);
		targetCharactor.EffectTimeCast (moveSpeedDown,attackSpeedDown,lastDamage,effectTime);
	}
	                                                                                                                                                                                                                                                                                                                                                                                                                
	#endregion

}
