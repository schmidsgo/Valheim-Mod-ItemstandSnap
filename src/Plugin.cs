using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace ItemStandSnap
{
	[BepInPlugin(ModGUID, ModName, ModVersion)]
	public class Plugin : BaseUnityPlugin
	{
		public const string ModName = "ItemStandSnap", ModVersion = "0.0.1", ModGUID = "schmidsgo." + ModName;
		private static Harmony harmony = new(ModGUID);
		public static Plugin _self;

		void Awake()
		{
			_self = this;
			harmony.PatchAll();
		}


		[HarmonyPatch]
		public class Patch
		{
			[HarmonyPatch(typeof(ZNetScene), "Awake"), HarmonyPostfix]
			public static void ZNetSceneAwakePatch()
			{
				SnappointHelper.AddSnappoints("itemstandh", new Vector3[]
				{
					new (0f, 0f, 0f),
					new (0.1f, 0f, 0f),
					new (-0.1f, 0f, 0f),
					new (0.0f, 0f, 0.1f),
					new (0.0f, 0f, -0.1f),

				});
                SnappointHelper.AddSnappoints("itemstand", new Vector3[]
				{
                    new (0f, 0f, 0f),
                    new (0.22f, 0f, 0f),
                    new (-0.22f, 0f, 0f),
                    new (0.0f, 0.22f, 0f),
                    new (0.0f, -0.22f, 0f),

				});
            }
		}
		public void Debug(string msg)
		{
			Logger.LogInfo(msg);
		}
	}
}