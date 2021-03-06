﻿using System;
using System.Collections;
using System.Collections.Generic;

public class SCRequestDropRet : SocketPacket
{
	public BYTE mIndex = new BYTE();
	public BYTE mMahjong = new BYTE();
	public SCRequestDropRet(PACKET_TYPE type)
		: base(type) { }
	protected override void fillParams()
	{
		pushParam(mIndex);
		pushParam(mMahjong);
	}
	public override void execute()
	{
		CommandCharacterDrop cmd = newCmd(out cmd);
		cmd.mMah = (MAHJONG)mMahjong.mValue;
		cmd.mIndex = mIndex.mValue;
		pushCommand(cmd, mCharacterManager.getMyself());
	}
}