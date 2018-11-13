﻿using UnityEngine;
using System.Collections;

public class txNGUIEditbox : txNGUISprite
{
	protected UIInput mInput;
	public txNGUIEditbox()
	{
		mType = UI_TYPE.UT_NGUI_EDITBOX;
	}
	public override void init(GameLayout layout, GameObject go, txUIObject parent)
	{
		base.init(layout, go, parent);
		mInput = mObject.GetComponent<UIInput>();
		if (mInput == null)
		{
			mInput = mObject.AddComponent<UIInput>();
		}
	}
	public void setText(string text)
	{
		mInput.value = text;
	}
	public string getText()
	{
		return mInput.value;
	}
	public void setInputSubmitCallback(EventDelegate.Callback callback)
	{
		EventDelegate.Add(mInput.onSubmit, callback);
	}
	public void setOnValidateCallback(UIInput.OnValidate validate)
	{
		mInput.onValidate = validate;
	}
	public void setOnTabCallback(UIInput.OnKeyDelegate onTabDelegate)
	{
		mInput.onTabCallback = onTabDelegate;
	}
}
