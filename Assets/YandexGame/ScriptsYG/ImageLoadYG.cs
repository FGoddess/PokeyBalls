using System.IO;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

namespace YG
{
    public class ImageLoadYG : MonoBehaviour
    {
        [SerializeField] bool startLoad = true;
        [SerializeField] RawImage rawImage;
        [SerializeField] string urlImage;
        [SerializeField] GameObject loadAnimObj;

        private void Awake()
        {
            rawImage.enabled = false;
            if (startLoad) Load();
            else if (loadAnimObj) loadAnimObj.SetActive(false);
        }

        public void Load()
        {
            if (loadAnimObj) loadAnimObj.SetActive(true);
            StartCoroutine(SwapPlayerPhoto(urlImage));
        }

        public void Load(string url)
        {
            if (url != "null")
            {
                if (loadAnimObj) loadAnimObj.SetActive(true);
                StartCoroutine(SwapPlayerPhoto(url));
            }
        }

        IEnumerator SwapPlayerPhoto(string url)
        {
            yield return null;
        }
    }
}
