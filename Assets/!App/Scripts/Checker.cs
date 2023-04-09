namespace OpenCvSharp.Demo
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    using OpenCvSharp;

    public class Checker : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private TextMeshProUGUI resultText;

        [SerializeField] private RenderTexture renderTexture;
        [SerializeField] private TextAsset model;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Check()
        {
            AlphabetOCR alphabet = new AlphabetOCR(model.bytes);

            var image = Unity.TextureToMat(ToTexture2D(renderTexture));
            IList<AlphabetOCR.RecognizedLetter> letters = alphabet.ProcessImage(image);

            bool result = false;
            foreach (var letter in letters)
            {
                var bounds = Cv2.BoundingRect(letter.Rect);
                if (bounds.Width > bounds.Height)
                    result |= letter.Data.Contains('8');
            }
            resultText.text = result.ToString();
        }

        public Texture2D ToTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
            var old_rt = RenderTexture.active;
            RenderTexture.active = rTex;

            tex.ReadPixels(new UnityEngine.Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();

            RenderTexture.active = old_rt;
            return tex;
        }
    }
}
