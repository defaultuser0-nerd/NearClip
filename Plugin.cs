using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace NearClip
{
	[BepInPlugin("default.NearClip", "NearClip", "1.0.0")]
	public class Plugin : BaseUnityPlugin
	{
		public ConfigEntry<float> ClippingAmout;
		void Awake()
		{
			ClippingAmout = Config.Bind("Settings", "NearClip", 0.1f, new ConfigDescription("This changes the amount of near clip you want on your main camera", new AcceptableValueRange<float>(.01f, 1f)));

			
            GorillaTagger.OnPlayerSpawned(delegate
            {
	            Camera.main.nearClipPlane = Mathf.Clamp(ClippingAmout.Value, 0.01f, 0.9f);
            });
		}
	}
}
