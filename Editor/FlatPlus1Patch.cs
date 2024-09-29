using UnityEngine;
using nadena.dev.ndmf;
using System.Linq;
using com.github.pandrabox.flatplus1patch;

[assembly: ExportsPlugin(typeof(FlatPlus1PatchPass))]

namespace com.github.pandrabox.flatplus1patch
{
    public class FlatPlus1PatchPass : Plugin<FlatPlus1PatchPass>
    {
        protected override void Configure()
        {
            InPhase(BuildPhase.Resolving).BeforePlugin("nadena.dev.modular-avatar").Run("FlatPlus1Patch", ctx =>
            {
                if (!ctx.AvatarRootTransform.GetComponentsInChildren<FlatPlus1Patch>(true).Any()) return;
                new FlatPlus1PatchMain(ctx);
            });
        }
    }

    public class FlatPlus1PatchMain
    {
        public FlatPlus1PatchMain(BuildContext ctx)
        {
            GameObject FlatPlusObj = ctx.AvatarRootTransform?.Find("FlatPlus")?.gameObject;
            if (FlatPlusObj == null) return;
            GameObject TailRootObj = FlatPlusObj?.transform?.Find("SippoEx/Tail Root")?.gameObject;
            if (TailRootObj == null) return;

            var targetTransform = TailRootObj.transform;

            float targetPosX = 0f;
            float targetPosY = -0.1264026f;
            float targetPosZ = -0.1477546f;
            float targetScaleX = 61.43048f;
            float targetScaleY = 61.43048f;
            float targetScaleZ = 61.43048f;

            float tolerance = 0.001f;

            if (Mathf.Abs(targetTransform.localPosition.x - targetPosX) < tolerance &&
                Mathf.Abs(targetTransform.localPosition.y - targetPosY) < tolerance &&
                Mathf.Abs(targetTransform.localPosition.z - targetPosZ) < tolerance &&
                Mathf.Abs(targetTransform.localScale.x - targetScaleX) < tolerance &&
                Mathf.Abs(targetTransform.localScale.y - targetScaleY) < tolerance &&
                Mathf.Abs(targetTransform.localScale.z - targetScaleZ) < tolerance)
            {
                targetTransform.localPosition = new Vector3(0, -0.1834847f, -0.2144791f);
                targetTransform.eulerAngles = new Vector3(-108.156f, -3.148987f, 2.991989f);
                targetTransform.localScale = new Vector3(74.01262f, 74.0126f, 74.0126f);
            }
        }
    }
}