using Google.Protobuf;
using System;
using System.IO;

public class DataCollection
{
    public readonly PopupModel popupModel = new PopupModel();

    public DataCollection(){}
    public Action OnSave;
    
    public void Init()
    {
        Popup popup = new Popup
        {
            BackgroundColorTheme = "#5DADE2",
            EnableCancel = true,
            Id = 1,
            Message = "Failed to load",
            Title = "Not Found"
        };

        if (File.Exists("data.data"))
        {
            using (Stream output = File.OpenRead("data.data"))
            {
                popup = Popup.Parser.ParseFrom(output);
            }
        }

        popupModel.Message = popup.Message;
        popupModel.BackgroundColorTheme = popup.BackgroundColorTheme;
        popupModel.EnableCancel = popup.EnableCancel;
        popupModel.Title = popup.Title;

        this.OnSave = () =>
        {
            using (Stream output = File.OpenWrite("data.data"))
            {
                popup.WriteTo(output);
            }
        };
    }
}
public class PopupModel
{
    public string Title;
    public string Message;
    public bool EnableCancel;
    public string BackgroundColorTheme;
}
