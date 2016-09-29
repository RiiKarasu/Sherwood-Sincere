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

public class CharacterBase : MonoBehaviour {			

	enum Race 
	{
		Bunny,
		Warthog
	}

	#region 角色属性字段
	/// <summary>
	/// 角色名称
	/// </summary>
	/// <value>The name.</value>
	string name{ set; get;}
	/// <summary>
	/// 角色种族
	/// </summary>
	Race race;
	/// <summary>
	/// 角色血量
	/// </summary>
	/// <value>The hp.</value>
	float hp{ set; get;}
	/// <summary>
	/// 角色攻击力
	/// </summary>
	/// <value>The attack.</value>
	float attack{ set; get;}
	/// <summary>
	/// 角色攻击范围
	/// </summary>
	/// <value>The attack of aera.</value>
	float attackOfAera{ set; get;}
	/// <summary>
	/// 角色攻击速度
	/// </summary>
	/// <value>The attack speed.</value>
	float attackSpeed{ set; get;}
	/// <summary>
	/// 角色移动速度
	/// </summary>
	/// <value>The move speed.</value>
	float moveSpeed{set;get;}
	/// <summary>
	/// 角色技能
	/// </summary>
	SkillBase[] skills;
	/// <summary>
	/// 角色动画组件
	/// </summary>
	Animator ant;
	/// <summary>
	/// 角色声音组件
	/// </summary>
	AudioSource aud;
	/// <summary>
	/// 角色旋转速度
	/// </summary>
	public float roSpeed = 180f;


	#endregion

	#region 构造方法
	public CharacterBase(int id,Animator ant,AudioSource aud){
		name = ShareDataBase.sDb.SelectFieldSql ("SELECT name FROM CharactorBase WHERE id="+id).ToString();
		//		race = ShareDataBase.sDb.SelectFieldSql ("SELECT race FROM CharactorBase WHERE id =" + id).ToString;
		hp = float.Parse(ShareDataBase.sDb.SelectFieldSql("SELECT hp FROM CharactorBase WHERE id ="+id).ToString());
		attack = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attack FROM CharactorBase WHERE id="+id).ToString());
		attackOfAera = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attackOfAera FROM CharactorBase WHERE id="+id).ToString());
		attackSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attackSpeed FROM CharactorBase WHERE id="+id).ToString());
		moveSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT moveSpeed FROM CharactorBase WHERE id="+id).ToString());
		this.ant = ant;
		this.aud = aud;
	}
	#endregion

	#region 公共方法

	/// <summary>
	/// 角色受到攻击
	/// </summary>
	/// <param name="damage">伤害值</param>
	public void UnderAttack(float damage){
		hp -= damage;
		ant.SetTrigger (HashID.UnderAttack);
	}
		
	public void PlayerDead(AudioClip DeathAudio){
		ant.SetBool (HashID.PlayerDeath,true);
		AudioSource.PlayClipAtPoint (DeathAudio,transform.position);
	}

	#endregion

	#region 私有方法

	/// <summary>
	/// 角色移动
	/// </summary>
	private void PlayerMove(AudioSource aud){
		float ver = Input.GetAxis ("Verrtical");
		float hor = Input.GetAxis ("Horizontal");
		float targetSpeed = 1;

		if (ver != 0||hor != 0) {
			transform.position += transform.forward * ver * Time.deltaTime * moveSpeed;
			transform.Rotate (Vector3.up * hor * Time.deltaTime * roSpeed);
			targetSpeed = 1;
			if (!aud.isPlaying) {
				aud.Play ();
			}
		} else {
			aud.Stop ();
			targetSpeed = 0;
		}

		ant.SetFloat (HashID.MoveSpeed,Mathf.Lerp(ant.GetFloat(HashID.MoveSpeed),targetSpeed,Time.deltaTime));
	}

	#endregion

}
