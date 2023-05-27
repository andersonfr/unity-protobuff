using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    
    private NavigationManager navigation;

    void Start()
    {
        this.navigation = new NavigationManager(this.mainCanvas);
        
        DataCollection dataCollection = new DataCollection();
        dataCollection.Init();

        var popupModel = dataCollection.popupModel;
        var modal = navigation.CreateModal<PopupModal>(PopupModal.PATH);

                
        if (modal != null)
        {
            modal.WireData(popupModel, dataCollection.OnSave);
        }
    }    
}