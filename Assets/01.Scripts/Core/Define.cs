using UnityEngine;

namespace Core
{
	public enum StateType
	{
		Normal = 0,
		//OnHit = 1,
	}

	public enum GunType
	{
		HandGun = 0,
		ShotGun = 1,
		Sniper = 2
	}

	public class Define
	{
		private static Camera mainCam = null;
		public static Camera MainCam
		{
			get
			{
				if(mainCam == null) mainCam = Camera.main;
				return mainCam;
			}
		}
	}
}
