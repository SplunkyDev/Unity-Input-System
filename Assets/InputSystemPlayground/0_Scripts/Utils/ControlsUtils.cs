using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.Controls
{
	public enum ePreferredControl
	{
		None =0,
		KeyBoardMouse =1,
		GamePad =2,
		Mobile =3,
		XRController =4,
		Joystic =5
	}

	public delegate void m_delUserChangedController();
}
