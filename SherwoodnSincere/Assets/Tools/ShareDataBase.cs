/*********************************************************************************************************
					山鬼灵镜---Development						
*********************************************************************************************************/

/*********************************************************************************************************
文件名（File Name）:   ShareDataBase.cs

作者（Author）:    #山鬼灵镜#

创建时间（CreateTime）:  #2016-9-6 11:17:03#
*********************************************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

public class ShareDataBase
{
	//		1.单例化该脚本
	public static ShareDataBase sDb = new ShareDataBase ();

	//		创建一个数据库连接对象
	/// <summary>
	/// 数据库连接对象
	/// </summary>
	SqliteConnection m_con;
	//		只负责连接
	/// <summary>
	/// 命令执行对象
	/// </summary>
	SqliteCommand m_command;
	//		负责查询
	/// <summary>
	/// 接收查询返回值的对象
	/// </summary>
	SqliteDataReader m_reader;
	//		接收用

	private ShareDataBase ()
	{							//		重写构造方法
		
//		string dataPath = "Data Source ="+Application.streamingAssetsPath+"/myFirstDataBase.sqlite";
//		Debug.Log (dataPath);


		#if  UNITY_EDITOR
		string dataPath = "Data Source =" + Application.streamingAssetsPath + "/BasicDataBase.sqlite";
		#elif  UNITY_IPHONE
		string dataPath = "Data Source =" + Application.persistentDataPath+"/BasicDataBase.sqlite";
		#elif  UNITY_ANDRIOD
		string dataPath = "URI = file:"+Application.persistentDataPath+"/BasicDataBase.sqlite";
		#endif

		try {
			if (m_con == null) {
				m_con = new SqliteConnection (dataPath);
			}
		} catch (SqliteException ex) {
			Debug.Log ("sss" + ex);
		}

		try {
			m_command = m_con.CreateCommand ();
		} catch (SqliteException ex) {
			Debug.Log (ex);
		}

		sDb = this;
	}

	#region 私有方法

	/// <summary>
	/// 打开数据库
	/// </summary>
	private void OpenConnectDataBase ()
	{
		try {
			m_con.Open ();
		} catch (SqliteException ex) {
			Debug.Log (ex);
		}
	}

	/// <summary>
	/// 关闭数据库
	/// </summary>
	private void CloseConnectDataBase ()
	{
		try {
			m_con.Close ();
		} catch (SqliteException ex) {
			Debug.Log (ex);
		}
	}

	#endregion

	#region 公开方法

	/// <summary>
	/// 适用于没有返回值的sql命令，如：<创建表><删除表><插入数据><删除数据><更改数据>
	/// </summary>
	/// <param name="query">需要执行的sql语句</param>
	public void ExecSql (string query)
	{
		//		打开数据库
		OpenConnectDataBase ();

		try {
			m_command.CommandText = query;
			m_command.ExecuteNonQuery ();
		} catch (SqliteException ex) {
			Debug.Log (ex);
		}

		//		关闭数据库
		CloseConnectDataBase ();
	}

	/// <summary>
	/// 查询返回一个单元格
	/// <查属性><查条数><>
	/// </summary>
	/// <returns>The field sql.</returns>
	/// <param name="query">Query.</param>
	public object SelectFieldSql (string query)
	{
		OpenConnectDataBase ();

		object obj = new object ();
		try {
			m_command.CommandText = query;
			obj = m_command.ExecuteScalar ();
		} catch (SqliteException ex) {
			Debug.Log (ex);
		}

		CloseConnectDataBase ();

		return obj;
	}

	/// <summary>
	/// 查询多行多列数据
	/// </summary>
	/// <returns>The result sql.</returns>
	public List<ArrayList> SelectResultSql (string query)
	{
		OpenConnectDataBase ();

		List <ArrayList> list = new List<ArrayList> ();

		try {
			m_command.CommandText = query;
			m_reader = m_command.ExecuteReader ();

			while (m_reader.Read ()) {
				ArrayList alist = new ArrayList ();
				for (int i = 0; i < m_reader.FieldCount; i++) {
					alist.Add (m_reader.GetValue (i));
				}
				list.Add (alist);
			}
			m_reader.Close ();
		} catch (SqliteException ex) {
			Debug.Log (ex);
		}

		CloseConnectDataBase ();

		return list;
	}

	#endregion

	//ExecuteNonQuery ();		------->返回受到影响的行数
	//ExecuteScalar ();				------->返回查询结果的第一个值
	//ExecuteReader ();			------->返回所有查询结果
}
