using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

namespace UI {

    public class InverseMask : Image
    {
        public override Material materialForRendering {
            get {
                Material material = new Material(base.materialForRendering);
                material.SetInt("_StencilComp", (int) CompareFunction.NotEqual);
                return material;
            }
        }
    }
}