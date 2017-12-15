using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SkyGameKit {
    public class GroundManager : MonoBehaviour {
        public OffsetScroller backGroundScroller;

        void Update() {
            transform.position += Time.deltaTime * Vector3.left * backGroundScroller.inGameScrollSpeed * backGroundScroller.transform.localScale.x;
        }
    }
}
