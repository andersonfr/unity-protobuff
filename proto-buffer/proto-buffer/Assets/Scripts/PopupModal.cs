using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PopupModal : MonoBehaviour
{
    public const string PATH = "Prefabs/UI/Popup";

    [SerializeField] private Button btn_confirm;
    [SerializeField] private Button btn_cancel;
    [SerializeField] private TextMeshProUGUI text_title;
    [SerializeField] private TextMeshProUGUI text_message;
    [SerializeField] private Image img_background;

    public void WireData(PopupModel model, Action OnClickConfirm)
    {
        this.btn_confirm.onClick.AddListener(()=> OnClickConfirm?.Invoke());

        this.text_title.text = model.Title;
        this.text_message.text = model.Message;
        
        if(ColorUtility.TryParseHtmlString(model.BackgroundColorTheme, out var bgColor))
        {
            this.img_background.color = bgColor;
        }
                
        if(model.EnableCancel == false)
        {
            this.btn_cancel.gameObject.SetActive(false);
        }
    }
}
