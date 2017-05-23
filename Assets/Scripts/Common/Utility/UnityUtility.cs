﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using UnityEngine;

public class UnityUtility : GameBase
{
	protected static GameCamera mForeEffectCamera;
	protected static GameCamera mBackEffectCamera;
	public void init() 
	{
		mForeEffectCamera = mCameraManager.getCamera("UIForeEffectCamera");
		mBackEffectCamera = mCameraManager.getCamera("UIBackEffectCamera");
	}
	public static void logError(string info)
	{
		messageBox(info, true);
		Debug.LogError("error : " + info);
	}
	public static void logInfo(string info)
	{
		Debug.Log(info);
	}
	public static void messageBox(string info, bool errorOrInfo)
	{
		string title = errorOrInfo ? "错误" : "提示";
		// 在编辑器中显示对话框
#if UNITY_EDITOR
		UnityEditor.EditorUtility.DisplayDialog(title, info, "确认");
#else
		// 游戏运行过程中显示窗口提示框
		MessageBox.Show(info, title, MessageBoxButtons.OK, errorOrInfo ? MessageBoxIcon.Error : MessageBoxIcon.Information);
#endif
	}
	public static Ray getRay(Vector2 screenPos)
	{
		if (mLayoutManager.getUIRootObject() == null)
		{
			return new Ray();
		}
		Camera camera = mCameraManager.getUICamera().getCamera();
		return camera.ScreenPointToRay(screenPos);
	}
	public static List<BoxCollider> Raycast(Ray ray, List<BoxCollider> boxList, int maxCount = 0)
	{
		List<BoxCollider> retList = new List<BoxCollider>();
		RaycastHit hit = new RaycastHit();
		foreach (var box in boxList)
		{
			if (box.Raycast(ray, out hit, 10000.0f))
			{
				retList.Add(box);
				if (maxCount > 0 && retList.Count >= maxCount)
				{
					break;
				}
			}
		}
		return retList;
	}
	public static GameObject getGameObject(GameObject parent, string name)
	{
		GameObject go = null;
		if (parent == null)
		{
			go = GameObject.Find(name);
		}
		else
		{
			Transform trans = parent.transform.Find(name);
			if (trans != null)
			{
				go = trans.gameObject;
			}
		}
		return go;
	}
	// parent为实例化后挂接的父节点
	// prefabName为预设名,带Resources下相对路径
	// name为实例化后的名字
	// 其他三个是实例化后本地的变换
	public static GameObject instantiatePrefab(GameObject parent, string prefabName, string name, Vector3 scale, Vector3 rot, Vector3 pos)
	{
		GameObject prefab = mResourceManager.loadResource<GameObject>(prefabName, true);
		if (prefab == null)
		{
			logError("error : can not find prefab : " + prefabName);
			return null;
		}
		GameObject obj = instantiatePrefab(prefab);
		setNormalProperty(ref obj, parent, name, scale, rot, pos);
		return obj;
	}
	// prefabName为Resource下的相对路径
	public static GameObject instantiatePrefab(GameObject parent, string prefabName)
	{
		string name = StringUtility.getFileName(ref prefabName);
		return instantiatePrefab(parent, prefabName, name, Vector3.one, Vector3.zero, Vector3.zero);
	}
	public static GameObject instantiatePrefab(GameObject prefab)
	{
		return GameObject.Instantiate(prefab);
	}
	public static bool instantiatePrefabAsync(string prefabName, AssetLoadDoneCallback callback)
	{
		bool ret = mResourceManager.loadResourceAsync<GameObject>(prefabName, callback, true);
		return ret;
	}
	public static void setNormalProperty(ref GameObject obj, GameObject parent, string name, Vector3 scale, Vector3 rot, Vector3 pos)
	{
		obj.transform.parent = parent.transform;
		obj.transform.localPosition = pos;
		obj.transform.localEulerAngles = rot;
		obj.transform.localScale = scale;
		obj.transform.name = name;
	}
	public static T createInstance<T>(Type classType, object[] param) where T : class
	{
		T instance = Activator.CreateInstance(classType, param) as T;
		return instance;
	}
	public static Vector2 screenPosToEffectPos(Vector2 screenPos, Vector2 parentWorldPos, float effectDepth, bool isBack, bool isRelative = true)
	{
		GameCamera camera = isBack ? mBackEffectCamera : mForeEffectCamera;
		if (isRelative)
		{
			// 转到世界坐标系下,首先计算UI根节点的缩放值
			Vector3 scale = mLayoutManager.getUIRoot().getScale();
			screenPos.x = screenPos.x / scale.x;
			screenPos.y = screenPos.y / scale.y;
			parentWorldPos.x = parentWorldPos.x / scale.x;
			parentWorldPos.y = parentWorldPos.y / scale.y;
		}
		return (effectDepth / -camera.getPosition().z + 1) * screenPos - parentWorldPos;
	}
	public static void setGameObjectLayer(txUIObject obj, string layerName)
	{
		int layer = LayerMask.NameToLayer(layerName);
		if (layer < 0 || layer >= 32)
		{
			return;
		}
		GameObject go = obj.mObject;
		go.layer = layer;
		foreach (Transform t in go.transform.GetComponentsInChildren<Transform>(true))
		{
			t.gameObject.layer = layer;
		}
	}
}