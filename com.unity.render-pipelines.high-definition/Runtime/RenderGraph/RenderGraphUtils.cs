using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;

namespace UnityEngine.Experimental.Rendering
{
    using RTHandle = RTHandleSystem.RTHandle;

    public static class RenderGraphUtils
    {

        const int kMinMRTCount = 1;
        const int kMaxMRTCount = 8;
        static List<RenderTargetIdentifier[]> s_MRTArrays = new List<RenderTargetIdentifier[]>();

        public static RenderTargetIdentifier[] GetMRTArray(int mrtCount)
        {
            if (mrtCount < kMinMRTCount || mrtCount > kMaxMRTCount)
            {
                Debug.LogError(string.Format("Trying to request MRT array with an invalid count {0}", mrtCount));
                return null;
            }

            if (s_MRTArrays.Count == 0)
            {
                for (int i = 0; i < (kMaxMRTCount - kMinMRTCount); ++i)
                    s_MRTArrays.Add(new RenderTargetIdentifier[i+ kMinMRTCount]);
            }

            return s_MRTArrays[mrtCount - kMinMRTCount];
        }
    }
}
