using UnityEngine;
namespace SkyGameKit {
    public class OffsetScroller : MonoBehaviour {
        public float scrollSpeed;
        [HideInInspector]
        public float inGameScrollSpeed;
        private Vector2 savedOffset;
        private Renderer myRenderer;
        void Start() {
            inGameScrollSpeed = scrollSpeed;
            myRenderer = GetComponent<Renderer>();
            savedOffset = myRenderer.sharedMaterial.GetTextureOffset("_MainTex");
        }

        void Update() {
            if (!GameManager.isPlaying) inGameScrollSpeed = 0;
            float x = Mathf.Repeat(Time.time * inGameScrollSpeed, 1);
            Vector2 offset = new Vector2(x, savedOffset.y);
            myRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        }

        void OnDisable() {
            myRenderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
        }
    }
}