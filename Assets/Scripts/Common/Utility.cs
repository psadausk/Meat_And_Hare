using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Common {
    public static class Utility {

        public static float IncrementTowards(float current, float target, float acceleration) {
            if ( current == target )
                return current;
            float dir = Mathf.Sign(target - current);
            current += acceleration * Time.deltaTime * dir;
            return ( dir == Mathf.Sign(target - current) ? current : target );
        }
    }
}
