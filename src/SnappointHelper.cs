using UnityEngine;

namespace ItemStandSnap
{
    public class SnappointHelper
    {
        public static void AddSnappoints(string name, Vector3[] points)
        {
            GameObject prefab = ZNetScene.instance.GetPrefab(name);
            bool flag = prefab == null;
            if (flag) return;
            else
            {
                foreach (Vector3 pos in points)
                {
                    CreateSnappoint(pos, prefab.transform);
                }

                Plugin._self.Debug("Snappoints added to " + name);
            }
        }

        static void CreateSnappoint(Vector3 pos, Transform parent)
        {
            new GameObject("_snappoint")
            {
                transform =
                {
                    parent = parent,
                    localPosition = pos
                },
                tag = "snappoint"
            }.SetActive(false);
        }

        public static void FixPiece(string name)
        {
            GameObject prefab = ZNetScene.instance.GetPrefab(name);
            bool flag = prefab == null;
            if (flag)
            {
                Plugin._self.Debug(name + " not found. Cannot add fix piece");
            }
            else
            {
                foreach (Collider collider in prefab.GetComponentsInChildren<Collider>())
                {
                    collider.gameObject.layer = LayerMask.NameToLayer("piece");
                }
            }
        }
    }
}
