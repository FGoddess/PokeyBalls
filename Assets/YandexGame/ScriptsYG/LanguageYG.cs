using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using System.Collections;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
#endif

namespace YG
{
    public class LanguageYG : MonoBehaviour
    {
        public Text textUIComponent;
        public TextMesh textMeshComponent;
        public InfoYG infoYG;
        [Space(10)]
        public string text;
        public string ru, en, tr, az, be, he, hy, ka, et, fr, kk, ky, lt, lv, ro, tg, tk, uk, uz;
        public Font uniqueFont;

        private void Start()
        {
            Serialize();
        }

        private void OnEnable()
        {
            YandexGame.SwitchLangEvent += SwitchLanguage;
            SwitchLanguage(YandexGame.savesData.language);
        }
        private void OnDisable() => YandexGame.SwitchLangEvent -= SwitchLanguage;

        public void SwitchLanguage(string lang)
        {
            switch (lang)
            {
                case "ru":
                    AssignLanguage(ru, "ru");
                    break;
                case "en":
                    AssignLanguage(en, "en");
                    break;
                case "tr":
                    AssignLanguage(tr, "tr");
                    break;
                case "az":
                    AssignLanguage(az, "az");
                    break;
                case "be":
                    AssignLanguage(be, "be");
                    break;
                case "he":
                    AssignLanguage(he, "he");
                    break;
                case "hy":
                    AssignLanguage(hy, "hy");
                    break;
                case "ka":
                    AssignLanguage(ka, "ka");
                    break;
                case "et":
                    AssignLanguage(et, "et");
                    break;
                case "fr":
                    AssignLanguage(fr, "fr");
                    break;
                case "kk":
                    AssignLanguage(kk, "kk");
                    break;
                case "ky":
                    AssignLanguage(ky, "ky");
                    break;
                case "lt":
                    AssignLanguage(lt, "lt");
                    break;
                case "lv":
                    AssignLanguage(lv, "lv");
                    break;
                case "ro":
                    AssignLanguage(ro, "ro");
                    break;
                case "tg":
                    AssignLanguage(tg, "tg");
                    break;
                case "tk":
                    AssignLanguage(tk, "tk");
                    break;
                case "uk":
                    AssignLanguage(uk, "uk");
                    break;
                case "uz":
                    AssignLanguage(uz, "uz");
                    break;
            }
        }

        void AssignLanguage(string translation, string lang)
        {
            if (textUIComponent)
                textUIComponent.text = translation;
            else if (textMeshComponent)
                textMeshComponent.text = translation;

            if (infoYG.fonts.defaultFont != null)
            {
                switch (lang)
                {
                    case "ru":
                        ChangeFont(infoYG.fonts.ru);
                        break;
                    case "en":
                        ChangeFont(infoYG.fonts.en);
                        break;
                    case "tr":
                        ChangeFont(infoYG.fonts.tr);
                        break;
                    case "az":
                        ChangeFont(infoYG.fonts.az);
                        break;
                    case "be":
                        ChangeFont(infoYG.fonts.be);
                        break;
                    case "he":
                        ChangeFont(infoYG.fonts.ru);
                        break;
                    case "hy":
                        ChangeFont(infoYG.fonts.hy);
                        break;
                    case "ka":
                        ChangeFont(infoYG.fonts.ka);
                        break;
                    case "et":
                        ChangeFont(infoYG.fonts.et);
                        break;
                    case "fr":
                        ChangeFont(infoYG.fonts.fr);
                        break;
                    case "kk":
                        ChangeFont(infoYG.fonts.kk);
                        break;
                    case "ky":
                        ChangeFont(infoYG.fonts.ky);
                        break;
                    case "lt":
                        ChangeFont(infoYG.fonts.lt);
                        break;
                    case "lv":
                        ChangeFont(infoYG.fonts.lv);
                        break;
                    case "ro":
                        ChangeFont(infoYG.fonts.ro);
                        break;
                    case "tg":
                        ChangeFont(infoYG.fonts.tg);
                        break;
                    case "tk":
                        ChangeFont(infoYG.fonts.tk);
                        break;
                    case "uk":
                        ChangeFont(infoYG.fonts.uk);
                        break;
                    case "uz":
                        ChangeFont(infoYG.fonts.uz);
                        break;
                }
            }
        }

        public void ChangeFont(Font font)
        {
            if (font == null)
            {
                if (uniqueFont)
                    font = uniqueFont;
                else
                    font = infoYG.fonts.defaultFont;
            }

            if (textUIComponent)
                textUIComponent.font = font;
            else if (textMeshComponent)
                textMeshComponent.font = font;

        }

        public void Serialize()
        {
            textUIComponent = GetComponent<Text>();
            textMeshComponent = GetComponent<TextMesh>();
            infoYG = GameObject.Find("YandexGame").GetComponent<YandexGame>().infoYG;
        }

#if UNITY_EDITOR
        public float textHeight = 20f;
        public string processTranslateLabel;
        public bool componentTextField;

        public void Translate(int countLangAvailable)
        {
            StartCoroutine(TranslateEmptyFields(countLangAvailable));
        }

        string TranslateGoogle(string translationTo = "en")
        {
            return "nothing";
        }

        public int countLang = 0;
        IEnumerator TranslateEmptyFields(int countLangAvailable)
        {
            countLang = 0;

            processTranslateLabel = "processing... 0/" + countLangAvailable;

            if (infoYG.languages.ru && (ru == null || ru == ""))
            {
                bool complete = false;
                ru = TranslateGoogle("ru");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }

                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.en && (en == null || en == ""))
            {
                bool complete = false;
                en = TranslateGoogle("en");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }

                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.tr && (tr == null || tr == ""))
            {
                bool complete = false;
                tr = TranslateGoogle("tr");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }

                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.az && (az == null || az == ""))
            {
                bool complete = false;
                az = TranslateGoogle("az");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.be && (be == null || be == ""))
            {
                bool complete = false;
                be = TranslateGoogle("be");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.he && (he == null || he == ""))
            {
                bool complete = false;
                he = TranslateGoogle("he");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.hy && (hy == null || hy == ""))
            {
                bool complete = false;
                hy = TranslateGoogle("hy");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.ka && (ka == null || ka == ""))
            {
                bool complete = false;
                ka = TranslateGoogle("ka");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.et && (et == null || et == ""))
            {
                bool complete = false;
                et = TranslateGoogle("et");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.fr && (fr == null || fr == ""))
            {
                bool complete = false;
                fr = TranslateGoogle("fr");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.kk && (kk == null || kk == ""))
            {
                bool complete = false;
                kk = TranslateGoogle("kk");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.ky && (ky == null || ky == ""))
            {
                bool complete = false;
                ky = TranslateGoogle("ky");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.lt && (lt == null || lt == ""))
            {
                bool complete = false;
                lt = TranslateGoogle("lt");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.lv && (lv == null || lv == ""))
            {
                bool complete = false;
                lv = TranslateGoogle("lv");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.ro && (ro == null || ro == ""))
            {
                bool complete = false;
                ro = TranslateGoogle("ro");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.tg && (tg == null || tg == ""))
            {
                bool complete = false;
                tg = TranslateGoogle("tg");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.tk && (tk == null || tk == ""))
            {
                bool complete = false;
                tk = TranslateGoogle("tk");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.uk && (uk == null || uk == ""))
            {
                bool complete = false;
                uk = TranslateGoogle("uk");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }
            if (infoYG.languages.uz && (uz == null || uz == ""))
            {
                bool complete = false;
                uz = TranslateGoogle("uz");

                if (processTranslateLabel.Contains("error"))
                    processTranslateLabel = countLang + "/" + countLangAvailable + " error";
                else
                {
                    complete = true;
                    processTranslateLabel = countLang + "/" + countLangAvailable;
                }
                yield return complete == true;
                countLang++;
            }

            processTranslateLabel = countLang + "/" + countLangAvailable + " completed";
        }
#endif
    }
}