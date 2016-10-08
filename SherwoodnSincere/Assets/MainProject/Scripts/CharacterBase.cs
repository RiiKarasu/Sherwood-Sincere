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

<<<<<<< HEAD
public class CharacterBase : MonoBehaviour
{

	enum Race
	{
		Bunny,
		Warthog
	}
=======

public class CharacterBase : MonoBehaviour {			
>>>>>>> 39cb34362aadab3e8438456cb0a8930afa90013f

	#region 角色属性字段

	/// <summary>
	/// 角色名称
	/// </summary>
	/// <value>The name.</value>
	string name{ set; get; }

	/// <summary>
	/// 角色种族
	/// </summary>
<<<<<<< HEAD
	Race race;

=======
	string race;
>>>>>>> 39cb34362aadab3e8438456cb0a8930afa90013f
	/// <summary>
	/// 角色血量
	/// </summary>
	/// <value>The hp.</value>
	float hp{ set; get; }

	/// <summary>
	/// 角色攻击力
	/// </summary>
	/// <value>The attack.</value>
	float attack{ set; get; }

	/// <summary>
	/// 角色攻击范围
	/// </summary>
	/// <value>The attack of aera.</value>
	float attackOfAera{ set; get; }

	/// <summary>
	/// 角色攻击速度
	/// </summary>
	/// <value>The attack speed.</value>
	float attackSpeed{ set; get; }

	/// <summary>
	/// 角色移动速度
	/// </summary>
	/// <value>The move speed.</value>
	float moveSpeed{ set; get; }

	/// <summary>
	/// 当前移动速度
	/// </summary>
	float curMoveSpeed;
	/// <summary>
	/// 当前攻击速度
	/// </summary>
	float curAttackSpeed;
	/// <summary>
	/// buff计时器
	/// </summary>
	float timer;
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

<<<<<<< HEAD
	#endregion

	#region 构造方法

	public CharacterBase (int id, Animator ant, AudioSource aud)
	{
		name = ShareDataBase.sDb.SelectFieldSql ("SELECT name FROM CharactorBase WHERE id=" + id).ToString ();
		//		race = ShareDataBase.sDb.SelectFieldSql ("SELECT race FROM CharactorBase WHERE id =" + id).ToString;
		hp = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT hp FROM CharactorBase WHERE id =" + id).ToString ());
		attack = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT attack FROM CharactorBase WHERE id=" + id).ToString ());
		attackOfAera = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT attackOfAera FROM CharactorBase WHERE id=" + id).ToString ());
		attackSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT attackSpeed FROM CharactorBase WHERE id=" + id).ToString ());
		moveSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql ("SELECT moveSpeed FROM CharactorBase WHERE id=" + id).ToString ());
		this.ant = ant;
		this.aud = aud;
	}
=======


	#endregion

	#region 构造方法
	/// <summary>
	/// 实例化角色方法
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="ant">Ant.</param>
	/// <param name="aud">Aud.</param>
	public CharacterBase(int id,Animator ant,AudioSource aud){
		name = ShareDataBase.sDb.SelectFieldSql ("SELECT name FROM CharactorBase WHERE id="+id).ToString();
		race = ShareDataBase.sDb.SelectFieldSql ("SELECT race FROM CharactorBase WHERE id =" + id).ToString();
		hp = float.Parse(ShareDataBase.sDb.SelectFieldSql("SELECT hp FROM CharactorBase WHERE id ="+id).ToString());
		attack = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attack FROM CharactorBase WHERE id="+id).ToString());
		attackOfAera = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attackOfAera FROM CharactorBase WHERE id="+id).ToString());
		attackSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attackSpeed FROM CharactorBase WHERE id="+id).ToString());
		moveSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT moveSpeed FROM CharactorBase WHERE id="+id).ToString());
		this.ant = ant;
		this.aud = aud;
	}
	/// <summary>
	/// 获取角色信息方法
	/// </summary>
	/// <param name="id">Identifier.</param>
	public CharacterBase(int id){
		name = ShareDataBase.sDb.SelectFieldSql ("SELECT name FROM CharactorBase WHERE id="+id).ToString();
		hp = float.Parse(ShareDataBase.sDb.SelectFieldSql("SELECT hp FROM CharactorBase WHERE id ="+id).ToString());
		attack = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attack FROM CharactorBase WHERE id="+id).ToString());
		attackOfAera = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attackOfAera FROM CharactorBase WHERE id="+id).ToString());
		attackSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT attackSpeed FROM CharactorBase WHERE id="+id).ToString());
		moveSpeed = float.Parse (ShareDataBase.sDb.SelectFieldSql("SELECT moveSpeed FROM CharactorBase WHERE id="+id).ToString());
	}
>>>>>>> 39cb34362aadab3e8438456cb0a8930afa90013f

	#endregion

	#region 公共方法
	/// <summary>
	/// 角色受到攻击
	/// </summary>
	/// <param name="damage">伤害值</param>
	public void UnderAttack (float damage)
	{
		hp -= damage;
		ant.SetTrigger (HashID.UnderAttack);
	}
<<<<<<< HEAD

	public void PlayerDead (AudioClip DeathAudio)
	{
		ant.SetBool (HashID.PlayerDeath, true);
		AudioSource.PlayClipAtPoint (DeathAudio, transform.position);
=======
	/// <summary>
	/// 角色死亡方法
	/// </summary>
	/// <param name="DeathAudio">Death audio.</param>
	public void PlayerDead(AudioClip DeathAudio){
		ant.SetBool (HashID.PlayerDeath,true);
		AudioSource.PlayClipAtPoint (DeathAudio,transform.position);
>>>>>>> 39cb34362aadab3e8438456cb0a8930afa90013f
	}
	/// <summary>
	///  受技能效果影响
	/// </summary>
	/// <param name="msEffect">移速减少.</param>
	/// <param name="asEffect">攻速减少.</param>
	/// <param name="lastDamage">持续伤害.</param>
	/// <param name="time">效果持续时间.</param>
	public void EffectTimeCast(float msEffect,float asEffect,float lastDamage,float time){
		timer+= Time.deltaTime;
		if (timer < time) {
			curAttackSpeed =attackSpeed- asEffect;
			curMoveSpeed =moveSpeed- msEffect;
			hp -= lastDamage;
			EffectTimeCast (msEffect,asEffect,lastDamage,time);
		} else {
			curMoveSpeed = moveSpeed;
			curAttackSpeed = attackSpeed;
			timer = 0;
		}
	}

	#endregion

	#region 私有方法

	/// <summary>
	/// 角色移动
	/// </summary>
	private void PlayerMove (AudioSource aud)
	{
		float ver = Input.GetAxis ("Verrtical");
		float hor = Input.GetAxis ("Horizontal");
		float targetSpeed = 1;

		if (ver != 0 || hor != 0) {
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

		ant.SetFloat (HashID.MoveSpeed, Mathf.Lerp (ant.GetFloat (HashID.MoveSpeed), targetSpeed, Time.deltaTime));
	}

	#endregion

}
