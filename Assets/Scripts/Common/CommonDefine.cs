﻿using System;
using UnityEngine;
using System.Collections;

// 游戏枚举定义-----------------------------------------------------------------------------------------------
// 界面布局定义
public enum LAYOUT_TYPE
{
	LT_GLOBAL_TOUCH,
	LT_START,
	LT_MAIN_FRAME,
	LT_CHARACTER,
	LT_BILLBOARD,
	LT_ROOM_MENU,
	LT_MAHJONG_HAND_IN,
	LT_MAHJONG_DROP,
	LT_ALL_CHARACTER_INFO,
	LT_DICE,
	LT_MAHJONG_GAME_FRAME,
	LT_PLAYER_ACTION,
	LT_GAME_ENDING,
	LT_MAX,
};
// UI物体类型
public enum UI_OBJECT_TYPE
{
	UBT_BASE,			// 窗口基类
	UBT_STATIC_SPRITE,	// 静态图片窗口,需要图集
	UBT_SPRITE_ANIM,	// 序列帧图片窗口,需要图集
	UBT_STATIC_TEXTURE, // 静态图片窗口,不需要图集
	UBT_TEXTURE_ANIM,	// 序列中图片窗口,不需要图集
	UBT_NUMBER,			// 数字窗口
	UBT_PARTICLE,		// 粒子特效窗口
	UBT_BUTTON,         // 按钮窗口
	UBT_SLIDER,			// 滑动条
	UBT_SCROLL_VIEW,	// 包含多个按钮的滚动条
	UBT_VIDEO,			// 用于播放视频的窗口
	UBT_TEXT,			// 文本窗口
}
// 停靠位置
public enum DOCKING_POSITION
{
	DP_LEFT,
	DP_CENTER,
	DP_RIGHT,
}
// 循环方式
public enum LOOP_MODE
{
	LM_ONCE,
	LM_LOOP,
	LM_PINGPONG,
}
// 播放状态
public enum PLAY_STATE
{
	PS_NONE,
	PS_PLAY,
	PS_PAUSE,
	PS_STOP,
}
// 音效定义
public enum SOUND_DEFINE
{
	SD_MIN = -1,
	SD_MAX,
};
// 音效通道定义
public enum AUDIO_CHANNEL
{
	AC_SCENE_NONE,

	AC_SCENE_MIN,
	AC_SCENE_BACKGROUND,
	AC_SCENE_MAX,

	AC_WINDOW_MIN,
	AC_WINDOW_NORMAL,
	AC_WINDOW_UI,
	AC_WINDOW_MAX,

	AC_CHARACTER_MIN,
	AC_CHARACTER_RANK,			// 名次改变时的音效,只在显示结算界面时的
	AC_CHARACTER_ANIM_TRRIGER,	// 动作触发类音效
	AC_CHARACTER_MAX,
}
// 场景的类型
public enum GAME_SCENE_TYPE
{
	GST_START,
	GST_MAIN,
	GST_MAHJONG,
	GST_MAX,
};
// 游戏场景流程类型
public enum PROCEDURE_TYPE
{
	PT_NONE,

	PT_START_MIN,
	PT_START_LOADING,
	PT_START_RUNNING,
	PT_START_EXIT,
	PT_START_MAX,

	PT_MAIN_MIN,
	PT_MAIN_LOADING,
	PT_MAIN_RUNNING,
	PT_MAIN_EXIT,
	PT_MAIN_MAX,

	PT_MAHJONG_MIN,
	PT_MAHJONG_LOADING,
	PT_MAHJONG_WAITING,
	PT_MAHJONG_RUNNING,
	PT_MAHJONG_RUNNING_DICE,
	PT_MAHJONG_RUNNING_GET_START,
	PT_MAHJONG_RUNNING_GAMING,
	PT_MAHJONG_ENDING,
	PT_MAHJONG_EXIT,
	PT_MAHJONG_MAX,
};
// 游戏中的公共变量定义
public enum GAME_DEFINE_FLOAT
{
	GDF_HTTP_PORT,					// http端口
	GDF_SOCKET_PORT,				// socket端口
	GDF_BROADCAST_PORT,				// 广播端口
	GDF_SHOW_COMMAND_DEBUG_INFO,    // 是否输出显示命令调试信息,0为不显示,1为显示
	GDF_LOAD_RESOURCES,             // -1表示优先从AssetBundle加载,找不到再去Resources加载,0表示从AssetBundle加载,1表示从Resources加载
	GDF_LOAD_ASYNC,					// 是否异步加载,0表示同步,1表示异步
	GDF_MAX,
};
public enum GAME_DEFINE_STRING
{
	GDS_MAX,
};
// 组件属性的类型
public enum PROPERTY_TYPE
{
	PT_BOOL,
	PT_INT,
	PT_STRING,
	PT_VECTOR2,
	PT_VECTOR3,
	PT_VECTOR4,
	PT_FLOAT,
	PT_ENUM,
	PT_TEXTURE,
	PT_DIM,
	PT_POINT,
};
// 音效所有者类型
public enum SOUND_OWNER
{
	SO_MIN = -1,
	SO_WINDOW,
	SO_GAME_SCENE,
	SO_CHARACTER,
};
// 作为客户端时接收以及发送的类型
public enum SOCKET_PACKET
{
	SP_CARD_DATA,
	SP_FRICTION,
	SP_FRICTION_RET,
	SP_MAX,
};
// HTTP协议消息包类型
public enum HTTP_PACKET
{
	HP_NONE = -1,
};
// 表格数据类型
public enum DATA_TYPE
{
	DT_GAME_SOUND,
	DT_MAX,
}
// character 类型
public enum CHARACTER_TYPE
{
	CT_NORMAL,
	CT_NPC,
	CT_OTHER,
	CT_MYSELF,
	CT_MAX,
}
public enum ACTION_TYPE
{
	AT_HU,
	AT_GANG,
	AT_PENG,
	AT_PASS,
	AT_MAX,
}
public enum MAHJONG
{
	// 8种花
	M_HUA_CHUN,
	M_HUA_XIA,
	M_HUA_QIU,
	M_HUA_DONG,
	M_HUA_MEI,
	M_HUA_LAN,
	M_HUA_ZHU,
	M_HUA_JU,
	// 7个风
	M_FENG_DONG,
	M_FENG_NAN,
	M_FENG_XI,
	M_FENG_BEI,
	M_FENG_ZHONG,
	M_FENG_FA,
	M_FENG_BAI,
	// 9个筒
	M_TONG1,
	M_TONG2,
	M_TONG3,
	M_TONG4,
	M_TONG5,
	M_TONG6,
	M_TONG7,
	M_TONG8,
	M_TONG9,
	// 9个条
	M_TIAO1,
	M_TIAO2,
	M_TIAO3,
	M_TIAO4,
	M_TIAO5,
	M_TIAO6,
	M_TIAO7,
	M_TIAO8,
	M_TIAO9,
	// 9个万
	M_WAN1,
	M_WAN2,
	M_WAN3,
	M_WAN4,
	M_WAN5,
	M_WAN6,
	M_WAN7,
	M_WAN8,
	M_WAN9,

	M_MAX,
}
public enum MAHJONG_HUASE
{
	MH_HUA,		// 花牌
	MH_FENG,	// 风牌
	MH_TONG,	// 筒
	MH_TIAO,	// 条
	MH_WAN,		// 万
	MH_MAX,
}
public enum PLAYER_POSITION
{
	PP_MYSELF,		// 玩家自己
	PP_LEFT,        // 左边的玩家
	PP_OPPOSITE,    // 对面的玩家
	PP_RIGHT,		// 右边的玩家
	PP_MAX,
}
// 胡牌类型
public enum HU_TYPE
{
	HT_NONE,		// 没有人胡
	HT_NORMAL,		// 平胡
	HT_QINGYISE,	// 清一色
}

// 游戏委托定义-------------------------------------------------------------------------------------------------------------
public delegate void SpriteAnimCallBack(txUISpriteAnim window, object userData, bool isBreak);
public delegate void TextureAnimCallBack(txUITextureAnim window, object userData, bool isBreak);
public delegate void KeyFrameCallback(ComponentKeyFrame component, object userData, bool breakTremling, bool done);
public delegate void AlphaFadeCallback(ComponentAlpha component, object userData, bool breakFade, bool done);
public delegate void CommandCallback(object user_data, Command cmd);
public delegate void MoveCallback(ComponentMove moveComponent, object userdata, bool breakMove, bool done);
public delegate void RotateToTargetCallback(ComponentRotateToTarget component, object userData, bool breakRotate, bool done);
public delegate void ScaleCallback(ComponentScale component, object user_data, bool breakDone, bool done);
public delegate void HSLCallback(ComponentHSL component, object userData, bool breakHSL, bool done);
public delegate void BoxColliderClickCallback(txUIButton obj);
public delegate void BoxColliderHoverCallback(txUIButton obj, bool hover);
public delegate void BoxColliderPressCallback(txUIButton obj, bool press);
public delegate void AssetLoadDoneCallback(UnityEngine.Object res);
public delegate void LayoutAsyncDone(GameLayout layout);
public delegate void VideoPlayEndCallback(string videoName, bool isBreak);

// 游戏常量定义-------------------------------------------------------------------------------------------------------------
public class CommonDefine
{
	// 路径定义
	// 文件夹名
	public const string ASSETS = "Assets";
	public const string RESOURCES = "Resources";
	public const string ATLAS = "Atlas";
	public const string FONT = "Font";
	public const string GAME_DATA_FILE = "GameDataFile";
	public const string KEY_FRAME = "KeyFrame";
	public const string LOWER_KEY_FRAME = "keyframe";
	public const string LAYOUT = "Layout";
	public const string LOWER_LAYOUT = "layout";
	public const string SCENE = "Scene";
	public const string SHADER = "Shader";
	public const string SKYBOX = "Skybox";
	public const string SOUND = "Sound";
	public const string MATERIAL = "Material";
	public const string TEXTURE = "Texture";
	public const string GAME_ATLAS = "GameAtlas";
	public const string GAME_TEXTURE = "GameTexture";
	public const string NUMBER_STYLE = "NumberStyle";
	public const string TEXTURE_ANIM = "TextureAnim";
	public const string LAYOUT_PREFAB = "LayoutPrefab";
	public const string LOWER_LAYOUT_PREFAB = "layoutprefab";
	public const string UI_PREFAB = "UIPrefab";
	public const string STREAMING_ASSETS = "StreamingAssets";
	public const string CONFIG = "Config";
	public const string VIDEO = "Video";
	public const string PARTICLE = "Particle";
	// 相对路径,相对于项目,以P_开头,表示Project
	public const string P_ASSETS_PATH = ASSETS + "/";
	public const string P_RESOURCE_PATH = P_ASSETS_PATH + RESOURCES + "/";
	// 相对路径,相对于Assets,以A_开头,表示Assets
	public const string A_RESOURCE_PATH = RESOURCES + "/";
	public const string A_STREAMING_ASSETS_PATH = STREAMING_ASSETS + "/";
	public const string A_CONFIG_PATH = A_STREAMING_ASSETS_PATH + CONFIG + "/";
	public const string A_VIDEO_PATH = A_STREAMING_ASSETS_PATH + VIDEO + "/";
	public const string A_GAME_DATA_FILE_PATH = A_STREAMING_ASSETS_PATH + GAME_DATA_FILE + "/";
	public const string A_KEY_FRAME_PATH = A_RESOURCE_PATH + KEY_FRAME + "/";
	public const string A_LAYOUT_PATH = A_RESOURCE_PATH + LAYOUT + "/";
	public const string A_LAYOUT_PREFAB_PATH = A_LAYOUT_PATH + LAYOUT_PREFAB + "/";
	public const string A_BUNDLE_KEY_FRAME_PATH = A_STREAMING_ASSETS_PATH + LOWER_KEY_FRAME + "/";
	public const string A_BUNDLE_LAYOU_PATH = A_STREAMING_ASSETS_PATH + LOWER_LAYOUT + "/";
	public const string A_BUNDLE_LAYOUT_PREFAB_PATH = A_BUNDLE_LAYOU_PATH + LAYOUT_PREFAB + "/";
	// 相对路径,相对于Resources,R_开头,表示Resources
	public const string R_SOUND_PATH = SOUND + "/";
	public const string R_LAYOUT_PATH = LAYOUT + "/";
	public const string R_KEY_FRAME_PATH = KEY_FRAME + "/";
	public const string R_LAYOUT_PREFAB_PATH = R_LAYOUT_PATH + LAYOUT_PREFAB + "/";
	public const string R_UI_PREFAB_PATH = R_LAYOUT_PATH + UI_PREFAB + "/";
	public const string R_TEXTURE_PATH = TEXTURE + "/";
	public const string R_GAME_TEXTURE_PATH = R_TEXTURE_PATH + GAME_TEXTURE + "/";
	public const string R_TEXTURE_ANIM_PATH = R_TEXTURE_PATH + TEXTURE_ANIM + "/";
	public const string R_MATERIAL_PATH = MATERIAL + "/";
	public const string R_PARTICLE_PATH = PARTICLE + "/";
	// 绝对路径,以F_开头,表示Full
	public static string F_ASSETS_PATH = Application.dataPath + "/";
	public static string F_STREAMING_ASSETS_PATH = F_ASSETS_PATH + STREAMING_ASSETS + "/";
	public static string F_VIDEO_PATH = F_STREAMING_ASSETS_PATH + VIDEO + "/";
	public static string F_CONFIG_PATH = F_STREAMING_ASSETS_PATH + CONFIG + "/";
	public static string F_GAME_DATA_FILE_PATH = F_STREAMING_ASSETS_PATH + GAME_DATA_FILE + "/";
	// 后缀名
	public const string DATA_SUFFIX = ".bytes";
	public const string ASSET_BUNDLE_SUFFIX = ".unity3d";
	//----------------------------------------------------------------------------------------------------------------
	// 常量定义
	// 常亮字符串
	// 音效所有者类型名,应该与SOUND_OWNER一致
	public static string[] SOUND_OWNER_NAME = new string[] { "Window", "Scene" };
	// 所有麻将的资源名字
	public static string[] MAHJONG_NAME = new string[(int)MAHJONG.M_MAX]
	{
		"Hua0", "Hua1", "Hua2", "Hua3", "Hua4","Hua5", "Hua6", "Hua7",
		"Feng0", "Feng1", "Feng2", "Feng3", "Feng4", "Feng5", "Feng6",
		"Tong0", "Tong1", "Tong2", "Tong3", "Tong4", "Tong5", "Tong6", "Tong7", "Tong8",
		"Tiao0", "Tiao1", "Tiao2", "Tiao3", "Tiao4", "Tiao5", "Tiao6", "Tiao7", "Tiao8",
		"Wan0", "Wan1", "Wan2", "Wan3", "Wan4", "Wan5", "Wan6", "Wan7", "Wan8"
	};
	public static string[] mHandInRootName = new string[MAX_PLAYER_COUNT] { "MyMahjongRoot", "LeftMahjongRoot", "OppositeMahjongRoot", "RightMahjongRoot" };
	public static string[] mShowRootName = new string[MAX_PLAYER_COUNT] { "MyShowRoot", "LeftShowRoot", "OppositeShowRoot", "RightShowRoot" };
	public static string[] mShowPreName = new string[MAX_PLAYER_COUNT] { "Drop_My_", "Drop_Side_", "Drop_Opposite_", "Drop_Side_" };
	//------------------------------------------------------------------------------------------------------------------------
	// 常量数字
	// 每名玩家手里最多有14张牌,不包含碰,吃,杠
	public const int MAX_HAND_IN_COUNT = 14;
	// 可以碰或者杠的最大次数
	public const int MAX_PENG_TIMES = MAX_HAND_IN_COUNT / 3;
	// 一局麻将游戏中玩家的最大数量
	public const int MAX_PLAYER_COUNT = (int)PLAYER_POSITION.PP_MAX;
	// 每个麻将的最大数量
	public const int MAX_SINGLE_COUNT = 4;
	// 一局中所有麻将的最大数量
	public const int MAX_MAHJONG_COUNT = (int)MAHJONG.M_MAX * MAX_SINGLE_COUNT;
	// 骰子的个数
	public const int DICE_COUNT = 2;
	// 每个骰子的最大值,骰子值的范围从0到MAX_DICE_VALUE
	public const int MAX_DICE_VALUE = 5;
	// 开局时发每一张牌的时间间隔
	public const float ASSIGN_MAHJONG_INTERVAL = 0.1f;
}