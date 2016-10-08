/*********************************************************************************************************
					山鬼灵镜---Development						
*********************************************************************************************************/

/*********************************************************************************************************
文件名（File Name）:   HashID.cs

作者（Author）:    #山鬼灵镜#

创建时间（CreateTime）:  9/29/2016 1:27:45 PM
*********************************************************************************************************/

using UnityEngine;

public class HashID:MonoBehaviour{			
	
	public static int UnderAttack;
	public static int MoveSpeed;
	public static int PlayerDeath;
	public static int Enemy;
	public static int Allies;

void Start () {
		UnderAttack = Animator.StringToHash ("UnderAttack");
		MoveSpeed = Animator.StringToHash ("Speed");
		PlayerDeath= Animator.StringToHash ("isDead");
		Enemy = "Enemy";
		Allies = "Allies";
}
}
